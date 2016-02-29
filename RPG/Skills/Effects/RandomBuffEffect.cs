using System.Collections.Generic;

namespace RPG
{
    public class RandomBuffEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomBuffEffect().Execute(source, targets);
        }
    }
}
