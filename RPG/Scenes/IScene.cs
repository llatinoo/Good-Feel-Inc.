using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Scene
    {
        public List<PartyMember> Group { get; set; }
        public List<PartyMember> FightCadre { get; private set; }
        public List<Enemy> Enemies { get; private set; }

        public bool IsDone { get; private set; }

        public void Play(List<PartyMember> group)
        {
            this.IsDone = true;
        }
    }
}
