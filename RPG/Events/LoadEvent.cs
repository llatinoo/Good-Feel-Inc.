using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RPG.Events
{
    class LoadEvent
    {
        private SafeGameState saveGame;

        public LoadEvent()
        {
            LoadContent();
        }

        protected void LoadContent()
        {
            using (var reader = new StreamReader(@"SaveGame/SafeData.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(SafeGameState));
                saveGame = (SafeGameState)deserializer.Deserialize(reader);
            }
        }

        public SafeGameState getSaveGame()
        {
            return saveGame;
        }

    }
}
