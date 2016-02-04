using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using RPG.Skills;

namespace RPG
{
    public static class LoadSkillHelperClass
    {
        public static void AddAllClassSkills(Character character)
        {
            var skillCadreDataSection =
                ConfigurationManager.GetSection("SkillCadre") as SkillCadreDataSection;
            var classSkillDataSection =
                ConfigurationManager.GetSection("ClassSkillCadre") as ClassSkillCadreDataSection;

            var Class =
                classSkillDataSection.Classes.Cast<ClassElement>()
                    .SingleOrDefault(
                        concreteClass => concreteClass.Name.ToLower() == String.Format(character.Class.ToString().ToLower()));

            List<IEffect> skillToAddEffects;
            foreach (ClassSkillElement classSkill in Class.ClassSkills)
            {
                var skillToAdd =
                    skillCadreDataSection.Skills.Cast<SkillElement>()
                        .SingleOrDefault(
                            cadreSkill => cadreSkill.Name == classSkill.Name);

                skillToAddEffects = new List<IEffect>();
                foreach (EffectElement effect in skillToAdd.Effects)
                {
                    skillToAddEffects.Add(GetEffectFactory.GetEffect(effect.Name));
                }

                character.AddSkill(new Skill(skillToAdd.Name, Convert.ToInt32(skillToAdd.ManaCosts), skillToAddEffects));
            }
        }

        public static void AddCertainSkillToParty(PartyMember member)
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
                if (!member.Skills.All(Skill => Skill.Name == charSkill.Name) &&
                    member.Level >= Convert.ToInt32(charSkill.Level))
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

                    member.AddSkill(new Skill(skillToAdd.Name, Convert.ToInt32(skillToAdd.ManaCosts), skillToAddEffects));
                }
            }
        }
    }
}
