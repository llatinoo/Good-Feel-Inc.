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
            return group;
        }

        public void setGroup()
        {

        }

        public int getSceneCount()
        {
            return scenenCount;
        }

        public void setScene()
        {

        }

    }
}
