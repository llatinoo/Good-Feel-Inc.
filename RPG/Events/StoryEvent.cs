﻿using System.Configuration;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.Data_Section_Classes;
using RPG.Screen_Manager;

namespace RPG.Events
{
    class StoryEvent
    {
        //Position des Textes
        Vector2 textLine_1 = new Vector2(150, 422);
        Vector2 textLine_2 = new Vector2(150, 447);
        Vector2 textLine_3 = new Vector2(150, 472);
        Vector2 textLine_4 = new Vector2(150, 497);

        //Position der Namen
        Vector2 speakerNamePosition = new Vector2();
        Vector2 listenerNamePosition = new Vector2();

        //Position der Faces
        Vector2 speakerPicturePosition = new Vector2();
        Vector2 listenerPicturePosition = new Vector2();

        //Elemente die auf dem bildschirm angezeigt werden
        GUIElement speakerPicture;
        GUIElement listenerPicture;

        TextElement speaker;
        TextElement listener;
        TextElement row1;
        TextElement row2;
        TextElement row3;
        TextElement row4;

        public StoryEvent(int sceneNumber, int partNumber)
        {
            this.getScene(sceneNumber, partNumber);
        }

        void getScene(int sceneNumber, int partNumber)
        {
            var getStory =
                ConfigurationManager.GetSection("Story") as StoryDialogsDataSection;
            var getScene =
                getStory.Scenes.Cast<SceneElement>().SingleOrDefault(scene => scene.Id == ""+ sceneNumber);
            var getPart =
                getScene.Parts.Cast<PartElement>().SingleOrDefault(Part => Part.Id == "" + partNumber);

            foreach (TextBoxElement textBox in getPart.TextBoxes)
            {
                this.speakerPicture = new GUIElement(textBox.SpeakerPicture, (int) this.speakerPicturePosition.X, (int) this.speakerPicturePosition.Y);
                this.listenerPicture = new GUIElement (textBox.ListenerPicture, (int) this.listenerPicturePosition.X, (int) this.listenerPicturePosition.Y);
                this.speaker = new TextElement(textBox.Speaker, (int) this.listenerNamePosition.X, (int) this.listenerNamePosition.X);
                this.listener = new TextElement(textBox.Listener, (int) this.listenerNamePosition.X, (int) this.listenerNamePosition.X);
                this.row1 = new TextElement(textBox.Row1, (int) this.textLine_1.X, (int) this.textLine_1.Y);
                this.row2 = new TextElement(textBox.Row2, (int) this.textLine_2.X, (int) this.textLine_2.Y);
                this.row3 = new TextElement(textBox.Row3, (int) this.textLine_3.X, (int) this.textLine_3.Y);
                this.row4 = new TextElement(textBox.Row4, (int) this.textLine_4.X, (int) this.textLine_4.Y);
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.speakerPicture.LoadContent(content);
            this.listenerPicture.LoadContent(content);
            this.speaker.LoadContent(content);
            this.listener.LoadContent(content);
            this.row1.LoadContent(content);
            this.row2.LoadContent(content);
            this.row3.LoadContent(content);
            this.row4.LoadContent(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.speakerPicture.Draw(spriteBatch);
            this.listenerPicture.Draw(spriteBatch);
            this.speaker.Draw(spriteBatch);
            this.listener.Draw(spriteBatch);
            this.row1.Draw(spriteBatch);
            this.row2.Draw(spriteBatch);
            this.row3.Draw(spriteBatch);
            this.row4.Draw(spriteBatch);
        }


    }
}
