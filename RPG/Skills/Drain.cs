using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public class Drain : IEffect
    {
        public IStatuseffect Statuseffect { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach(Character target in targets)
            {
                int damage = Convert.ToInt32(((source.FightStrength + source.FightMagic) / 2) / 3);
                target.FightVitality -= damage;
                source.FightVitality += Convert.ToInt32(damage / 2);
            }
        }
    }
}
