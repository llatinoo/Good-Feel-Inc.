﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using RPG.Skills;

namespace RPG
{
    public static class LoadSkillHelperClass
    {
        //Hinzufügen aller Skills einer Klasse
        //Gedacht für Gegner
        public static void AddAllClassSkills(Character character)
        {
            //Aufrufen der benötigten Sections
            var skillCadreDataSection =
                ConfigurationManager.GetSection("SkillCadre") as SkillCadreDataSection;
            var classSkillDataSection =
                ConfigurationManager.GetSection("ClassSkillCadre") as ClassSkillCadreDataSection;

            //Heraussuchen der gesuchten Klasse
            var Class =
                classSkillDataSection.Classes.Cast<ClassElement>()
                    .SingleOrDefault(
                        concreteClass => concreteClass.Name.ToLower() == String.Format(character.Class.ToString().ToLower()));

            //Herauslesen aller Skills der gewählten Klasse
            List<IEffect> skillToAddEffects;
            foreach (ClassSkillElement classSkill in Class.ClassSkills)
            {
                //Holt den Referenzierten Skill aus dem Skill Cadre
                var skillToAdd =
                    skillCadreDataSection.Skills.Cast<SkillElement>()
                        .SingleOrDefault(
                            cadreSkill => cadreSkill.Name == classSkill.Name);

                if (character.Level >= Convert.ToInt32(skillToAdd.Level))
                {
                    //Läd alle Effekte dieses Skills
                    skillToAddEffects = new List<IEffect>();
                    foreach (EffectElement effect in skillToAdd.Effects)
                    {
                        skillToAddEffects.Add(GetEffectFactory.GetEffect(effect.Name));
                    }

                    //Fügt dem Charakter den gewählten Skill hinzu
                    character.AddSkill(new Skill(skillToAdd.Name,
                        LoadSkillHelperClass.GetManaCosts(Convert.ToInt32(skillToAdd.Level)), skillToAdd.Target,
                        skillToAdd.AreaOfEffect, skillToAddEffects));
                }
            }
        }


        //Hinzufügen aller Skills die ein Partymember bei einem gegebenen Level haben muss
        public static void AddLevelUpSkillToParty(PartyMember member)
        {
            var skillCadreDataSection =
                ConfigurationManager.GetSection("SkillCadre") as SkillCadreDataSection;
            var partySkillCadreDataSection =
                ConfigurationManager.GetSection("PartySkillCadre") as PartySkillCadreDataSection;

            var Char =
                partySkillCadreDataSection.Chars.Cast<CharElement>()
                    .SingleOrDefault(
                        concreteChar => concreteChar.Name.ToLower() == member.Name.ToLower());

            List<IEffect> skillToAddEffects;
            foreach ( CharSkillElement charSkill in Char.CharSkills)
            {
                //Überprufen ob der Charakter das erforderliche Level für den Skills besitzt
                //und ob der Charakter diesen Skill bereits besitzt
                
                    var skillToAdd =
                     skillCadreDataSection.Skills.Cast<SkillElement>()
                         .SingleOrDefault(
                             cadreSkill => cadreSkill.Name == charSkill.Name);

                if (!member.Skills.All(Skill => Skill.Name == charSkill.Name) &&
                    member.Level <= Convert.ToInt32(skillToAdd.Level))
                {
                    skillToAddEffects = new List<IEffect>();
                    foreach (EffectElement effect in skillToAdd.Effects)
                    {
                        skillToAddEffects.Add(GetEffectFactory.GetEffect(effect.Name));
                    }

                    member.AddSkill(new Skill(skillToAdd.Name, LoadSkillHelperClass.GetManaCosts(Convert.ToInt32(skillToAdd.Level)), skillToAdd.Target, skillToAdd.AreaOfEffect, skillToAddEffects));
                }
            }
        }


        //Setzen der Standard Skills 'Angriff' und 'Ausruhen'
        public static void AddStandardSkills(Character member)
        {
            var skillCadreDataSection =
                ConfigurationManager.GetSection("SkillCadre") as SkillCadreDataSection;

            var attackSkill =
                     skillCadreDataSection.Skills.Cast<SkillElement>()
                         .SingleOrDefault(
                             cadreSkill => cadreSkill.Name == "Angriff");

            var recoverSkill =
                     skillCadreDataSection.Skills.Cast<SkillElement>()
                         .SingleOrDefault(
                             cadreSkill => cadreSkill.Name == "Ausruhen");


            var attackSkillEffects = new List<IEffect>();

            if (member.Class.Equals(Classes.Harasser) || member.Class.Equals(Classes.Patron))
            {
                foreach (EffectElement effect in attackSkill.Effects)
                {
                    if (effect.Name.Equals("MagicalDamage"))
                    {
                        attackSkillEffects.Add(GetEffectFactory.GetEffect(effect.Name));
                    }
                }
            }
            else
            {
                foreach (EffectElement effect in attackSkill.Effects)
                {
                    if (effect.Name.Equals("Damage"))
                    {
                        attackSkillEffects.Add(GetEffectFactory.GetEffect(effect.Name));
                    }
                }
            }


            var recoverSkillEffects = new List<IEffect>();
            foreach (EffectElement effect in recoverSkill.Effects)
            {
                recoverSkillEffects.Add(GetEffectFactory.GetEffect(effect.Name));
            }


            member.SetStandardSkills(
                new Skill(attackSkill.Name, LoadSkillHelperClass.GetManaCosts(Convert.ToInt32(attackSkill.Level)), attackSkill.Target, attackSkill.AreaOfEffect, attackSkillEffects), 
                new Skill(recoverSkill.Name, LoadSkillHelperClass.GetManaCosts(Convert.ToInt32(recoverSkill.Level)), recoverSkill.Target, recoverSkill.AreaOfEffect, recoverSkillEffects)
             );
        }

        public static int GetManaCosts(int level)
        {
            if (level == 2)
            {
                return 30;
            }
            if (level == 4)
            {
                return 50;
            }
            if (level == 6)
            {
                return 65;
            }
            if (level == 8)
            {
                return 80;
            }

            return 0;
        }
    }
}
