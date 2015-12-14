using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace RPG.Characters
{
    //Graphische Daten eines Charakters
    public class GraphicCharacter
    {
        //Sprite eines Charakters
        public Texture2D CharTexture { get; set; }

        //Position eines Charakters
        public Vector2 Position { get; set; }

        public bool Active { get; set; }

        public int Width => this.CharTexture.Width;

        public int Height => this.CharTexture.Height;


        public void Initialize(Texture2D texture, Vector2 position)
        {
            this.CharTexture = texture;
            this.Position = position;
            this.Active = true;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.CharTexture, this.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
