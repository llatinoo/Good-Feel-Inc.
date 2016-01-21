using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace RPG
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
            elapsedTime = 0;
            currentVerticalFrame = 0;
            currentHorizontalFrame = 0;

            //standartmäßig Animation aktiv setzen
            active = true;

        }

        public void Update(GameTime gameTime)
        {
            if (active == false)
            {
                return;
            }
            //vergangene Zeit updaten
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Wenn vergangene Zeit größer als anzeigezeit ist, wird das aktuelle Frame geändert
            if (elapsedTime > frameDisplayTime)
            {
                currentVerticalFrame++;
                if (currentVerticalFrame == spriteSheetVertical)
                {
                    currentVerticalFrame = 0;
                    currentHorizontalFrame++;
                    if(currentHorizontalFrame == spriteSheetHorizontal)
                    {
                        currentHorizontalFrame = 0;
                    }
                    if (!loop)
                    {
                        active = false;
                    }
                }

                //vergangene Zeit wird zurückgesetzt
                elapsedTime = 0;
            }
                sourceRect = new Rectangle(frameWidth * currentVerticalFrame, frameHeight * currentHorizontalFrame, frameWidth, frameHeight);

            //Ziel des anzuzeigenden Frames
            destinationRect = new Rectangle((int)position.X - (int)(frameWidth * displayedScale) / 2, 
            (int)position.Y - (int)(frameHeight * displayedScale) / 2, (int)(frameWidth * displayedScale), (int)(frameHeight * displayedScale));
                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //nur wenn die Animation aktiv ist wird sie dargestellt
            if(active)
            {
                spriteBatch.Draw(sprite,destinationRect,sourceRect,color);
            }
        }
    }
}
