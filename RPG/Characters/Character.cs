using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using RPG.Skills;
using RPG.Skills.StatusEffects;

namespace RPG.Characters
{
    //Technische Daten eines Charakters
    public class Character
    {
        //Grafikdaten des Charakters
        public GraphicCharacter Sprite { get; set; }

        //Name
        public string Name { get; set; }

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
        public List<int> Levelcap { get; private set; }

        //Fähigkeiten Attribute
        public List<Skill> Skills { get; private set; }

        //Auf den Charakter wirkende Effekte
        public List<IStatuseffect> Statuseffects { get; set; }

        //Ultimative Fähigkeit
        public int UltimatePoints { get; set; }
        public int UltimatePointsToCast { get; set; }

        public Character(string charName, Texture2D texture, Vector2 position, int vitality, int strength, int magic, int defense, int mana, int luck, List<int> levellist)
        {
            this.Name = charName;

            this.Sprite.Initialize(texture, position);

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
    }
}
