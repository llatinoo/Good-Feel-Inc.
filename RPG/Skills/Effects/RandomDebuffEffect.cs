using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    public class RandomDebuffEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomDebuffEffect().Execute(source, targets);
        }
    }
}
