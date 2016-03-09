using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RPG
{
    public class TextElement
    {
        bool LoadedOnes = false;
        Controls controls = new Controls();
        SpriteFont Font;
        private Vector2 fontSize;
        SoundEffect MouseIntersect;
        private bool rectangleContainedMouseBefore;

        string skillName;
        public string SkillName
        {
            get { return skillName; }
        }
        public int positionX { get; set; }
        public int positionY { get; set; }

        public Rectangle textRect;
        bool clickAble;

        public delegate void tElementClicked(string element);
        public event tElementClicked tclickEvent;
        public TextElement(SpriteFont Font, string skillName, int positionX, int positionY, bool clickAble, SoundEffect MouseIntersect)
        {
            this.skillName = skillName;
            this.positionX = positionX;
            this.positionY = positionY;
            this.clickAble = clickAble;
            this.MouseIntersect = MouseIntersect;
            this.Font = Font;
        }

        public TextElement(SpriteFont Font, string skillName, int positionX, int positionY, bool clickAble)
        {
            this.skillName = skillName;
            this.positionX = positionX;
            this.positionY = positionY;
            this.clickAble = clickAble;
            this.Font = Font;
        }

        public void Update()
        {
            if (!LoadedOnes)
            {
                if (clickAble)
                {
                    this.fontSize = this.Font.MeasureString(this.skillName);
                    this.textRect = new Rectangle(this.positionX, this.positionY, (int)this.fontSize.X, (int)this.fontSize.Y);
                }
                LoadedOnes = true;
            }
            this.controls.Update();
            if (clickAble)
            {
                if (this.textRect.Contains(this.controls.CursorPos) && !rectangleContainedMouseBefore)
                {
                    rectangleContainedMouseBefore = true;
                    MouseIntersect.Play();
                }
                if (!textRect.Contains(this.controls.CursorPos))
                {
                    rectangleContainedMouseBefore = false;
                }
                if (this.textRect.Contains(this.controls.CursorPos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    rectangleContainedMouseBefore = false;
                    this.tclickEvent(this.skillName);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.Font, this.skillName, new Vector2(this.positionX, this.positionY), Color.White);
            if (this.textRect.Contains(this.controls.CursorPos))
            {
                spriteBatch.DrawString(this.Font, this.skillName, new Vector2(this.positionX, this.positionY), Color.Blue);
            }
        }
      }
    }
