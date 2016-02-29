using System.Collections.Generic;
using RPG.Characters;
using RPG.Extensions_And_Helper_Classes;
using RPG.Skills.StatusEffects;

namespace RPG.Skills.Effects
{
    public class Bless : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            //Verursacht den Statuseffekt Blessing
            //In Extension.cs
            targets.AddStatuseffectToTargets(target => new Blessing());
        }
    }
}
