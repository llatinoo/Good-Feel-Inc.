using System;
using RPG.Characters;
using RPG.Skills.StatusEffects;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    internal static class StatusEffectExecuteExtensions
    {
        public static void AddStatuseffectToTargets(this List<Character> targets, Func<Character, IStatuseffect> getStatuseffectFunc)
        {            
            foreach (Character target in targets)
            {
                var statuseffect = getStatuseffectFunc(target);

                if (target.Statuseffects.All(effect => effect.GetType() != statuseffect.GetType()))
                {
                    target.Statuseffects.Add(statuseffect);
                }
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
