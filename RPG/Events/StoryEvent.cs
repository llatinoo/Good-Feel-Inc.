using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace RPG
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
            getScene(sceneNumber, partNumber);
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
                
                speakerPicture = new GUIElement(textBox.SpeakerPicture, (int)speakerPicturePosition.X, (int)speakerPicturePosition.Y);
                listenerPicture = new GUIElement (textBox.ListenerPicture, (int)listenerPicturePosition.X, (int)listenerPicturePosition.Y);
                speaker = new TextElement(textBox.Speaker, (int)listenerNamePosition.X, (int)listenerNamePosition.X);
                listener = new TextElement(textBox.Listener, (int)listenerNamePosition.X, (int)listenerNamePosition.X);
                row1 = new TextElement(textBox.Row1, (int)textLine_1.X, (int)textLine_1.Y);
                row2 = new TextElement(textBox.Row2, (int)textLine_2.X, (int)textLine_2.Y);
                row3 = new TextElement(textBox.Row3, (int)textLine_3.X, (int)textLine_3.Y);
                row4 = new TextElement(textBox.Row4, (int)textLine_4.X, (int)textLine_4.Y);
            }
        }

        public void LoadContent(ContentManager content)
        {
            speakerPicture.LoadContent(content);
            listenerPicture.LoadContent(content);
            speaker.LoadContent(content);
            listener.LoadContent(content);
            row1.LoadContent(content);
            row2.LoadContent(content);
            row3.LoadContent(content);
            row4.LoadContent(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            speakerPicture.Draw(spriteBatch);
            listenerPicture.Draw(spriteBatch);
            speaker.Draw(spriteBatch);
            listener.Draw(spriteBatch);
            row1.Draw(spriteBatch);
            row2.Draw(spriteBatch);
            row3.Draw(spriteBatch);
            row4.Draw(spriteBatch);
        }


    }
}
