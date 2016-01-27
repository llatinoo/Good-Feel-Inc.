using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Screen_Manager
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
