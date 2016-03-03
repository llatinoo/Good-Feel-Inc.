using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Events
{
    class ConversationEvent
    {
        //Position des Textes
        Vector2 textLine_1 = new Vector2(150, 422);
        Vector2 textLine_2 = new Vector2(150, 447);
        Vector2 textLine_3 = new Vector2(150, 472);
        Vector2 textLine_4 = new Vector2(150, 497);

        //Vector2 textBoxPosition = new Microsoft.Xna.Framework.Vector2(50, 390);

        //Position der Namen
        Vector2 speakerNamePosition = new Vector2(70,215);
        Vector2 listenerNamePosition = new Vector2(545,215);

        //Position der Faces
        Vector2 speakerPicturePosition = new Vector2(50, 245);
        Vector2 listenerPicturePosition = new Vector2(525, 245);

        //Elemente die auf dem bildschirm angezeigt werden
        GUIElement speakerPicture;
        GUIElement listenerPicture;

        TextElement speaker;
        TextElement listener;
        TextElement row1;
        TextElement row2;
        TextElement row3;
        TextElement row4;

        GUIElement textBox;
        public ConversationEvent(int sceneNumber, int partNumber, int textBoxNumber)
        {
            this.getScene(sceneNumber, partNumber, textBoxNumber);
            textBox = new GUIElement("Boxes\\TextBox_Heroic");
        }

        void getScene(int sceneNumber, int partNumber, int textBoxNumber)
        {
            var getStory =
                ConfigurationManager.GetSection("Story") as StoryDialogsDataSection;
            var getScene =
                getStory.Scenes.Cast<SceneElement>().SingleOrDefault(scene => scene.Id == "" + sceneNumber);
            var getPart =
                getScene.Parts.Cast<PartElement>().SingleOrDefault(Part => Part.Id == "" + partNumber);
            var getTextBox =
                getPart.TextBoxes.Cast<TextBoxElement>().SingleOrDefault(TextBox => TextBox.Id == "" + textBoxNumber);

                if(getTextBox.SpeakerPicture.ToLower() != "Pfad".ToLower())
                {
                    this.speakerPicture = new GUIElement(getTextBox.SpeakerPicture, (int)this.speakerPicturePosition.X, (int)this.speakerPicturePosition.Y);
                }
                else
                {
                    this.speakerPicture = new GUIElement("Faces\\Jos\\Jos_NotAmused_Face", (int)this.speakerPicturePosition.X, (int)this.speakerPicturePosition.Y);
                }
                if (getTextBox.ListenerPicture.ToLower() != "Kein Pfad".ToLower())
                {
                    this.listenerPicture = new GUIElement(getTextBox.SpeakerPicture, (int)this.listenerPicturePosition.X, (int)this.listenerPicturePosition.Y);
                }
                else
                {
                    this.listenerPicture = new GUIElement("Faces\\Jos\\Jos_NotAmused_Face", (int)this.listenerPicturePosition.X, (int)this.listenerPicturePosition.Y);
                }
                this.speaker = new TextElement(getTextBox.Speaker, (int)this.speakerNamePosition.X, (int)this.speakerNamePosition.Y, false);
                this.listener = new TextElement(getTextBox.Listener, (int)this.listenerNamePosition.X, (int)this.listenerNamePosition.Y, false);
                this.row1 = new TextElement(getTextBox.Row1, (int)this.textLine_1.X, (int)this.textLine_1.Y, false);
                this.row2 = new TextElement(getTextBox.Row2, (int)this.textLine_2.X, (int)this.textLine_2.Y, false);
                this.row3 = new TextElement(getTextBox.Row3, (int)this.textLine_3.X, (int)this.textLine_3.Y, false);
                this.row4 = new TextElement(getTextBox.Row4, (int)this.textLine_4.X, (int)this.textLine_4.Y, false);
        }

        public void LoadContent(ContentManager content)
        {
            textBox.LoadContent(content);
            this.speakerPicture.LoadContent(content);
            this.listenerPicture.LoadContent(content);

            this.speaker.LoadContent(content);
            this.listener.LoadContent(content);
            this.row1.LoadContent(content);
            this.row2.LoadContent(content);
            this.row3.LoadContent(content);
            this.row4.LoadContent(content);

            textBox.CenterElement(576, 720);
            textBox.moveElement(0, 180);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            textBox.Draw(spriteBatch);
            if (speakerPicture != null)
            {
                this.speakerPicture.Draw(spriteBatch);
            }
            if (listenerPicture != null)
            {
                this.listenerPicture.Draw(spriteBatch);
            }
            this.speaker.Draw(spriteBatch);
            this.listener.Draw(spriteBatch);
            this.row1.Draw(spriteBatch);
            this.row2.Draw(spriteBatch);
            this.row3.Draw(spriteBatch);
            this.row4.Draw(spriteBatch);
        }

    }
}
