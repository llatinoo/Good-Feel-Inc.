using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RPG.Characters
{
    //Technische Daten eines Charakters
    public class Character
    {
        Characters.GraphicCharacter sprite;

        public string name { get; set; }

        //Festwerte die durch aufleveln gesteigert werden
        public int Vitality { get; set; }
        public int Strength { get; set; }
        public int Magic { get; set; }
        public int Defense { get; set; }
        public int Mana { get; set; }
        public int Luck { get; set; }

        //Kampfwerte die im Kampf verändert werden können
        public int FightVitality { get; set; }
        public int FightStrength { get; set; }
        public int FightMagic { get; set; }
        public int FightDefense { get; set; }
        public int FightMana { get; set; }
        public int FightLuck { get; set; }

        //Level Attribute
        public int Level { get; set; }
        public int Exp { get; set; }
        public List<int> Levelcap { get; set; }

        //Fähigkeiten Attribute
        public List<Skills.Skill> skills { get; set; }

        //Auf den Charakter wirkende Effekte
        public List<Skills.StatusEffects.IStatuseffect> Statuseffects { get; set; }

        //Ultimative Fähigkeit
        public int UltimatePoints { get; set; }
        public int UltimatePointsToCast { get; set; }


        public Character(string charName, Texture2D texture, Vector2 position, int vitality, int strength, int magic, int defense, int mana, int luck, List<int> levellist)
        {
            name = charName;
            //sprite.Initialize(texture, position);

            FightVitality = Vitality = vitality;
            FightStrength = Strength = strength;
            FightMagic = Magic = magic;
            FightDefense = Defense = defense;
            FightMana = Mana = mana;
            FightLuck = Luck = luck;

            Exp = 0;
            Levelcap = levellist;

            skills = new List<Skills.Skill>();
            Statuseffects = new List<Skills.StatusEffects.IStatuseffect>();
        }

        public void AddSkill(Skills.Skill newSkill)
        {
            this.skills.Add(newSkill);
        }

        public void RemoveSkill(Skills.Skill removeSkill)
        {
            this.skills.Remove(removeSkill);
        }
    }
}
