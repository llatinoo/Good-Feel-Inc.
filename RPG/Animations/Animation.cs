using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Animations
{
    public class Animation
    {
        //Textur der Animation
        Texture2D sprite;

        //Anzeigegröße des sprites
        float displayedScale;

        //Zeit des letzten Updates
        int elapsedTime;

        //Zeit die ein Frame angezeigt bis zum nächsten
        int frameDisplayTime;

        //Farbe des Frames
        Color color;

        //Teil des Spritesheets der angezeigt werden soll
        Rectangle sourceRect = new Rectangle();

        //Wo das Frame auf dem Bildschirm angezeigt werden soll
        Rectangle destinationRect = new Rectangle();

        //Breite des Frames
        public int frameWidth;

        //Höhe des Frames
        public int frameHeight;

        //Status der Animation
        public bool active;

        //gibt an ob die animation weiter abspielt oder stoppt
        public bool loop;

        //Breite des gegebenen Frames
        public Vector2 position;

        //Horizontale frames des sheets
        int spriteSheetHorizontal;

        //Vertikale frames des sheets
        int spriteSheetVertical;

        //aktuell angezeigter Horizontaler frame
        int currentHorizontalFrame;

        //aktuell angezeigter Vertikaler frame
        int currentVerticalFrame;

        public void LoadContent(Texture2D sprite, Vector2 position, int frameWidth, int frameHeight,
            int frameDisplayTime, Color color, float displayedScale, bool loop, int spriteSheetHorizontal, int spriteSheetVertical)
        {
            this.sprite = sprite;
            this.position = position;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameDisplayTime = frameDisplayTime;
            this.color = color;
            this.displayedScale = displayedScale;
            this.loop = loop;
            this.spriteSheetHorizontal = spriteSheetHorizontal;
            this.spriteSheetVertical = spriteSheetVertical;

            //Zeit wird auf 0 gesetzt
            this.elapsedTime = 0;
            this.currentVerticalFrame = 0;
            this.currentHorizontalFrame = 0;

            //standartmäßig Animation aktiv setzen
            this.active = true;

        }

        public void Update(GameTime gameTime)
        {
            if (this.active == false)
            {
                return;
            }
            //vergangene Zeit updaten
            this.elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Wenn vergangene Zeit größer als anzeigezeit ist, wird das aktuelle Frame geändert
            if (this.elapsedTime > this.frameDisplayTime)
            {
                this.currentVerticalFrame++;
                if (this.currentVerticalFrame == this.spriteSheetVertical)
                {
                    this.currentVerticalFrame = 0;
                    this.currentHorizontalFrame++;
                    if(this.currentHorizontalFrame == this.spriteSheetHorizontal)
                    {
                        this.currentHorizontalFrame = 0;
                    }
                    if (!this.loop)
                    {
                        this.active = false;
                    }
                }

                //vergangene Zeit wird zurückgesetzt
                this.elapsedTime = 0;
            }
            this.sourceRect = new Rectangle(this.frameWidth *this.currentVerticalFrame, this.frameHeight *this.currentHorizontalFrame, this.frameWidth, this.frameHeight);

            //Ziel des anzuzeigenden Frames
            this.destinationRect = new Rectangle((int) this.position.X - (int)(this.frameWidth *this.displayedScale) / 2, 
            (int) this.position.Y - (int)(this.frameHeight *this.displayedScale) / 2, (int)(this.frameWidth *this.displayedScale), (int)(this.frameHeight *this.displayedScale));
                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //nur wenn die Animation aktiv ist wird sie dargestellt
            if(this.active)
            {
                spriteBatch.Draw(this.sprite, this.destinationRect, this.sourceRect, this.color);
            }
        }
    }
}
