using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTest.Skills
{
    class HealEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                target.Vitality += Convert.ToInt32(source.fMagic * 0.2);
            }
        }
    }
}