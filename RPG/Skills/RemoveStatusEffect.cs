using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;

namespace RPG.Skills
{
    public class RemoveStatusEffect : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            foreach (var target in targets)
            {
                int random = new Random().Next(0, (target.Statuseffects.Count + 1) * 1000) / 1000;

                if (target.Statuseffects.Count != 0)
                {
                    target.Statuseffects.Remove(target.Statuseffects.ElementAt(random));
                }
            }
            
        }
    }
}
