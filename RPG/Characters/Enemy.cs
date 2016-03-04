using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using RPG.Events;

namespace RPG
{
    //Klasse zur Unterscheidung von Gegnern
    public class Enemy : Character
    {
        //Abfrage ob der Gegner ein Boss ist
        public bool isBoss;
        //Abfrage ob der Gegner eine ANimation besitzt
        public bool isAnimated;
        //Liste von ausführbaren Skills
        private List<Skill> performableSkills = new List<Skill>();
        //Liste von nutzbaren Skills
        private List<Skill> useableSkills = new List<Skill>();
        //Skill der Ausgeführt werden soll
        private Skill skillToPerform;
        //Mögliche Ziele
        private List<Character> possibleTargets = new List<Character>();
        //Ziele des Skills
        private List<Character> targets = new List<Character>();

        public Enemy(string charName, Classes className, bool isboss, int vita, int mana, int strength,
            int mag, int def, int res, int luck, string standardAnimationPath, string attackAnimationPath, string deathAnimationPath, bool isAnimated)
            : base(charName, className, vita, mana, strength, mag, def, res, luck, standardAnimationPath, attackAnimationPath, deathAnimationPath)
        {
            this.isBoss = isboss;
            this.isAnimated = isAnimated;
            LoadSkillHelperClass.AddAllClassSkills(this);
            this.CutSkills();
        }


        //Ausführen der Gegner KI enemies sind die Spieler und group die Gruppe der Gegner
        public void PerformAI(List<Character> enemys, List<Character> group)
        {
            Random r = new Random();

            this.SetPerformSkills(group);

            this.skillToPerform = this.performableSkills.ElementAt(r.Next(0, this.performableSkills.Count * 1000) / 1000);

            if (this.skillToPerform.Target.ToLower() == "Single".ToLower())
            {
                if (this.skillToPerform.AreaOfEffect.ToLower() == "Enemy".ToLower())
                {
                    this.SetTargetForSingletargetDamageSkill(enemys);
                }
                else
                {
                    this.SetTargetForSingletargetFriendlySkill(group);
                }
            }
            else
            {
                if (this.skillToPerform.AreaOfEffect.ToLower() == "Enemy".ToLower())
                {
                    this.targets = enemys;
                }
                else
                {
                    this.targets = group;
                }
            }

            this.skillToPerform.Execute(this, this.targets);
        }

        private void SetTargetForSingletargetFriendlySkill(List<Character> group)
        {
            foreach (var effect in this.skillToPerform.Effects)
            {
                if (effect.GetType() == typeof(Halo) || effect.GetType() == typeof(Heal))
                {
                    group.OrderBy(x => x.Life);
                    group.RemoveAll(x => x.Life <= 0);
                    this.targets = new List<Character>() { group.ElementAt(0) };
                }

                if (effect.GetType() == typeof(Resurrection))
                {
                    group.OrderBy(x => x.Life);
                    group.RemoveAll(x => x.Life > 0);
                    this.targets = new List<Character>() { group.ElementAt(0) };
                }

                if (effect.GetType() == typeof(RemoveStatusEffect))
                {
                    group.OrderByDescending(x => x.Statuseffects.Count);
                    this.targets = new List<Character>() { group.ElementAt(0) };
                }
            }
        }

        private void SetTargetForSingletargetDamageSkill(List<Character> enemys)
        {
            Random r = new Random();
            this.targets = new List<Character>() { enemys.ElementAt(r.Next(0, enemys.Count * 1000) / 1000) };
        }


        //Erstellung der nutzbaren Skills
        private void CutSkills()
        {
            Random r = new Random();
            for (int i = 0; i <= 3; i++)
            {
                this.useableSkills.Add(Skills.ElementAt(r.Next(0, this.Skills.Count * 1000) / 1000));
            }
        }


        //Setzen der ausführbaren Skills
        private void SetPerformSkills(List<Character> group)
        {
            foreach (var skill in this.useableSkills)
            {
                if (skill.Manacosts <= this.Mana)
                {
                    if (skill.Effects.All(effect => effect.GetType() == typeof(Resurrection)))
                    {
                        if (!this.performableSkills.Contains(skill) && group.All(foe => foe.Life <= 0))
                            this.performableSkills.Add(skill);
                    }

                    if (skill.Effects.All(effect => effect.GetType() == typeof(RemoveStatusEffect)))
                    {
                        if (!this.performableSkills.Contains(skill) && group.All(foe => foe.Statuseffects.Count > 0))
                            this.performableSkills.Add(skill);
                    }

                    if (skill.Effects.All(effect => effect.GetType() == typeof(Halo)))
                    {
                        if (!this.performableSkills.Contains(skill) && group.All(foe => (foe.Life / foe.FightVitality) * 100 < 65))
                            this.performableSkills.Add(skill);
                    }

                    if (skill.Effects.All(effect => effect.GetType() == typeof(Heal)))
                    {
                        if (!this.performableSkills.Contains(skill) && group.All(foe => (foe.Life / foe.FightVitality) * 100 < 45))
                            this.performableSkills.Add(skill);
                    }

                    if (skill.Effects.All(effect => effect.GetType() == typeof(Drain)))
                    {
                        if (!this.performableSkills.Contains(skill) && (this.Life / this.FightVitality) * 100 < 55)
                            this.performableSkills.Add(skill);
                    }

                    else
                    {
                        this.performableSkills.Add(skill);
                    }
                }
            }

            foreach (var skill in this.performableSkills)
            {
                this.performableSkills.Add(this.AttackSkill);
            }

            if ((this.Mana / this.Manapool) * 100 <= 35 || this.performableSkills.All(skill => skill.Manacosts > this.Mana))
            {
                this.performableSkills.Add(this.RestSkill);
            }
        }
    }
}
