using System.Collections.Generic;
using RPG.Characters;
using RPG.Extensions_And_Helper_Classes;

namespace RPG.Skills.Effects
{
    public class RandomDebuffEffect : IEffect
    {
        //Verursacht einen zufälligen negativen Statuseffekt
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomDebuffEffect().Execute(source, targets);
        }
    }
}
