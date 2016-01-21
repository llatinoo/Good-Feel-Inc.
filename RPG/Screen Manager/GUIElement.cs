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
    class GUIElement
    {
        Controls controls = new Controls();
        //Farbe des GUI Elements
        Color color = Color.White;
        //Textur des Elements
        public Texture2D GUITexture;
        //Größe des Elements
        private Rectangle GUIRect;

        public Rectangle getGUIRect
        {
            get { return GUIRect; }
        }
        //Pfad zur Textur
        private string assetName;
        public string AssetName
        {
            get { return assetName;}
            set { assetName = value;}
        }

        //Event das beim drücken auf ein GUI Element ausgeführt wird
        public delegate void ElementClicked(string element);
        public event ElementClicked clickEvent;
        public GUIElement(string assetName)
        {
            this.assetName = assetName;
        }
        public void LoadContent(ContentManager content)
        {
            GUITexture = content.Load<Texture2D>(assetName);
            GUIRect = new Rectangle(0, 0, GUITexture.Width, GUITexture.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(GUITexture, GUIRect, color);
                if (GUIRect.Contains(controls.CursorPos) && Mouse.GetState().LeftButton != ButtonState.Pressed && assetName.Contains("Button"))
                {
                    spriteBatch.Draw(GUITexture, GUIRect, Color.LightYellow);
                }

                spriteBatch.Draw(GUITexture, GUIRect, color);
        }
        
        public void Update()
        {
            controls.Update();

            //Wenn sich die Maus mit der Textur schneidet und dann der linke Mausbutton gedrückt wird, wird das ClickEvent ausgelöst
            if (GUIRect.Contains(controls.CursorPos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clickEvent(assetName);
            }
            if (GUIRect.Contains(controls.CursorPos) && controls.CurrentKeyboardState.IsKeyDown(Keys.Enter))
            {
                clickEvent(assetName);
            }
        }

        //GUI Element wir in die mitte geschoben
        public void CenterElement(int width, int height)
        {
            GUIRect = new Rectangle((height / 2) - (this.GUITexture.Width / 2), 
                (width / 2) - (this.GUITexture.Height / 2),this.GUITexture.Width,this.GUITexture.Height);
        }

        //GUI Element wird verschoben
        public void moveElement(int x, int y)
        {
            GUIRect = new Rectangle(GUIRect.X += x, GUIRect.Y += y, GUIRect.Width, GUIRect.Height);
        }

        public void changeColor(Color newColor)
        {
            color = newColor;
        }
        
    }
}
