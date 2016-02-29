using System.Collections.Generic;
using RPG.Characters;
using RPG.Extensions_And_Helper_Classes;

namespace RPG.Skills.Effects
{
    public class RandomBuffEffect : IEffect
    {
        //Verursacht einen zufälligen positiven Statuseffekt
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomBuffEffect().Execute(source, targets);
        }
    }
}
