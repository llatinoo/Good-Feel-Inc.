using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG.Characters;

namespace RPGTests
{
    /// <summary>
    /// Summary description for EffectTests
    /// </summary>
    [TestClass]
    public class EffectTests
    {
        [TestMethod]
        public void BasicEffectsTests()
        {
            var enemy = new Enemy
            (
                "Enemy",
                Classes.Coloss,
                false,
                "Human",
                100, //vita
                100, //mana
                100, //strength
                100, //magic
                100, //Defense
                100, //Res
                100, //Luck
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
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
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
            );


        }
    }
}
