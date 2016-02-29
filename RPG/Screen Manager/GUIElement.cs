using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        int PositionX;
        int PositionY;
        public Rectangle getGUIRect
        {
            get { return this.GUIRect; }
        }
        //Pfad zur Textur
        private string assetName;
        public string AssetName
        {
            get { return this.assetName;}
            set { this.assetName = value;}
        }

        //Event das beim drücken auf ein GUI Element ausgeführt wird
        public delegate void ElementClicked(string element);
        public event ElementClicked clickEvent;

        public GUIElement(string assetName)
        {
            this.assetName = assetName;
            this.PositionX = 0;
            this.PositionY = 0;
        }
        public GUIElement(string assetName,int PositionX, int PositionY)
        {
            this.assetName = assetName;
            this.PositionX = PositionX;
            this.PositionY = PositionY;
        }
        public void LoadContent(ContentManager content)
        {
            this.GUITexture = content.Load<Texture2D>(this.assetName);
            this.GUIRect = new Rectangle(this.PositionX, this.PositionY, this.GUITexture.Width, this.GUITexture.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(this.GUITexture, this.GUIRect, this.color);
                if (this.GUIRect.Contains(this.controls.CursorPos) && Mouse.GetState().LeftButton != ButtonState.Pressed && this.assetName.Contains("Button"))
                {
                    spriteBatch.Draw(this.GUITexture, this.GUIRect, Color.PaleVioletRed);
                }
        }
        
        public void Update()
        {
            this.controls.Update();

            //Wenn sich die Maus mit der Textur schneidet und dann der linke Mausbutton gedrückt wird, wird das ClickEvent ausgelöst
            if (this.GUIRect.Contains(this.controls.CursorPos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.clickEvent(this.assetName);
            }
            if (this.GUIRect.Contains(this.controls.CursorPos) && this.controls.CurrentKeyboardState.IsKeyDown(Keys.Enter))
            {
                this.clickEvent(this.assetName);
            }
        }

        //GUI Element wir in die mitte geschoben
        public void CenterElement(int width, int height)
        {
            this.GUIRect = new Rectangle((height / 2) - (this.GUITexture.Width / 2), 
                (width / 2) - (this.GUITexture.Height / 2),this.GUITexture.Width,this.GUITexture.Height);
        }

        //GUI Element wird verschoben
        public void moveElement(int x, int y)
        {
            this.GUIRect = new Rectangle(this.GUIRect.X += x, this.GUIRect.Y += y, this.GUIRect.Width, this.GUIRect.Height);
        }

        public void changeColor(Color newColor)
        {
            this.color = newColor;
        }
        
    }
}
