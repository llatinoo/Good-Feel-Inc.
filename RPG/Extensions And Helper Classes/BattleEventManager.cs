using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.Events;

namespace RPG.Extensions_And_Helper_Classes
{
    public class BattleEventManager
    {
        Thread BattleThread { get; set; }
        Thread UpdateThread { get; set; }
        Thread DrawThread { get; set; }

        BattleEvent BattleEvent { get; set; }

        GameTime GameTime { get; set; }
        SpriteBatch SpriteBatch { get; set; }

        public BattleEventManager(List<PartyMember> fightCadre, List<Enemy> enemies)
        {
            this.BattleEvent = new BattleEvent(fightCadre, enemies);

            this.BattleThread = new Thread(BattleThreadMethod);
            this.UpdateThread = new Thread(UpdateThreadMethod);
            this.DrawThread = new Thread(DrawThreadMethod);
        }


        public void BattleThreadMethod()
        {
            BattleEvent.Battle();
        }

        public void StartBattle()
        {
            BattleThread.Start();
        }


        private void UpdateThreadMethod()
        {
            this.BattleEvent.Update(this.GameTime);
        }

        public void Update(GameTime gameTime)
        {
            this.GameTime = gameTime;
            if (!this.UpdateThread.IsAlive)
            {
                this.UpdateThread.Start();
            }
        }


        private void DrawThreadMethod()
        {
            this.BattleEvent.Draw(this.SpriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.SpriteBatch = spriteBatch;
            this.DrawThread.Start();
        }


        public void LoadContent(ContentManager contentManager)
        {
            BattleEvent.LoadContent(contentManager);
        }
    }
}
