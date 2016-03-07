using System;
using System.Collections.Generic;

namespace RPG
{
    public class Ultimatum : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            foreach (var target in targets)
            {
                target.FightVitality = Convert.ToInt32(target.FightVitality*0.75);
            }
        }
    }
}
