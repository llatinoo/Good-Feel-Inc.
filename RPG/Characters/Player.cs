using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG.Skills;
using System.Collections.Generic;

namespace RPG.Characters
{
    //Klasse für Spielerdaten
    public class Player : PartyMember
    {
        public int AngelExp { get; set; }
        public int DemonExp { get; set; }

        public List<int> AngelLevelcap { get; private set; }
        public List<int> DemonLevelcap { get; private set; }

        public List<Skill> AngelSkills { get; private set; }
        public List<Skill> DemonSkills { get; private set; }

        public Player(string charName, Texture2D texture, Vector2 position, int vita, int strength, int mag, int def, int mana, int luck, List<int> levellist, List<int> angelLevelCap, List<int> demonLevelCap) 
            : base(charName, texture, position, vita, strength, mag, def, mana, luck, levellist)
        {
            this.AngelLevelcap = angelLevelCap;
            this.DemonLevelcap = demonLevelCap;

            this.AngelExp = 0;
            this.DemonExp = 0;
        }
    }
}
