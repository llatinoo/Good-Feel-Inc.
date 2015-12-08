using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class Burning : IStatuseffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public Burning(Character source)
        {
            Random r1 = new Random();
            
            this.Duration = Convert.ToInt32(r1.Next(1, 4 * 1000) / 1000);
            this.Damage = Convert.ToInt32((r1.Next(source.FightMagic / 5, (source.FightMagic / 3) * 1000)) / 1000);
        }

        public int ExecuteStatus(Character target)
        {
            Duration--;
            return Damage;
        }

        public bool IsDone ()
        {
            if (Duration <= 0)
                return true;
            else
                return false;
        }
    }
}
