using System.Collections.Generic;
using RPG.Characters;
using RPG.Extensions_And_Helper_Classes;

namespace RPG.Skills.Effects
{
    public class RandomEffect : IEffect
    {
        //Verursacht einen zufälligen Statuseffekt
        public void Execute(Character source, List<Character> targets)
        {
            RandomStatusEffectHelperClass.GetRandomStatuseffect().Execute(source, targets);
        }
    }
}
