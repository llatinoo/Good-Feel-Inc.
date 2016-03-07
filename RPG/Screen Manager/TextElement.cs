using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RPG
{
    class TextElement
    {
        
        Controls controls = new Controls();
        SpriteFont AwesomeFont;
        private Vector2 fontSize;
        SoundEffect MouseIntersect;
        private bool rectangleContainedMouseBefore;

        string skillName;
        public string SkillName
        {
            get { return skillName; }
        }
        private int positionX;
        private int positionY;

        public Rectangle textRect;
        bool clickAble;

        public delegate void tElementClicked(string element);
        public event tElementClicked tclickEvent;
        public TextElement(string skillName, int positionX, int positionY, bool clickAble)
        {
            this.skillName = skillName;
            this.positionX = positionX;
            this.positionY = positionY;
            this.clickAble = clickAble;
        }

        public void LoadContent(ContentManager content)
        {
            MouseIntersect = content.Load<SoundEffect>("Sounds\\Effects\\MouseIntersect");
            //Font mit dem Namen "BasicFont" wird geladen
            this.AwesomeFont = content.Load<SpriteFont>("Fonts\\AwesomeFont");
            if (clickAble)
            {
                this.fontSize = this.AwesomeFont.MeasureString(this.skillName);
                this.textRect = new Rectangle(this.positionX, this.positionY, (int)this.fontSize.X, (int)this.fontSize.Y);
            }
        }

        public void Update()
        {
            this.controls.Update();
            if(this.textRect.Contains(this.controls.CursorPos) && !rectangleContainedMouseBefore)
            {
                rectangleContainedMouseBefore = true;
                MouseIntersect.Play();
            }
            if(!textRect.Contains(this.controls.CursorPos))
            {
                rectangleContainedMouseBefore = false;
            }
            if(this.textRect.Contains(this.controls.CursorPos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                rectangleContainedMouseBefore = false;
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
