using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;

namespace RPGTests
{
    /// <summary>
    /// Summary description for AITest
    /// </summary>
    [TestClass]
    public class AITest
    {
        Enemy enemy = new Enemy
            (
                "Enemy",
                Classes.Patron,
                "",
                "",
                "",
                false
            );

        Enemy enemyWithLowHealth = new Enemy
            (
                "Enemy",
                Classes.Coloss,
                "",
                "",
                "",
                false
            );

        Enemy deadEnemy = new Enemy
            (
                "Enemy",
                Classes.Coloss,
                "",
                "",
                "",
                false
            );

        Enemy enemyWithStatusEffects = new Enemy
            (
               "Enemy",
               Classes.Coloss,
               "",
               "",
               "",
               false
            );

        PartyMember partymember = new PartyMember
            (
                "Char",
                Classes.DamageDealer,
                new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 },
                100,
                "",
                "",
                ""
            );


        private List<Enemy> enemies;
        private List<PartyMember> partyMembers;


        public void SetLists()
        {
            enemies = new List<Enemy>() {this.enemy, this.enemyWithLowHealth, this.deadEnemy, this.enemyWithStatusEffects};
            partyMembers = new List<PartyMember>() {this.partymember};
        }

        [TestMethod]
        public void TestPatronAI()
        {
            this.SetLists();

            this.enemy.PerformAI(partyMembers, enemies.Cast<Character>().ToList());
        }
    }
}
