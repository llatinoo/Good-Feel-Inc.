using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;

namespace RPG.Skills
{
    public class Drain : IEffect
    {
        public int CausedDamage { get; private set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach(Character target in targets)
            {
                this.CausedDamage = Convert.ToInt32(((source.FightStrength + source.FightMagic) / 2) / 3);
                target.FightVitality -= this.CausedDamage;
                source.FightVitality += Convert.ToInt32(this.CausedDamage / 2);
            }
        }
    }
}
