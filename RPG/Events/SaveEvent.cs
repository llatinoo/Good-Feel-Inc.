﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG.Events
{
    class SaveEvent
    {
        List<PartyMember> group = new List<PartyMember>();
        int sceneCount;

        public SaveEvent(SafeGameState gameState)
        {
            SaveContent(gameState);
        }

        public void SaveContent(SafeGameState gameState)
        {
            //XML muss noch den ScenenCount speicher
            XmlSerializer xmlSerializerGroup = new XmlSerializer(typeof(SafeGameState));
            StreamWriter sw = new StreamWriter(@"SaveGame/SafeData.xml");
            xmlSerializerGroup.Serialize(sw,gameState);
            sw.Close();
        }

    }
}
