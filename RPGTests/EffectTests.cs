using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;
using RPG.Skills.Effects;

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

            enemy.Life = enemy.FightVitality;
            partymember.Life = partymember.FightVitality;

            //Crit
            new CriticalDamage().Execute(partymember,new List<Character>() {enemy});
            Assert.IsTrue(enemy.FightVitality > enemy.Life);

            //DMG
            enemy = this.ResetEnemy();
            partymember = this.ResetPartyMember();

            new Damage().Execute(partymember, new List<Character>() { enemy });
            Assert.IsTrue(enemy.FightVitality > enemy.Life);

            //MagicalDMG
            enemy = this.ResetEnemy();
            partymember = this.ResetPartyMember();

            new MagicalDamage().Execute(partymember, new List<Character>() {enemy});
            Assert.IsTrue(enemy.FightVitality > enemy.Life);

            //Drain
            enemy = this.ResetEnemy();
            partymember = this.ResetPartyMember();
            partymember.Life = partymember.FightVitality / 2;

            int oldLife = partymember.Life;

            new Drain().Execute(partymember,new List<Character>() {enemy});
            Assert.IsTrue(enemy.FightVitality > enemy.Life);
            Assert.IsTrue(oldLife < partymember.Life);

            //Heal
            partymember = this.ResetPartyMember();
            partymember.Life = partymember.FightVitality / 2;

            oldLife = partymember.Life;

            new Heal().Execute(partymember, new List<Character>() { partymember });
            Assert.IsTrue(oldLife < partymember.Life);

            //AttributesChange Effects
            partymember = this.ResetPartyMember();

            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightVitality).Execute(partymember, new List<Character>() {partymember});
            Assert.IsTrue(partymember.Vitality < partymember.FightVitality);

            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightManaPool).Execute(partymember, new List<Character>() { partymember });
            Assert.IsTrue(partymember.Manapool < partymember.FightManaPool);

            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightStrength).Execute(partymember, new List<Character>() { partymember });
            Assert.IsTrue(partymember.Strength < partymember.FightStrength);

            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightMagic).Execute(partymember, new List<Character>() { partymember });
            Assert.IsTrue(partymember.Magic < partymember.FightMagic);

            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightDefense).Execute(partymember, new List<Character>() { partymember });
            Assert.IsTrue(partymember.Defense < partymember.FightDefense);

            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightResistance).Execute(partymember, new List<Character>() { partymember });
            Assert.IsTrue(partymember.Resistance < partymember.FightResistance);

            new AttributesChangeEffect(AttributeActions.Add, Attributes.FightLuck).Execute(partymember, new List<Character>() { partymember });
            Assert.AreNotEqual(partymember.Luck, partymember.FightLuck);
        }

        [TestMethod]
        public void StatusEffectsTests()
        {
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

            enemy.Life = enemy.FightVitality;
            partymember.Life = enemy.FightVitality;

            int duration;

            //bleed
            new Bleed().Execute(partymember, new List<Character>() {enemy});
            foreach (var effect in enemy.Statuseffects)
            {
                duration = effect.Duration;
                enemy.Life -= effect.ExecuteStatus();
                Assert.IsTrue(effect.Duration < duration);
            }
            Assert.IsTrue(enemy.FightVitality > enemy.Life);

            //burn
            enemy = this.ResetEnemy();
            partymember = this.ResetPartyMember();

            new Burn().Execute(partymember, new List<Character>() { enemy });
            foreach (var effect in enemy.Statuseffects)
            {
                duration = effect.Duration;
                enemy.Life -= effect.ExecuteStatus();
                Assert.IsTrue(effect.Duration < duration);
            }
            Assert.IsTrue(enemy.FightVitality > enemy.Life);

            //poisoned
            enemy = this.ResetEnemy();
            partymember = this.ResetPartyMember();

            new Poison().Execute(partymember, new List<Character>() { enemy });
            foreach (var effect in enemy.Statuseffects)
            {
                enemy.Life -= effect.ExecuteStatus();
            }
            Assert.IsTrue(enemy.FightVitality > enemy.Life);

            //mindblown
            enemy = this.ResetEnemy();
            partymember = this.ResetPartyMember();

            new Mindblow().Execute(partymember,new List<Character>() {enemy});
            foreach (var effect in enemy.Statuseffects)
            {
                duration = effect.Duration;
                effect.ExecuteStatus();
                Assert.IsTrue(effect.Duration < duration);
            }

            //blessing
            partymember = this.ResetPartyMember();
            new Bless().Execute(partymember,new List<Character>() {partymember});
            partymember.Life = 0;
            if (partymember.Statuseffects.All(effect => effect.GetType() == typeof (Blessing)))
            {
                partymember.Life = 1;
            }
            Assert.IsTrue(partymember.Life == 1);

            foreach (var effect in partymember.Statuseffects)
            {
                duration = effect.Duration;
                effect.ExecuteStatus();
                Assert.IsTrue(effect.Duration < duration);
            }

            //halo
            enemy = this.ResetEnemy();
            partymember = this.ResetPartyMember();
            partymember.Life = partymember.FightVitality/2;

            int oldLife;
            oldLife = partymember.Life;

            new Halo().Execute(partymember, new List<Character>() {partymember});
            foreach (var effect in partymember.Statuseffects)
            {
                duration = effect.Duration;
                partymember.Life -= effect.ExecuteStatus();
                Assert.IsTrue(effect.Duration < duration);
            }
            Assert.IsTrue(partymember.Life > oldLife);
        }

        public Enemy ResetEnemy()
        {
            var enemy = new Enemy
            (
                "Enemy",
                Classes.Coloss,
                "",
                "",
                "",
                false
            );

            enemy.Life = enemy.FightVitality;

            return enemy;
        }

        public PartyMember ResetPartyMember()
        {
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

            partymember.Life = partymember.FightVitality;

            return partymember;
        }
    }
}
