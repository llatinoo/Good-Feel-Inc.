using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class Poisoned : IStatuseffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public Poisoned(Character source)
        {
            this.Damage = Convert.ToInt32((source.FightMagic / 5));
        }

        public int ExecuteStatus()
        {
            return Damage;
        }

        public bool IsDone()
        {
            return false;
        }
    }
}
