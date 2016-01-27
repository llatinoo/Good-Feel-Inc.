using RPG.Characters;
using System;

namespace RPG.Skills.StatusEffects
{
    public class Poisoned : IStatuseffect
    {
        public int Duration { get; private set; }
        public int Damage { get; private set; }

        public Poisoned(Character source)
        {
            this.Damage = Convert.ToInt32((source.FightMagic / 4) / (source.FightResistance / 2));
            this.Damage = this.Damage / (source.FightResistance / 2);
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
