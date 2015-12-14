﻿using RPG.Characters;
using System;
using System.Collections.Generic;

namespace RPG.Skills
{
    public class CriticalDamage : IEffect
    {
        private readonly Random r1 = new Random();

        public void Execute(Character source, List<Character> targets)
        {
            foreach (var target in targets)
            {
                target.FightVitality -= Convert.ToInt32((source.FightStrength * 1.5 + (this.r1.Next(1, (source.FightStrength / 7) * 1000)) / 1000));
            }
        }
    }
}
