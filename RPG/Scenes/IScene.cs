using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public interface IScene
    {
        List<PartyMember> Group { get; }
        List<PartyMember> FightCadre { get; }
        List<Enemy> Enemys { get; }

        List<IEvent> Events { get; }

        List<PartyMember> ReturnGroup();
        bool IsDone();
    }
}
