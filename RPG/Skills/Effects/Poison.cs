using System.Collections.Generic;
using RPG.Characters;
using RPG.Extensions_And_Helper_Classes;
using RPG.Skills.StatusEffects;

namespace RPG.Skills.Effects
{
    public class Poison : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            //Verursacht den Statuseffekt Poisoned
            //In Extension.cs
            targets.AddStatuseffectToTargets(target => new Poisoned(source));
        }
    }
}
