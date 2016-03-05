using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using RPG.Events;

namespace RPG
{
    //Klasse zur Unterscheidung von Gegnern
    public class Enemy : Character
    {
        const string EigeneGruppe = "Eigene Gruppe";
        const string GegnerischeGruppe = "Gegnerische Gruppe";

        //Abfrage ob der Gegner eine ANimation besitzt
        public bool isAnimated;

        //Liste von ausführbaren Skills
        private List<Skill> performableSkills = new List<Skill>();

        //Liste von nutzbaren Skills
        private List<Skill> useableSkills = new List<Skill>();

        //Skill der Ausgeführt werden soll
        private Skill SkillToPerform { get; set; }
        public string SkillToPerformName { get; private set; }

        //Ziele des Skills
        private List<Character> targets = new List<Character>();
        public List<Character> Targets
        {
            get { return targets; }
        }
        public string TargetName { get; private set; }



        public Enemy(string charName, Classes className, int vita, int mana, int strength,
            int mag, int def, int res, int luck, string standardAnimationPath, string attackAnimationPath, string deathAnimationPath, bool isAnimated)
            : base(charName, className, vita, mana, strength, mag, def, res, luck, standardAnimationPath, attackAnimationPath, deathAnimationPath)
        {
            this.isAnimated = isAnimated;
            LoadSkillHelperClass.AddAllClassSkills(this);
            this.SelectUsableSkills();
        }


        //Ausführen der Gegner KI enemiesOfFoe sind die Spieler und groupOfFoe die Gruppe der Gegner
        public void PerformAI(IEnumerable<Character> enemiesOfFoe, List<Character> groupOfFoe)
        {
            Random r = new Random();

            this.SetPerformSkills(groupOfFoe);

            this.SkillToPerform = this.performableSkills.ElementAt(r.Next(0, (this.performableSkills.Count - 1) * 1000) / 1000);
            this.SkillToPerformName = this.SkillToPerform.Name;

            if (this.SkillToPerform.Target.ToLower() == "Single".ToLower())
            {
                if (this.SkillToPerform.AreaOfEffect.ToLower() == "Enemy".ToLower())
                {
                    this.SetTargetForSingletargetDamageSkill(enemiesOfFoe);
                }
                else
                {
                    this.SetTargetForSingletargetFriendlySkill(groupOfFoe);
                }
            }
            else
            {
                if (this.SkillToPerform.AreaOfEffect.ToLower() == "Enemy".ToLower())
                {
                    this.targets = enemiesOfFoe.ToList();
                    this.TargetName = GegnerischeGruppe;
                }
                else
                {
                    this.targets = groupOfFoe;
                    this.TargetName = EigeneGruppe;
                }
            }

            this.SkillToPerform.Execute(this, this.targets);
        }


        private void SetTargetForSingletargetFriendlySkill(List<Character> groupOfFoe)
        {
            foreach (var effect in this.SkillToPerform.Effects)
            {
                if (effect.GetType() == typeof(Halo) || effect.GetType() == typeof(Heal))
                {
                    groupOfFoe.OrderBy(x => x.Life);
                    groupOfFoe.RemoveAll(x => x.Life <= 0);
                    this.targets = new List<Character>() { groupOfFoe.ElementAt(0) };
                    break;
                }

                if (effect.GetType() == typeof(Resurrection))
                {
                    groupOfFoe.OrderBy(x => x.Life);
                    groupOfFoe.RemoveAll(x => x.Life > 0);
                    this.targets = new List<Character>() { groupOfFoe.ElementAt(0) };
                    break;
                }

                if (effect.GetType() == typeof(RemoveStatusEffect))
                {
                    groupOfFoe.OrderByDescending(x => x.Statuseffects.Count);
                    this.targets = new List<Character>() { groupOfFoe.ElementAt(0) };
                    break;
                }
            }
            this.SetTargetNameForSingleTarget();
        }


        private void SetTargetForSingletargetDamageSkill(IEnumerable<Character> enemiesOfFoe)
        {
            Random r = new Random();
            this.targets = new List<Character>() { enemiesOfFoe.ElementAt(r.Next(0, (enemiesOfFoe.Count() - 1) * 1000) / 1000) };
            this.SetTargetNameForSingleTarget();
        }

        private void SetTargetNameForSingleTarget()
        {
            this.TargetName = this.targets.ElementAt(0).Name;
        }


        //Erstellung der nutzbaren Skills
        private void SelectUsableSkills()
        {
            Random r = new Random();
            for (int i = 0; i <= 3; i++)
            {
                try
                {
                    this.useableSkills.Add(Skills.ElementAt(r.Next(0, this.Skills.Count*1000)/1000));
                }catch(Exception e)
                { }
            }
        }


        //Setzen der ausführbaren Skills
        private void SetPerformSkills(List<Character> groupOfFoe)
        {
            foreach (var skill in this.useableSkills)
            {
                if (skill.Manacosts <= this.Mana)
                {
                    if (skill.Effects.All(effect => effect.GetType() == typeof(Resurrection)))
                    {
                        if (!this.performableSkills.Contains(skill) && 
                            groupOfFoe.All(foe => foe.Life <= 0))
                        {
                            this.performableSkills.Add(skill);
                            continue;
                        }

                    }

                    if (skill.Effects.All(effect => effect.GetType() == typeof(RemoveStatusEffect)))
                    {
                        if (!this.performableSkills.Contains(skill) && 
                            groupOfFoe.All(foe => foe.Statuseffects.Count > 0))
                        {
                            this.performableSkills.Add(skill);
                            continue;
                        }
                    }

                    if (skill.Effects.All(effect => effect.GetType() == typeof(Halo)))
                    {
                        if (!this.performableSkills.Contains(skill) && 
                            groupOfFoe.All(foe => (foe.Life/foe.FightVitality)*100 < 65))
                        {
                            this.performableSkills.Add(skill);
                            continue;
                        }
                    }

                    if (skill.Effects.All(effect => effect.GetType() == typeof(Heal)))
                    {
                        if (!this.performableSkills.Contains(skill) &&
                            groupOfFoe.All(foe => (foe.Life/foe.FightVitality)*100 < 45))
                        {
                            this.performableSkills.Add(skill);
                            continue;
                        }
                    }

                    if (skill.Effects.All(effect => effect.GetType() == typeof(Drain)))
                    {
                        if (!this.performableSkills.Contains(skill) && 
                            (this.Life/this.FightVitality)*100 < 55)
                        {
                            this.performableSkills.Add(skill);
                            continue;
                        }
                    }

                    else
                    {
                        this.performableSkills.Add(skill);
                    }
                }
            }


            int performableSkillsCount = 0;
            MathHelper.Clamp(performableSkillsCount, 1, this.performableSkills.Count);


            for (int i = 0; i < performableSkillsCount / 2; i++)
            {
                this.performableSkills.Add(this.AttackSkill);
            }
            this.performableSkills.Add(this.AttackSkill);


            if (this.useableSkills.All(skill => skill.Manacosts > this.Mana) && useableSkills.Count > 0)
            {
                this.performableSkills.Add(this.RestSkill);
                this.performableSkills.Add(this.RestSkill);
            }
            else if (this.Mana / this.Manapool * 100 <= 40)
            {
                this.performableSkills.Add(this.RestSkill);
            }
        }
    }
}
