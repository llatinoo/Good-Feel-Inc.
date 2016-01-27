using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Skills.Effects
{
    public class RandomEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomStatuseffect().Execute(source, targets);
        }
    }
}
