using System;
using System.Collections.Generic;
using System.Linq;
using RPG.Characters;
using RPG.Skills.StatusEffects;

namespace RPG.Skills.Effects
{
    public class RemoveStatusEffect : IEffect
    {
        //Entfernt einen Zufälligen Statuseffekt
        //Primär Poisoned
        //Sekundär den Statuseffekt mit der längsten Duration
        //Tärtziär einen zufälligen Statuseffekt
        public void Execute(Character source, List<Character> targets)
        {
            foreach (var target in targets)
            {
                if (target.Statuseffects.Count > 0)
                {
                    if (target.Statuseffects.All(effect => effect.GetType() == typeof (Poisoned)))
                    {
                        target.Statuseffects.RemoveAll(effect => effect.GetType() == typeof (Poisoned));
                    }
                    else
                    {
                        int random = new Random().Next(0, (target.Statuseffects.Count) * 1000) / 1000;
                        target.Statuseffects.Remove(target.Statuseffects.ElementAt(random));
                    }
                }
            }
            
        }
    }
}
