using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using RPG.Skills;
using RPG.Skills.StatusEffects;
using SchulProjekt.Animation;

namespace RPG.Characters
{
    public enum MainAttributes
    {
        Vitality,
        Mana,
        Strength,
        Magic,
        Defense,
        Resistance,
        Luck
    }
    public enum Classes
    {
        Warrior,
        Hunter,
        Colossus,
        Patron,
        Harasser
    }

    //Technische Daten eines Charakters
    public class Character
    {
        //Grafikdaten des Charakters
        public Animations Sprite { get; private set; }

        //Name
        public string Name { get; private set; }
        //Klasse
        public Classes Class { get; private set; }
        //Rasse
        public string Race { get; private set; }


        //Festwerte die durch aufleveln gesteigert werden
        public int Vitality { get; private set; }
        public int Mana { get; private set; }
        public int Strength { get; private set; }
        public int Magic { get; private set; }
        public int Defense { get; private set; }
        public int Resistance
        {
            get { return this.Resistance; }
            set { this.Resistance = MathHelper.Clamp(this.Resistance, 0, 20); }
        }
        public int Luck   
        {
            get { return this.Luck; }
            set { this.Luck = MathHelper.Clamp(this.Luck, 0, 70); }
        }

        //Kampfwerte die im Kampf verändert werden können
        public int FightVitality { get; set; }
        public int FightMana { get; set; }
        public int FightStrength { get; set; }
        public int FightMagic { get; set; }
        public int FightDefense { get; set; }
        public int FightResistance
        {
            get { return this.FightResistance; }
            set { this.FightResistance = MathHelper.Clamp(this.FightResistance, 0, 20); }
        }
        public int FightLuck
        {
            get { return this.FightLuck; }
            set { this.FightLuck = MathHelper.Clamp(this.FightLuck, 0, 70); }
        }

        //Ausrüstung
        public Weapon RightWeapon { get; set; }
        public Weapon LefWeapon { get; set; }

        //Level Attribute
        public int Level { get; set; }
        public int Exp { get; set; }
        public List<int> Levelcap { get; private set; }

        //Fähigkeiten Attribute
        public List<Skill> Skills { get; private set; }

        //Auf den Charakter wirkende Effekte
        public List<IStatuseffect> Statuseffects { get; set; }

        //Ultimative Fähigkeit
        public int UltimatePoints { get; set; }
        public int UltimatePointsToCast { get; set; }

        public Character(string charName, Classes className, string race, int vitality, int mana, int strength, int magic, int defense, int resistance, int luck, List<int> levellist)
        {
            this.Name = charName;
            this.Class = className;
            this.Race = race;

            this.FightVitality = this.Vitality = vitality;
            this.FightMana = this.Mana = mana;
            this.FightStrength = this.Strength = strength;
            this.FightMagic = this.Magic = magic;
            this.FightDefense = this.Defense = defense;
            this.FightResistance = this.Resistance = resistance;
            this.FightLuck = this.Luck = luck;

            this.Exp = 0;
            this.Levelcap = levellist;

            this.Skills = new List<Skill>();
            this.Statuseffects = new List<IStatuseffect>();
        }

        public void AddSkill(Skill newSkill)
        {
            this.Skills.Add(newSkill);
        }

        public void RemoveSkill(Skill removeSkill)
        {
            this.Skills.Remove(removeSkill);
        }

        public void InitzializeSprite(Texture2D texture, Vector2 position, int frameWidth, int frameHeight,
            int countSpritesheetFrames, int frameDisplayTime, Color color, float displayedScale, bool loop)
        {
            this.Sprite.Initialize(texture, position, frameWidth, frameHeight, countSpritesheetFrames, frameDisplayTime, color, displayedScale, loop);
        }

        public void UpdateStat(int updateAmmount, MainAttributes mainAttributeToUpdate)
        {
            var propertyInfo = typeof(Character).GetProperty(mainAttributeToUpdate.ToString());
            var oldValue = (int)propertyInfo.GetValue(this, null);
            propertyInfo.SetValue(this, oldValue + updateAmmount, null);
        }
    }
}
