using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SchulProjekt
{
    class GUIElement
    {
        //Textur des Elements
        private Texture2D GUITexture;
        //Größe des Elements
        private Rectangle GUIRect;
        //Pfad zur Textur
        private string assetName;
        //Position des Elements
        private int positionY;
        private int positionX;
           
        public string AssetName
        {
            get { return this.assetName;}
            set { this.assetName = value;}
        }

        //Event das beim drücken auf ein GUI Element usgeführt wird
        public delegate void ElementClicked(string element);
        public event ElementClicked clickEvent;
        public GUIElement(string assetName, int positionY, int positionX)
        {
            this.assetName = assetName;
            this.positionX = positionX;
            this.positionY = positionY;
        }
        public void LoadContent(ContentManager content)
        {
            this.GUITexture = content.Load<Texture2D>(this.assetName);
            this.GUIRect = new Rectangle(this.positionY, this.positionX, this.GUITexture.Width, this.GUITexture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.GUITexture, this.GUIRect, Color.White);
            
            //Wenn sich die Maus mit der Textur schneidet leuchtet die textur Gelb
            if (this.GUIRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton != ButtonState.Pressed && this.assetName.Contains("Button"))
            {
                spriteBatch.Draw(this.GUITexture, this.GUIRect, Color.LightYellow);
            }

        }

        public void Update()
        {
            //Wenn sich die Maus mit der Textur schneidet und dann der linke Mausbutton gedrückt wird, wird das ClickEvent ausgelöst
            if(this.GUIRect.Contains(new Point(Mouse.GetState().X,Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.clickEvent(this.assetName);
            }
        }

        //GUI Element wir in die mitte geschoben
        public void CenterElement(int height, int width)
        {
            this.GUIRect = new Rectangle((width / 2) - (this.GUITexture.Width / 2), 
                (height / 2) - (this.GUITexture.Height / 2),this.GUITexture.Width,this.GUITexture.Height);
        }

        //GUI Element wird verschoben
        public void moveElement(int x, int y)
        {
            this.GUIRect = new Rectangle(this.GUIRect.X += x, this.GUIRect.Y += y, this.GUIRect.Width, this.GUIRect.Height);
        }
    }
}
