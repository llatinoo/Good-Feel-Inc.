using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class HasHalo : IStatuseffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public HasHalo(Character target)
        {
            Random r1 = new Random();
            
            this.Damage -= Convert.ToInt32(target.FightVitality * 0.1);
            this.Duration = Convert.ToInt32(r1.Next(1, 3 * 1000) / 1000);
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
