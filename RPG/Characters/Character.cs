using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using RPG.Skills;

namespace RPG
{
    public enum MainAttributes
    {
        Vitality,
        ManaPool,
        Strength,
        Magic,
        Defense,
        Resistance,
        Luck
    }
    public enum Classes
    {
        Warrior,
        DamageDealer,
        Coloss,
        Patron,
        Harasser
    }


    //Technische Daten eines Charakters
    public class Character
    {
        private int resistance;
        private int fightResistance;

        private int luck;
        private int fightLuck;

        private int life;
        private int fightVitality;

        private int mana;
        private int fightManaPool;

        private Animation animation;
        private Vector2 position;

        //Grafikdaten des Charakters
        public Animation Sprite { get; private set; }
        public String standardAnimationPath { get; private set; }
        public String deathAnimationPath {get; private set; }
        public String attackAnimationPath { get; private set; }

        //Name
        public string Name { get; private set; }

        //Klasse
        public Classes Class { get; private set; }
        public int Initiative { get; private set; }

        //Festwerte die durch aufleveln gesteigert werden
        public int Vitality { get; private set; }
        public int Manapool { get; private set; }
        public int Strength { get; private set; }
        public int Magic { get; private set; }
        public int Defense { get; private set; }
        public int Resistance
        {
            get { return this.resistance; }
            set { this.resistance = MathHelper.Clamp(this.resistance, 0, 21); }
        }
        public int Luck   
        {
            get { return this.luck; }
            set { this.luck = MathHelper.Clamp(this.luck, 0, 71); }
        }


        //Leben und ManaPool im Kampf
        public int Life
        {
            get { return this.life; }
            set { this.life = MathHelper.Clamp(value, 0, this.FightVitality); }
        }
        public int Mana
        {
            get { return this.mana; }
            set { this.mana = MathHelper.Clamp(value, 0, this.FightManaPool); }
        }


        //Kampfwerte die im Kampf verändert werden können
        //Vitalität und Manapool regulieren auch ManaPool und Leben, da diese Werte nicht über deren Kampfwerte liegen dürfen
        public int FightVitality
        {
            get { return this.fightVitality; }
            set
            {
                this.fightVitality = value;
                MathHelper.Clamp(this.life, 0, this.fightVitality);
            }
        }
        public int FightManaPool
        {
            get { return this.fightManaPool; }
            set
            {
                this.fightManaPool = value;
                MathHelper.Clamp(this.mana, 0, this.fightManaPool);
            }
        }
        public int FightStrength { get; set; }
        public int FightMagic { get; set; }
        public int FightDefense { get; set; }
        public int FightResistance
        {
            get { return this.fightResistance; }
            set { this.fightResistance = MathHelper.Clamp(value, 0, 20); }
        }
        public int FightLuck
        {
            get { return this.fightLuck; }
            set { this.fightLuck = MathHelper.Clamp(value, 0, 70); }
        }
        
        //Fähigkeiten Attribute
        public List<Skill> Skills { get; private set; }
        //public List<string> SkillTree { get; private set; }

        public int Level { get; set; }

        //Auf den Charakter wirkende Effekte
        public List<IStatuseffect> Statuseffects { get; set; }


        public Character(string charName, Classes className, string race, int vitality, int mana, int strength, int magic, int defense, int resistance, int luck, string standardAnimationPath,  string attackAnimationPath, string deathAnimationPath)
        {
            this.Name = charName;
            this.Class = className;

            this.FightVitality = this.Vitality = vitality;
            this.FightManaPool = this.Manapool = mana;
            this.FightStrength = this.Strength = strength;
            this.FightMagic = this.Magic = magic;
            this.FightDefense = this.Defense = defense;
            this.FightResistance = this.Resistance = resistance;
            this.FightLuck = this.Luck = luck;

            this.Skills = new List<Skill>();
            this.Statuseffects = new List<IStatuseffect>();

            this.Level = 0;
            this.standardAnimationPath = standardAnimationPath;
            this.deathAnimationPath = deathAnimationPath;
            this.attackAnimationPath = attackAnimationPath;
        }

        public void AddSkill(Skill newSkill)
        {
            this.Skills.Add(newSkill);
        }

        public void RemoveSkill(Skill removeSkill)
        {
            this.Skills.Remove(removeSkill);
        }

        public void UpdateStat(int updateAmmount, MainAttributes mainAttributeToUpdate)
        {
            var propertyInfo = typeof(Character).GetProperty(mainAttributeToUpdate.ToString());
            var oldValue = (int)propertyInfo.GetValue(this, null);
            propertyInfo.SetValue(this, oldValue + updateAmmount, null);
        }

        public void SetInitiative()
        {
            if (this.Class == Classes.Coloss)
            {
                this.Initiative = 1;
            }
            if (this.Class == Classes.Warrior)
            {
                this.Initiative = 2;
            }
            if (this.Class == Classes.Harasser)
            {
                this.Initiative = 3;
            }
            if (this.Class == Classes.Patron)
            {
                this.Initiative = 4;
            }
            if (this.Class == Classes.DamageDealer)
            {
                this.Initiative = 5;
            }
        }

        public int GetInitiative()
        {
            return this.Initiative + (new Random().Next(this.Initiative, (this.Initiative + 4) * 1000) / 1000);
        }

        public void LoadContent(Animation animation, Vector2 position)
        {
            this.animation = animation;
            this.position = position;
        }
        public void Update(GameTime gameTime)
        {
            animation.position = this.position;
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch);
        }

        public void LevelUpAttributes(List<int> stats)
        {
            this.Vitality += stats.ElementAt(0);
            this.Manapool += stats.ElementAt(1);
            this.Strength += stats.ElementAt(2);
            this.Magic += stats.ElementAt(3);
            this.Defense += stats.ElementAt(4);
            this.Resistance += stats.ElementAt(5);
            this.Luck += stats.ElementAt(6);
        }
    }
}
