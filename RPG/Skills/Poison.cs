using RPG.Characters;
using RPG.Skills.StatusEffects;
using System.Collections.Generic;

namespace RPG.Skills
{
    public class Poison : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            targets.AddStatuseffectToTargets(target => new Poisoned(source));
        }
    }
}
