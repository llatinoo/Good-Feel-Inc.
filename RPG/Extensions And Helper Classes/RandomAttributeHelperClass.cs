using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    public static class RandomAttributeHelperClass
    {
        //Gibt zufällig eines der Attribute die ein Charakter haben kann zurück
        public static Attributes GetRandomAttribute()
        {
            int random = new Random().Next(0, 7 * 1000) / 1000;

            List<Attributes> attributes = new List<Attributes> { Attributes.FightVitality, Attributes.FightManaPool, Attributes.FightStrength, Attributes.FightMagic, Attributes.FightDefense, Attributes.FightResistance, Attributes.FightLuck};

            return attributes.ElementAt(random);
        }
    }
}