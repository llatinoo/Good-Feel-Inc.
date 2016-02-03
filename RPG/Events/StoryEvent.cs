using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace RPG
{
    class StoryEvent
    {
        String speaker;
        String speakerPicture;
        String listener;
        String listenerPicture;
        String row1;
        String row2;
        String row3;
        String row4;

        String getSpeaker()
        {
            return speaker;
        }
        String getSpeakerPicture()
        {
            return speakerPicture;
        }
        String getListener()
        {
            return listener;
        }
        String getListenerPicture()
        {
            return listenerPicture;
        }
        String getRow1()
        {
            return row1;
        }
        String getRow2()
        {
            return row2;
        }
        String getRow3()
        {
            return row3;
        }
        String getRow4()
        {
            return row4;
        }

        StoryEvent(int TobisMUM)
        {
            getScene(TobisMUM);

        }
        void getScene(int SceneNr)
        {
            var getStory =
                ConfigurationManager.GetSection("Story") as StoryDialogsDataSection;
            var getScene =
                getStory.Scenes.Cast<SceneElement>().SingleOrDefault(scene => scene.Id == ""+SceneNr);

            foreach (TextBoxElement textBox in getScene.TextBoxes)
            {
                speaker = textBox.Speaker;
                speakerPicture = textBox.SpeakerPicture;
                listener = textBox.Listener;
                listenerPicture = textBox.ListenerPicture;
                row1 = textBox.Row1;
                row2 = textBox.Row2;
                row3 = textBox.Row3;
                row4 = textBox.Row4;
            }
        }





    }
}
