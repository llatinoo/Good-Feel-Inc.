using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Characters;

namespace RPG
{
    public class Weapon
    {
        public string Name { get; private set; }

        public List<Classes> Classlimitation { get; private set; }

        public int Vitality { get; private set; }
        public int Mana { get; private set; }
        public int Strength { get; private set; }
        public int Magic { get; private set; }
        public int Defense { get; private set; }
        public int Resistance { get; private set; }
        public int Luck { get; private set; }

        public Weapon(string name, List<Classes> limitation, int vitality, int mana, int strength, int magic, int defense, int resistance, int luck)
        {
            this.Name = name;

            this.Classlimitation = limitation;

            this.Vitality = vitality;
            this.Mana = mana;
            this.Strength = strength;
            this.Magic = magic;
            this.Defense = defense;
            this.Resistance = resistance;
            this.Luck = luck;
        }
    }
}
