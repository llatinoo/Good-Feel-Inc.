using System;
using System.Collections.Generic;

namespace RPG
{
    public class Drain : IEffect
    {
        public int CausedDamage { get; private set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach(Character target in targets)
            {
                this.CausedDamage = Convert.ToInt32((source.FightStrength + source.FightMagic) / 3);
                target.Life -= this.CausedDamage;
                source.Life += Convert.ToInt32(this.CausedDamage / 2);
            }
        }
    }
}
