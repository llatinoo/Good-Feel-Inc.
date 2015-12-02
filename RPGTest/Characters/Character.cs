using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGTest
{
    class Character
    {
        public Texture2D CharTexture;

        public Vector2 Position;

        public string name;

        public int Vitality;
        public int Strength;
        public int Magic;
        public int Defense;
        public int Mana;
        public int Luck;

        public int Width
        {
            get { return CharTexture.Width; }
        }

        public int Height
        {
            get { return CharTexture.Height; }
        }

        //TODO Konstruktor
        public void Initialize(Texture2D texture, Vector2 position, int vita, int strg, int mag, int def, int mana, int luck)
        {
            CharTexture = texture;
            Position = position;
            Vitality = vita;
            Strength = strg;
            Magic = mag;
            Defense = def;
            Mana = mana;
            Luck = luck;

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
