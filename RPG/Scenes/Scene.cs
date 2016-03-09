using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Scene
    {
        public int ID { get; private set; }

        public List<PartyMember> Group { get; set; }
        public List<PartyMember> FightCadre { get; private set; }
        public List<Enemy> Enemies { get; private set; }

        public bool IsDone { get; private set; }

        public List<IEvent> Events { get; private set; }

        public Scene(int id, List<PartyMember> group, List<IEvent> events)
        {
            this.ID = id;
            this.Group = group;
            this.Events = events;
            this.IsDone = false;
        }

        public void Play(List<PartyMember> group)
        {

            this.IsDone = true;
        }
    }
}
