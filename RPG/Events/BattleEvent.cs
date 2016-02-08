using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Events
{
    class BattleEvent
    {

        List<PartyMember> FightCadre = new List<PartyMember>();
        List<Enemy> Enemies = new List<Enemy>();
        
        public BattleEvent(List<PartyMember> FightCadre, List<Enemy> Enemies)
        {
            this.FightCadre = FightCadre;
            this.Enemies = Enemies;

           // FightCadre.ElementAt<PartyMember>(0).LoadContent();

        }

        

    }
}
