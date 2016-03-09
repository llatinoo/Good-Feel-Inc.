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

        public SaveEvent(List<PartyMember> partyMember)
        {
            SaveContent(partyMember);
        }

        public void SaveContent(List<PartyMember> partyMember)
        {
                
                group = partyMember;
                var safeData = new FileStream("SafeData.xml", FileMode.Create);
                new XmlSerializer(typeof(Character)).Serialize(safeData, group);
        }

    }
}
