using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills.Effects
{
    public class MagicalDamage : IEffect
    {
        private readonly Random r1 = new Random();
        private readonly Random CritChance = new Random();

        public int CausedDamage { get; private set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                this.CausedDamage = Convert.ToInt32(source.FightMagic + (this.r1.Next(1, (source.FightMagic / 7) * 1000)) / 1000);

                if (this.CritChance.Next(0, 91) <= source.FightLuck)
                {
                    this.CausedDamage = Convert.ToInt32(this.CausedDamage * 1.5);
                }

                this.CausedDamage -= target.FightDefense;

                if (this.CausedDamage <= 0)
                {
                    target.FightDefense -= source.FightStrength / 5;
                }

                target.Life -= this.CausedDamage;
            }
        }
    }
}
