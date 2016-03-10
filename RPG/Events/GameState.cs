using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Events
{
    public class GameState
    {
        int scenenCount;
        List<PartyMember> group = new List<PartyMember>();

        public GameState(List<PartyMember> partyMember, int sCount)
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
