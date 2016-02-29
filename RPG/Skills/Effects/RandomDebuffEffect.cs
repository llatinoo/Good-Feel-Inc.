using System.Collections.Generic;

namespace RPG
{
    public class RandomDebuffEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomDebuffEffect().Execute(source, targets);
        }
    }
}
