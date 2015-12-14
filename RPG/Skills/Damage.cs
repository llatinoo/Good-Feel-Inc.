using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;

namespace RPG.Skills
{
    public class Damage : IEffect
    {
        private  readonly Random r1 = new Random();

        public void Execute(Character source, List<Character> targets)
        {
            foreach(Character target in targets)
            {
                target.FightVitality -= (source.FightStrength + (this.r1.Next(1, (source.FightStrength / 7) * 1000)) / 1000) - target.FightDefense;
            }
        }
    }
}
