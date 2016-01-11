using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SchulProjekt.Animation
{
    public class Animations
    {
        //Textur der Animation
        Texture2D sprite;

        //Anzeigegröße des sprites
        float displayedScale;

        //Zeit des letzten Updates
        int elapsedTime;

        //Zeit die ein Frame angezeigt bis zum nächsten
        int frameDisplayTime;

        //Die Anzahl an frames des spritesheets
        int countSpritesheetFrames;

        //Index des aktuell angezeigten Frames
        int currentFrame;

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

        public void Initialize(Texture2D sprite, Vector2 position, int frameWidth, int frameHeight, 
            int countSpritesheetFrames, int frameDisplayTime, Color color, float displayedScale, bool loop)
        {
            this.sprite = sprite;
            this.position = position;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.countSpritesheetFrames = countSpritesheetFrames;
            this.frameDisplayTime = frameDisplayTime;
            this.color = color;
            this.displayedScale = displayedScale;
            this.loop = loop;

            //Zeit wird auf 0 gesetzt
            this.elapsedTime = 0;
            this.currentFrame = 0;

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
                this.currentFrame++;

                if(this.currentFrame == this.countSpritesheetFrames)
                {
                    this.currentFrame = 0;

                    //Wenn die Animation nicht wiederholt werden soll wird sie deaktiviert
                    if(!this.loop)
                    {
                        this.active = false;
                    }
                }

                //vergangene Zeit wird zurückgesetzt
                this.elapsedTime = 0;
            }

            //Der korrekte Frame wird gewählt
            this.sourceRect = new Rectangle(this.frameWidth *this.currentFrame, 0, this.frameWidth, this.frameHeight);

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
