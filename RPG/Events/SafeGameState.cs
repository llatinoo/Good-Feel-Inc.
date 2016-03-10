using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Events
{
    class SafeGameState
    {
        int scenenCount;
        List<PartyMember> group = new List<PartyMember>();

        public SafeGameState(List<PartyMember> partyMember, int sCount)
        {
            group = partyMember;
            scenenCount = sCount;
        }

        public List<PartyMember> getGroup()
        {
            return Group;
        }

        public int getSceneCount()
        {
            return scenenCount;
        } 


    }
}
