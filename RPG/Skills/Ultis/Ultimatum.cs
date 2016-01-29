using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;
using RPG.Skills.Effects;

namespace RPG.Skills.Ultis
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
