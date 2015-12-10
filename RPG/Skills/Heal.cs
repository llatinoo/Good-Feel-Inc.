﻿using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public class Heal : IEffect
    {
        public IStatuseffect Statuseffect { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                target.FightVitality += Convert.ToInt32(source.FightMagic * 0.25);
            }
        }
    }
}