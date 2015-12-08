using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public class CriticalDamageEffect : IEffect
    {
        Random r1 = new Random();

        public IStatuseffect Statuseffect { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                target.FightVitality -= Convert.ToInt32((source.FightStrength * 1.5 + (r1.Next(1, (source.FightStrength / 7) * 1000)) / 1000));
            }
        }
    }
}
