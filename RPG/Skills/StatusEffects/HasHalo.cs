using RPG.Characters;
using System;

namespace RPG.Skills.StatusEffects
{
    public class HasHalo : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public HasHalo(Character target)
        {
            Random r1 = new Random();
            
            this.Damage -= Convert.ToInt32(target.FightVitality * 0.1);
            this.Duration = Convert.ToInt32(r1.Next(1, 3 * 1000) / 1000);
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
