using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;

namespace RPG.Skills
{
    public class RandomBuffEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomBuffEffect().Execute(source, targets);
        }
    }
}
