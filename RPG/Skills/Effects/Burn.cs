using System.Collections.Generic;

namespace RPG
{
    public class Burn : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            //In Extension.cs
            targets.AddStatuseffectToTargets(target => new Burning(source));
        }
    }
}
