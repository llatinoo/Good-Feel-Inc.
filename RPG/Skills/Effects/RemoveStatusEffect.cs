using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    public class RemoveStatusEffect : IEffect
    {
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
