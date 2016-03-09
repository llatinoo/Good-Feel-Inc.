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
        List<PartyMember> group = new List<PartyMember>();

        public SaveEvent(List<PartyMember> partyMember,int sceneCount)
        {
            SaveContent(partyMember,sceneCount);
        }

        public void SaveContent(List<PartyMember> partyMember,int sceneCount)
        {
            //XML muss noch den ScenenCount speicher
                group = partyMember;
                var safeData = new FileStream("SafeData.xml", FileMode.Create);
                new XmlSerializer(typeof(PartyMember)).Serialize(safeData, group);
        }

    }
}
