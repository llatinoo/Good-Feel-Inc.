using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG.Events
{
    class SaveEvent
    {

        public SaveEvent(GameState gameState)
        {
            SaveContent(gameState);
        }

        public void SaveContent(GameState gameState)
        {
            if (gameState != null)
            {
                //XML speichert nun ein Objekt von GameState welches sowhol die aktuelle Gruppe als auch die aktuelle Scene speichert
                XmlSerializer xmlSerializerGroup = new XmlSerializer(typeof(GameState));
                StreamWriter sw = new StreamWriter(@"SaveGame/SafeData.xml");
                xmlSerializerGroup.Serialize(sw,gameState);
                sw.Close();
            }
            else
            {
                //Öffne ein Menü zum verarbeiten es Fehlers oder sperre den Knopf
            }
        }

    }
}
