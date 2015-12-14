using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;

namespace RPG.Skills
{
    public class Heal : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                target.FightVitality += Convert.ToInt32(source.FightMagic * 0.25);
            }
        }
    }
}