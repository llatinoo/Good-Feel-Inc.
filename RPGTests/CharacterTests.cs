using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPGTests
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.Characters;
    using RPG.Skills;
    using RPG.Skills.StatusEffects;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void CharakterInitzializeTest()
        {
            var PartyMember = new PartyMember
                (
                    "Nero",
                    null,
                    new Vector2(0, 0),
                    100,
                    100,
                    100,
                    100,
                    100,
                    10,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
                );

            PartyMember.AddSkill(new Skill("Genozid", 30, new List<IEffect>() { new Bleed(), new CriticalDamage() }));

            var Enemy = new Enemy
                (
                    "King",
                    null,
                    new Vector2(0, 0),
                    100,
                    100,
                    100,
                    100,
                    100,
                    10,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
                );

            Enemy.AddSkill(new Skill("Springer", 40, new List<IEffect>() { new StatsChange("+", "strength"), new StatsChange("+", "strength"), new StatsChange("-", "vitality") }));


            Skill executePartySkill = PartyMember.Skills.SingleOrDefault(skill => skill.Name.Equals("Genozid"));
            Skill executeEnemySkill = Enemy.Skills.SingleOrDefault(skill => skill.Name.Equals("Springer"));

            executePartySkill.Execute(PartyMember, new List<Character>() { Enemy });
            executeEnemySkill.Execute(Enemy, new List<Character>() { PartyMember });
        }

        [TestMethod]
        public void EffectTests()
        {
            var character = new Character
                (
                    "Char",
                    null,
                    new Vector2(0, 0),
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
                    null,
                    new Vector2(0, 0),
                    1000000,
                    100,
                    100,
                    100,
                    1000000,
                    10,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
                );
            
            character.AddSkill(new Skill("Bleed", 0, new List<IEffect>() { new Bleed() }));
            character.AddSkill(new Skill("Bless", 0, new List<IEffect> { new Bless() }));
            character.AddSkill(new Skill("Burn", 0, new List<IEffect> { new Burn() }));
            character.AddSkill(new Skill("Halo", 0, new List<IEffect> { new Halo() }));
            character.AddSkill(new Skill("Mindblow", 0, new List<IEffect> { new Mindblow() }));
            character.AddSkill(new Skill("Poison", 0, new List<IEffect> { new Poison() }));
            character.AddSkill(new Skill("StatsChange", 0, new List<IEffect> { new StatsChange("+", "strength") }));
            character.AddSkill(new Skill("CriticalDamage", 0, new List<IEffect> { new CriticalDamage() }));
            character.AddSkill(new Skill("Heal", 0, new List<IEffect> { new Heal() }));
            character.AddSkill(new Skill("Damage", 0, new List<IEffect> { new Damage() }));

            foreach (Skill skill in character.Skills)
            {
                skill.Execute(character, new List<Character>() { enemy });
            }

            Assert.IsTrue(enemy.Statuseffects.Count != 0);
            Assert.AreNotEqual(enemy.Vitality, enemy.FightVitality);

            enemy.FightVitality = enemy.Vitality;

            foreach(IStatuseffect status in enemy.Statuseffects)
            {
                enemy.FightVitality -= status.ExecuteStatus();
            }

            Assert.AreNotEqual(enemy.Vitality, enemy.FightVitality);
        }
    }
}