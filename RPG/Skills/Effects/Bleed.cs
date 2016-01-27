using System.Collections.Generic;
using RPG.Characters;
using RPG.Skills.StatusEffects;

namespace RPG.Skills.Effects
{
    public class Bleed : IEffect
    { 
        public void Execute (Character source, List<Character> targets)
        { 
            //In Extension.cs
            targets.AddStatuseffectToTargets(target => new Bleeding(source));
        }
    }
}
