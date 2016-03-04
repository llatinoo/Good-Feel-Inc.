using System;
using System.Collections.Generic;

namespace RPG
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

                //Automatischer Kritischer-Treffer
                this.CausedDamage = Convert.ToInt32(this.CausedDamage * 1.5);
                this.CausedDamage -= target.FightDefense;

                if (this.CausedDamage < source.FightStrength / 6)
                {
                    this.CausedDamage = source.FightStrength / 6;
                }

                target.Life -= this.CausedDamage;
            }
        }
    }
}
