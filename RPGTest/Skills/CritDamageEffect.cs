using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    class CritDamageEffect : IEffect
    {
        Random random;
        public void Execute(int skill, int strg, ref Result result)
        {
            result.damage -= Convert.ToInt32( (strg * 1.5 + (random.Next(1, (strg / 3) * 1000)) / 1000) );
        }
    }
}
