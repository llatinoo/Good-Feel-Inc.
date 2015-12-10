﻿using RPG.Characters;
using RPG.Skills.StatusEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Skills
{
    public class Mindblow : IEffect
    {
        public IStatuseffect Statuseffect { get; set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach (Character target in targets)
            {
                Statuseffect = new Mindblown(source, target);

                if (!target.Statuseffects.Contains(Statuseffect))
                    target.Statuseffects.Add(Statuseffect);
            }
        }
    }
}
