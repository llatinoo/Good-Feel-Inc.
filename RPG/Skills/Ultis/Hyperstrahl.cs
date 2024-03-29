﻿using System;
using System.Collections.Generic;

namespace RPG
{
    public class Hyperstrahl : IEffect
    {
        public int CausedDamege { get; private set; }

        public void Execute(Character source, List<Character> targets)
        {
            foreach (var target in targets)
            {
                this.CausedDamege = Convert.ToInt32(target.FightVitality*0.15);
                this.CausedDamege -= target.FightDefense;

                if (this.CausedDamege < 0)
                {
                    this.CausedDamege = 0;
                }

                target.Life -= this.CausedDamege;
            }
        }
    }
}
