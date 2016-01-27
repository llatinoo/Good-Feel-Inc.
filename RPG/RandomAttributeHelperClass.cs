﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RPG.Skills;
using RPG.Skills.StatusEffects;

namespace RPG
{
    public static class RandomAttributeHelperClass
    {
        public static Attributes GetRandomAttribute()
        {
            int random = new Random().Next(0, 7 * 1000) / 1000;

            List<Attributes> attributes = new List<Attributes> { Attributes.FightVitality, Attributes.FightManaPool, Attributes.FightStrength, Attributes.FightMagic, Attributes.FightDefense, Attributes.FightResistance, Attributes.FightLuck};

            return attributes.ElementAt(random);
        }
    }
}