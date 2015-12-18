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
        Strength,
        Magic,
        Defense,
        Mana,
        Luck
    }

    //Technische Daten eines Charakters
    public class Character
    {
        //Grafikdaten des Charakters
        public Animations Sprite { get; set; }

        //Name
        public string Name { get; set; }

        //Festwerte die durch aufleveln gesteigert werden
        public int Vitality { get; private set; }
        public int Strength { get; private set; }
        public int Magic { get; private set; }
        public int Defense { get; private set; }
        public int Mana { get; private set; }
        public int Luck { get; private set; }

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
        public List<int> Levelcap { get; private set; }

        //Fähigkeiten Attribute
        public List<Skill> Skills { get; private set; }

        //Auf den Charakter wirkende Effekte
        public List<IStatuseffect> Statuseffects { get; set; }

        //Ultimative Fähigkeit
        public int UltimatePoints { get; set; }
        public int UltimatePointsToCast { get; set; }

        public Character(string charName, int vitality, int strength, int magic, int defense, int mana, int luck, List<int> levellist)
        {
            this.Name = charName;

            this.FightVitality = this.Vitality = vitality;
            this.FightStrength = this.Strength = strength;
            this.FightMagic = this.Magic = magic;
            this.FightDefense = this.Defense = defense;
            this.FightMana = this.Mana = mana;
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
