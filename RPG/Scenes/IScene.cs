using System.Collections.Generic;
using RPG.Characters;
using RPG.Events;

namespace RPG.Scenes
{
    public interface IScene
    {
        List<PartyMember> Group { get; }
        List<PartyMember> FightCadre { get; }
        List<Enemy> Enemies { get; }

        List<IEvent> Events { get; }

        List<PartyMember> ReturnGroup();
        bool IsDone();
    }
}
