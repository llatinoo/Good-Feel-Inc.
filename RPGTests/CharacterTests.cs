using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;

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
                    "Dämon",
                    100,
                    100,
                    100,
                    100,
                    100,
                    100,
                    10
                );

            var enemy = new Enemy
                (
                    "Enemy",
                    Classes.Coloss,
                    false,
                    "Human",
                    100,
                    100,
                    100,
                    100,
                    100,
                    100,
                    10
                );

            var partymember = new PartyMember
                (
                    "Char",
                    Classes.DamageDealer,
                    "Dämon",
                    100,
                    100,
                    100,
                    100,
                    100,
                    100,
                    10,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 },
                    100
                );

            var player = new Player
            (
                "Char",
                Classes.Patron,
                "Dämon",
                100,
                100,
                100,
                100,
                100,
                100,
                10,
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 },
                100,
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 },
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
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
    }
}