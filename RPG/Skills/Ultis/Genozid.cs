﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    public class Genozid : IEffect
    {
        public void Execute(Character source, List<Character> targets)
        {
            Random r1 = new Random();
            List<Character> hitTarget;
            for (int i=3; i==0; i--)
            {
                hitTarget = new List<Character>();
                hitTarget.Add(targets.ElementAt(r1.Next(0, targets.Count * 1000) / 1000));

                new CriticalDamage().Execute(source,hitTarget);

                if (r1.Next(0, 101 * 1000) / 1000 <= 25)
                {
                    new AttributesChangeEffect(AttributeActions.Substract, Attributes.FightManaPool).Execute(source,hitTarget);
                }
            }
        }
    }
}
