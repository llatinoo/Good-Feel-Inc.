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
            get { return assetName;}
            set { assetName = value;}
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
                GUITexture = content.Load<Texture2D>(assetName);
                GUIRect = new Rectangle(positionY, positionX, GUITexture.Width, GUITexture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GUITexture, GUIRect, Color.White);
            
            //Wenn sich die Maus mit der Textur schneidet leuchtet die textur Gelb
            if (GUIRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton != ButtonState.Pressed && assetName.Contains("Button"))
            {
                spriteBatch.Draw(GUITexture, GUIRect, Color.LightYellow);
            }

        }

        public void Update()
        {
            //Wenn sich die Maus mit der Textur schneidet und dann der linke Mausbutton gedrückt wird, wird das ClickEvent ausgelöst
            if(GUIRect.Contains(new Point(Mouse.GetState().X,Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clickEvent(assetName);
            }
        }

        //GUI Element wir in die mitte geschoben
        public void CenterElement(int height, int width)
        {
            GUIRect = new Rectangle((width / 2) - (this.GUITexture.Width / 2), 
                (height / 2) - (this.GUITexture.Height / 2),this.GUITexture.Width,this.GUITexture.Height);
        }

        //GUI Element wird verschoben
        public void moveElement(int x, int y)
        {
            GUIRect = new Rectangle(GUIRect.X += x, GUIRect.Y += y, GUIRect.Width, GUIRect.Height);
        }
    }
}
