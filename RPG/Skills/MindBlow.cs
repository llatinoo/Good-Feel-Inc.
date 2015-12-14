using RPG.Characters;
using RPG.Skills.StatusEffects;
using System.Collections.Generic;

namespace RPG.Skills
{
    public class Mindblow : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            //In Extension.cs
            targets.AddStatuseffectToTargets(target => new Mindblown(source, target));
        }
    }
}
