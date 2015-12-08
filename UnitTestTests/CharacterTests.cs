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

            PartyMember.AddSkill(new Skill("Genozid", 30, new List<IEffect>() { new Bleed(), new CriticalDamageEffect() }));

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

            Enemy.AddSkill(new Skill("Springer", 40, new List<IEffect>() { new StatsChangeEffect("+", "strength"), new StatsChangeEffect("+", "strength"), new StatsChangeEffect("-", "vitality") }));


            Skill executePartySkill = PartyMember.skills.SingleOrDefault(skill => skill.Name.Equals("Genozid"));
            Skill executeEnemySkill = Enemy.skills.SingleOrDefault(skill => skill.Name.Equals("Springer"));

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
            character.AddSkill(new Skill("Blessing", 0, new List<IEffect> { new Blessing() }));
            character.AddSkill(new Skill("Blessing", 0, new List<IEffect> { new Burn() }));
            character.AddSkill(new Skill("Blessing", 0, new List<IEffect> { new Halo() }));
            character.AddSkill(new Skill("Blessing", 0, new List<IEffect> { new MindBlown() }));
            character.AddSkill(new Skill("Blessing", 0, new List<IEffect> { new Poison() }));
            character.AddSkill(new Skill("Blessing", 0, new List<IEffect> { new StatsChangeEffect("+", "strength") }));
            character.AddSkill(new Skill("Blessing", 0, new List<IEffect> { new CriticalDamageEffect() }));
            character.AddSkill(new Skill("Blessing", 0, new List<IEffect> { new HealEffect() }));

            foreach (Skill skill in character.skills)
            {
                skill.Execute(character, new List<Character>() { enemy });
            }

            bool 
            Assert.Is(enemy.statuseffects);
            Assert. AreNotEqual(1000000, enemy.FightVitality);
        }
    }
}
