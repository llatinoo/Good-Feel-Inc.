using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;

namespace RPG.Skills
{
    public class RandomDebuffEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomDebuffEffect().Execute(source, targets);
        }
    }
}
