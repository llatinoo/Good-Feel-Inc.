using RPG.Characters;
using System;

namespace RPG.Skills.StatusEffects
{
    public class Bleeding : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Bleeding(Character source)
        {
            var r1 = new Random();

            this.Duration = Convert.ToInt32(r1.Next(3, 6 * 1000) / 1000);
            this.Damage = Convert.ToInt32((r1.Next(source.FightMagic / 7, (source.FightMagic / 5) * 1000)) / 1000);
        }

        public int ExecuteStatus()
        {
            this.Duration--;
            return this.Damage;
        }

        public bool IsDone()
        {
            if (this.Duration <= 0)
                return true;
            else
                return false;
        }        
    }
}
