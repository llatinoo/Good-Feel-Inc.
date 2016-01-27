using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    class Cursor
    {
        Controls controls = new Controls();
        private Texture2D cursorTexture;
        public void LoadContent(ContentManager content)
        {
            this.cursorTexture = content.Load<Texture2D>("Cursors\\Demon_Sword_Cursor");
        }

        public void Update()
        {
            this.controls.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.cursorTexture, this.controls.VecCursorPos, Color.White);
        }
    }
}
