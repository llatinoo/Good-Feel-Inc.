using RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.StatusEffects
{
    public class Bleeding : IStatuseffect
    {
        public int Duration { get; set; }
        public int Damage { get; set; }

        public Bleeding(Character source)
        {
            Random r1 = new Random();

            Duration = Convert.ToInt32(r1.Next(3, 6 * 1000) / 1000);
            Damage = Convert.ToInt32((r1.Next(source.FightMagic / 7, (source.FightMagic / 5) * 1000)) / 1000);
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
