using System;
using Microsoft.Xna.Framework;

namespace RPG
{
    public class Poisoned : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Poisoned(Character source)
        {
            this.Duration = 0;
            this.Damage = Convert.ToInt32((source.FightMagic / 4) / (MathHelper.Clamp(source.FightResistance / 4, 1, 5)));
        }

        public int ExecuteStatus()
        {
            return this.Damage;
        }

        public bool IsDone()
        {
            return false;
        }
        public void UpdateDuration(int durationToAdd)
        {
            this.Duration += durationToAdd;
        }
    }
}
