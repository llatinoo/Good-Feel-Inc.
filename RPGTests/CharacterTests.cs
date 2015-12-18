using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPGTests
{
    using Microsoft.Xna.Framework;
    using RPG.Characters;
    using RPG.Skills;
    using RPG.Skills.StatusEffects;
    using System.Collections.Generic;

    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void EffectTests()
        {
            var character = new Character
                (
                    "Char",
                    1000000,
                    100,
                    100,
                    100,
                    1000000,
                    10,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
                );

            var enemy = new Enemy
                (
                    "Enemy",
                    1000000,
                    100,
                    100,
                    100,
                    1000000,
                    10,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
                );

            Assert.IsNotNull(enemy);
            Assert.IsNotNull(character);

            character.AddSkill(new Skill("Bleed", 0, new List<IEffect>() { new Bleed() }));
            character.AddSkill(new Skill("Bless", 0, new List<IEffect> { new Bless() }));
            character.AddSkill(new Skill("Burn", 0, new List<IEffect> { new Burn() }));
            character.AddSkill(new Skill("Halo", 0, new List<IEffect> { new Halo() }));
            character.AddSkill(new Skill("Mindblow", 0, new List<IEffect> { new Mindblow() }));
            character.AddSkill(new Skill("Poison", 0, new List<IEffect> { new Poison() }));

            character.AddSkill(new Skill("CriticalDamage", 0, new List<IEffect> { new CriticalDamage() }));
            character.AddSkill(new Skill("Heal", 0, new List<IEffect> { new Heal() }));
            character.AddSkill(new Skill("Damage", 0, new List<IEffect> { new Damage() }));
            character.AddSkill(new Skill("Drain", 0, new List<IEffect> { new Drain() }));

            character.AddSkill(new Skill("StatsChange", 0, new List<IEffect> { new StatsChange(StatActions.Add, Attributes.FightVitality) }));
            character.AddSkill(new Skill("StatsChange", 0, new List<IEffect> { new StatsChange(StatActions.Substract, Attributes.FightStrength) }));
            character.AddSkill(new Skill("StatsChange", 0, new List<IEffect> { new StatsChange(StatActions.Add, Attributes.FightMagic) }));
            character.AddSkill(new Skill("StatsChange", 0, new List<IEffect> { new StatsChange(StatActions.Substract, Attributes.FightDefense) }));
            character.AddSkill(new Skill("StatsChange", 0, new List<IEffect> { new StatsChange(StatActions.Add, Attributes.FightMana) }));
            character.AddSkill(new Skill("StatsChange", 0, new List<IEffect> { new StatsChange(StatActions.Substract, Attributes.FightLuck) }));

            Assert.AreNotEqual(0, character.Skills.Count);

            foreach (Skill skill in character.Skills)
            {
                skill.Execute(character, new List<Character>() { enemy });
            }

            Assert.IsFalse(enemy.Statuseffects.Count == 0);
            Assert.AreNotEqual(enemy.Vitality, enemy.FightVitality);
            Assert.AreNotEqual(enemy.Strength, enemy.FightStrength);
            Assert.AreNotEqual(enemy.Magic, enemy.FightMagic);
            Assert.AreNotEqual(enemy.Defense, enemy.FightDefense);
            Assert.AreNotEqual(enemy.Mana, enemy.FightVitality);
            Assert.AreNotEqual(enemy.Luck, enemy.FightLuck);

            enemy.FightVitality = enemy.Vitality;

            foreach(IStatuseffect status in enemy.Statuseffects)
            {
                enemy.FightVitality -= status.ExecuteStatus();
            }

            Assert.AreNotEqual(enemy.Vitality, enemy.FightVitality);

            character.UpdateStat(50,MainAttributes.Defense);

            Assert.IsTrue(character.Defense > 100);

        }
    }
}