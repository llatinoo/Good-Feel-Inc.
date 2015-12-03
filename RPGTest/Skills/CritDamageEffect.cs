using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    class CriticalDamageEffect : IEffect
    {
        Random random;
        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                target.Vitality -= Convert.ToInt32((source.fStrength * 1.5 + (random.Next(1, (source.fStrength / 3) * 1000)) / 1000)) - target.Defense;
            }
        }
    }
}
