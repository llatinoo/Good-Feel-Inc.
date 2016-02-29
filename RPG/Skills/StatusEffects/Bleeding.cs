using System;
using Microsoft.Xna.Framework;

namespace RPG
{
    public class Bleeding : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Bleeding(Character source)
        {
            var r1 = new Random();

            this.Duration = Convert.ToInt32(r1.Next(3, 6 * 1000) / 1000);
            this.Damage = Convert.ToInt32(((r1.Next(source.FightMagic / 6, (source.FightMagic / 4) * 1000)) / 1000));
            this.Damage = this.Damage / (MathHelper.Clamp(source.FightResistance/4, 1, 5));
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

        public void UpdateDuration(int durationToAdd)
        {
            this.Duration += durationToAdd;
        }     
    }
}