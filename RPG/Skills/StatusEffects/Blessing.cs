using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class Blessing : IStatuseffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public Blessing()
        {
            Duration = 1;
            Damage = 0;
        }

        public int ExecuteStatus()
        {
            Duration--;
            return Damage;
        }

        public bool IsDone()
        {
            if (Duration <= 0)
                return true;
            else
                return false;
        }
    }
}
