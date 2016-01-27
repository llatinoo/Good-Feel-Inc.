using System;
using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    public class CriticalDamage : IEffect
    {
        private readonly Random r1 = new Random();

        public int CausedDamage { get; private set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach (var target in targets)
            {
                this.CausedDamage = Convert.ToInt32((source.FightStrength + (this.r1.Next(1, (source.FightStrength / 7) * 1000)) / 1000));

                this.CausedDamage = Convert.ToInt32(this.CausedDamage * 1.5);
                this.CausedDamage -= target.FightDefense;

                if (this.CausedDamage < 0)
                {
                    this.CausedDamage = 0;
                }

                target.Life -= this.CausedDamage;
            }
        }
    }
}
