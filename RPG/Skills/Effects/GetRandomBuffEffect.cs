using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    public class RandomBuffEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomBuffEffect().Execute(source, targets);
        }
    }
}
