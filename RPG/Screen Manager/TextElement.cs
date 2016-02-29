using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG.Screen_Manager
{
    class TextElement
    {
        
        Controls controls = new Controls();
        SpriteFont AwesomeFont;
        private Vector2 fontSize;

        public string skillName;
        private int positionX;
        private int positionY;

        public Rectangle textRect;


        public delegate void tElementClicked(string element);
        public event tElementClicked tclickEvent;
        public TextElement(string skillName, int positionX, int positionY)
        {
            this.skillName = skillName;
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public void LoadContent(ContentManager content)
        {
            //Font mit dem Namen "BasicFont" wird geladen
            this.AwesomeFont = content.Load<SpriteFont>("Fonts\\AwesomeFont");
            this.fontSize = this.AwesomeFont.MeasureString(this.skillName);
            this.textRect = new Rectangle(this.positionX, this.positionY, (int) this.fontSize.X, (int) this.fontSize.Y);
        }

        public void Update()
        {
            this.controls.Update();
            if(this.textRect.Contains(this.controls.CursorPos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.tclickEvent(this.skillName);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.AwesomeFont, this.skillName, new Vector2(this.positionX, this.positionY), Color.White);
            if (this.textRect.Contains(this.controls.CursorPos))
            {
                spriteBatch.DrawString(this.AwesomeFont, this.skillName, new Vector2(this.positionX, this.positionY), Color.DarkBlue);
            }
        }
      }
    }
