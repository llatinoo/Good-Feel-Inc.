using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    class HealEffect : IEffect
    {
        Random random;

        public void Execute(int skill, int strg, ref Result result)
        {
            result.damage += Convert.ToInt32( ((skill / 100) * 20));
        }
    }
}