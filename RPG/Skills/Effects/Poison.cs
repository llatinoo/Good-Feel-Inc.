using System.Collections.Generic;
using RPG.Characters;
using RPG.Skills.StatusEffects;

namespace RPG.Skills.Effects
{
    public class Poison : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            targets.AddStatuseffectToTargets(target => new Poisoned(source));
        }
    }
}
