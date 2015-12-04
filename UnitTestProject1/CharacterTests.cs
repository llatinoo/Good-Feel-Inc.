using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace RPGTests
{
    using RPG.Characters;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void InitzializeTest()
        {
            var a = string.Empty;

            Game game = new Game();
            game.Content.RootDirectory = "Content";
            var PartyMember = new PartyMember
                (
                    "Nero",
                    game.Content.Load<Texture2D>("Graphics//player"),
                    new Vector2(game.GraphicsDevice.Viewport.TitleSafeArea.X, game.GraphicsDevice.Viewport.TitleSafeArea.Y + game.GraphicsDevice.Viewport.TitleSafeArea.Height / 2),
                    100,
                    100,
                    100,
                    100,
                    100,
                    10,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
                );

            PartyMember.AddSkill(new RPG.Skills.Skill("Genozid", 30, new List<RPG.Skills.IEffect>() { new RPG.Skills.StatusEffects.Bleed(), new RPG.Skills.CriticalDamageEffect() }));

            var Enemy = new Enemy
                (
                    "King",
                    game.Content.Load<Texture2D>("Graphics//mine"),
                    new Vector2(game.GraphicsDevice.Viewport.TitleSafeArea.X, game.GraphicsDevice.Viewport.TitleSafeArea.Y + game.GraphicsDevice.Viewport.TitleSafeArea.Height / 2),
                    100,
                    100,
                    100,
                    100,
                    100,
                    10,
                    new List<int>() { 1000, 2000, 4000, 8000, 16000, 32000, 64000 }
                );

            Enemy.AddSkill(new RPG.Skills.Skill("Springer", 40, new List<RPG.Skills.IEffect>() { new RPG.Skills.BuffEffect("strength"), new RPG.Skills.BuffEffect("strength"), new RPG.Skills.DeBuffEffect("vitality") }));


            RPG.Skills.Skill executePartySkill = PartyMember.skills.SingleOrDefault(skill => skill.Name.Equals("Genozid"));
            RPG.Skills.Skill executeEnemySkill = Enemy.skills.SingleOrDefault(skill => skill.Name.Equals("Springer"));

            executePartySkill.Execute(PartyMember, new List<Character>() { Enemy });
            executeEnemySkill.Execute(Enemy, new List<Character>() { PartyMember });

            Assert.AreEqual(1, 2);
        }
    }
}
