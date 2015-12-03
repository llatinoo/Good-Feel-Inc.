using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RPGTest
{
    public class Character
    {
        Characters.GraphicCharacter sprite;

        public string name;

        public int Vitality;
        public int Strength;
        public int Magic;
        public int Defense;
        public int Mana;
        public int Luck;

        public int fVitality;
        public int fStrength;
        public int fMagic;
        public int fDefense;
        public int fMana;
        public int fLuck;

        public int level;
        public int exp;
        public List<int> levelcap;

        public List<Skills.Skill> skills;
        public List<Skills.IStatuseffect> statuseffects;
        public int ultimatePoints;
        public int ultimatePointsToCast;
        private int v;

        //Contains Mindblown
        //var skill = skillFromList as MindBlown
        //    if (skill != null)


        public Character(Texture2D texture, Vector2 position, int vita, int strength, int mag, int def, int mana, int luck, List<int> levellist)
        {
            sprite.Initialize(texture, position);

            fVitality = Vitality = vita;
            fStrength = Strength = strength;
            fMagic = Magic = mag;
            fDefense = Defense = def;
            fMana = Mana = mana;
            fLuck = Luck = luck;

            exp = 0;
            levelcap = levellist;

            skills = new List<Skills.Skill>();
        }

        public Character(int v)
        {
            this.v = v;
        }

        public void AddSkill(Skills.Skill newSkill)
        {
            this.skills.Add(newSkill);
        }
    }
}
