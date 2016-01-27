using RPG.Characters;
using System;
using Microsoft.Xna.Framework;

namespace RPG.Skills.StatusEffects
{
    public class Burning : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Burning(Character source)
        {
            Random r1 = new Random();
            
            this.Duration = Convert.ToInt32(r1.Next(1, 4 * 1000) / 1000);
            this.Damage = Convert.ToInt32((((r1.Next(source.FightMagic / 4, (source.FightMagic / 2) * 1000)) / 1000)));
            this.Damage = this.Damage / (MathHelper.Clamp(source.FightResistance / 2, 1, 20));
        }

        public int ExecuteStatus()
        {
            this.Duration--;
            return this.Damage;
        }

        public bool IsDone ()
        {
            if (this.Duration <= 0)
                return true;
            else
                return false;
        }
        public void UpdateDuration(int durationToAdd)
        {
            this.Duration += durationToAdd;
        }
    }
}
