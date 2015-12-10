using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class Mindblown : IStatuseffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public Mindblown(Character source, Character target)
        {
            Damage = 0;
          
            if (target.Level > source.Level)
                Duration = 1;
            else
                Duration = source.Level - target.Level;
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
