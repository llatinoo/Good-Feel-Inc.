using System.Collections.Generic;

namespace RPG
{
    public class RandomEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomStatuseffect().Execute(source, targets);
        }
    }
}
