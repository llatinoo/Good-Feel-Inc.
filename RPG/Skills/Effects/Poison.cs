using System.Collections.Generic;

namespace RPG
{
    public class Poison : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            targets.AddStatuseffectToTargets(target => new Poisoned(source));
        }
    }
}
