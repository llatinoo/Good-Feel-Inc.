using System;
using System.Collections.Generic;
using System.Linq;
using RPG.Characters;
using RPG.Skills.StatusEffects;

namespace RPG.Extensions_And_Helper_Classes
{
    internal static class StatusEffectExecuteExtensions
    {
        //Fügt einen Status Effekt den Zielen zu
        public static void AddStatuseffectToTargets(this List<Character> targets, Func<Character, IStatuseffect> getStatuseffectFunc)
        {            
            foreach (Character target in targets)
            {
                var statuseffect = getStatuseffectFunc(target);

                if (target.Statuseffects.All(effect => effect.GetType() != statuseffect.GetType()))
                {
                    target.Statuseffects.Add(statuseffect);
                }
                //Falls das Ziel bereits von einem Statuseffekt dieser Art betroffen ist
                //wird die Dauer des breits existierenden Effekts erhöt
                else
                {
                    foreach (var effect in target.Statuseffects)
                    {
                        if (effect.GetType() == statuseffect.GetType())
                        {
                            effect.UpdateDuration(statuseffect.Duration);
                        }
                    }
                }
            }
        }
    }
}
