using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using RPG.Characters;
using RPG.Data_Section_Classes;
using RPG.Skills;
using RPG.Skills.Effects;

namespace RPG.Extensions_And_Helper_Classes
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

                //Läd alle Effekte dieses Skills
                skillToAddEffects = new List<IEffect>();
                foreach (EffectElement effect in skillToAdd.Effects)
                {
                    skillToAddEffects.Add(GetEffectFactory.GetEffect(effect.Name));
                }

                //Fügt dem Charakter den gewählten Skill hinzu
                character.AddSkill(new Skill(skillToAdd.Name, Convert.ToInt32(skillToAdd.ManaCosts), skillToAdd.Target, skillToAdd.AreaOfEffect, skillToAddEffects));
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
                if (!member.Skills.All(Skill => Skill.Name == charSkill.Name) &&
                    member.Level <= Convert.ToInt32(charSkill.Level))
                {
                    var skillToAdd =
                     skillCadreDataSection.Skills.Cast<SkillElement>()
                         .SingleOrDefault(
                             cadreSkill => cadreSkill.Name == charSkill.Name);

                    skillToAddEffects = new List<IEffect>();
                    foreach (EffectElement effect in skillToAdd.Effects)
                    {
                        skillToAddEffects.Add(GetEffectFactory.GetEffect(effect.Name));
                    }

                    member.AddSkill(new Skill(skillToAdd.Name, Convert.ToInt32(skillToAdd.ManaCosts), skillToAdd.Target, skillToAdd.AreaOfEffect, skillToAddEffects));
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
            foreach (EffectElement effect in attackSkill.Effects)
            {
                attackSkillEffects.Add(GetEffectFactory.GetEffect(effect.Name));
            }

            var recoverSkillEffects = new List<IEffect>();
            foreach (EffectElement effect in recoverSkill.Effects)
            {
                recoverSkillEffects.Add(GetEffectFactory.GetEffect(effect.Name));
            }


            member.SetStandardSkills(
                new Skill(attackSkill.Name, Convert.ToInt32(attackSkill.ManaCosts), attackSkill.Target, attackSkill.AreaOfEffect, attackSkillEffects), 
                new Skill(recoverSkill.Name, Convert.ToInt32(recoverSkill.ManaCosts), recoverSkill.Target, recoverSkill.AreaOfEffect, recoverSkillEffects)
             );
        }
    }
}
