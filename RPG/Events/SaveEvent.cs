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
        List<Character> group = new List<Character>();

        public SaveEvent(List<Character> partyMember)
        {
            SaveContent(partyMember);
        }

        public void SaveContent(List<Character> partyMember)
        {
                
                group = partyMember;
                var safeData = new FileStream("SafeData.xml", FileMode.Create);
                new XmlSerializer(typeof(Character)).Serialize(safeData, group);
        }

    }
}
