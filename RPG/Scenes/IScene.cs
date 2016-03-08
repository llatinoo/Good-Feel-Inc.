using System.Collections.Generic;

namespace RPG.Scenes
{
    public abstract class IScene
    {
        public List<PartyMember> Group { get; set; }
        public List<PartyMember> FightCadre { get; protected set; }
        public List<Enemy> Enemies { get; protected set; }

        public bool IsDone { get; private set; }

        public void Play(List<PartyMember> group)
        {
            this.IsDone = true;
        }
    }
}
