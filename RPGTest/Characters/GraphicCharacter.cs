using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace RPGTest.Characters
{
    class GraphicCharacter
    {
        public Texture2D CharTexture;

        public Vector2 Position;

        public bool Active;
        
        public int Width
        {
            get { return CharTexture.Width; }
        }

        public int Height
        {
            get { return CharTexture.Height; }
        }

        public void Initialize(Texture2D texture, Vector2 position)
        {
            CharTexture = texture;
            Position = position;
            Active = true;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(CharTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
