using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;
using RPG.Skills.Effects;

namespace RPGTests
{
    using System.Collections.Generic;

    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void CharacterInitializeTests()
        {
            var character = new Character
                (
                    "Char",
                    Classes.Warrior,
                    "",
                    "",
                    ""
                );

            var enemy = new Enemy
                (
                    "Enemy",
                    Classes.Coloss,
                    "",
                    "",
                    "", 
                    false
                );

            var partymember = new PartyMember
                (
                    "Char",
                    Classes.DamageDealer,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 },
                    100,
                    "",
                    "",
                    ""
                );

            var player = new Player
            (
                "Char",
                Classes.Patron,
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 },
                100,
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 },
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 },
                "",
                "",
                ""
            );

            List<Character> Chars = new List<Character>() {player, enemy, character, partymember};

            foreach (var Char in Chars)
            {
                if (Char.GetType() == (typeof (Player)))
                {
                    Assert.IsTrue(true);
                }
                if (Char.GetType() == (typeof(Enemy)))
                {
                    Assert.IsTrue(true);
                }
                if (Char.GetType() == (typeof(Character)))
                {
                    Assert.IsTrue(true);
                }
                if (Char.GetType() == (typeof(PartyMember)))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsFalse(false);
                }
            }

            Assert.IsNotNull(Chars);
        }

        [TestMethod]
        public void CharacterStandardSkillsTest()
        {
            var Warrior = new Character
                (
                    "Warrior",
                    Classes.Warrior,
                    "",
                    "",
                    ""
                );

            var Harasser = new Character
                (
                    "Harasser",
                    Classes.Harasser,
                    "",
                    "",
                    ""
                );

            Assert.IsTrue(Warrior.AttackSkill.Effects.All(effect => effect.GetType() == typeof(Damage)) && !Warrior.AttackSkill.Effects.All(effect => effect.GetType() == typeof(MagicalDamage)));
            Assert.IsTrue(Harasser.AttackSkill.Effects.All(effect => effect.GetType() == typeof(MagicalDamage)) && !Harasser.AttackSkill.Effects.All(effect => effect.GetType() == typeof(Damage)));
            Assert.IsNotNull(Warrior.RestSkill);
        }
    }
}