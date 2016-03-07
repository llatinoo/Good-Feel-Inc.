using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RPG
{
    public static class AttributesChange
    {
        //Gibt die Änderung der Festwerte der spezifischen Klasse bei Level Up zurück
        public static List<int> LevelUpAttributes(Classes charClass)
        {
            if (charClass.Equals(Classes.Warrior))
            {
                return new List<int>() { 200, 5, 80, 40, 30, 1, 3 };
            }

            if (charClass.Equals(Classes.DamageDealer))
            {
                return new List<int>() { 200, 0, 80, 80, 15, 1, 6 };
            }

            if (charClass.Equals(Classes.Coloss))
            {
                return new List<int>() { 400, 0, 40, 40, 30, 2, 3 };
            }

            if (charClass.Equals(Classes.Patron))
            {
                return new List<int>() { 400, 5, 40, 80, 15, 1, 3 };
            }

            if (charClass.Equals(Classes.Harasser))
            {
                return new List<int>() { 200, 5, 40, 80, 15, 2, 3 };
            }
            else
            {
                return new List<int>() { 0,0,0,0,0,0,0 };
            }
        }

        public static List<int> SetAttributes()
        {
            return new List<int>() { 500, 100, 80, 80, 30, 1, 3 };
        }
    }
}