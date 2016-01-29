using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class TextElement
    {
        
        Controls controls = new Controls();
        SpriteFont AwesomeFont;
        private Vector2 fontSize;

        private string skillName;
        private int positionX;
        private int positionY;

        Rectangle textRect;

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
            AwesomeFont = content.Load<SpriteFont>("Fonts\\AwesomeFont");
            fontSize = AwesomeFont.MeasureString(skillName);
            textRect = new Rectangle(positionX, positionY, (int)fontSize.X, (int)fontSize.Y);
        }

        public void Update()
        {
            controls.Update();
            if(textRect.Contains(controls.CursorPos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                tclickEvent(skillName);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(AwesomeFont, skillName, new Vector2(positionX, positionY), Color.White);
            if (textRect.Contains(controls.CursorPos))
            {
                spriteBatch.DrawString(AwesomeFont, skillName, new Vector2(positionX, positionY), Color.DarkBlue);
            }
        }
      }
    }
