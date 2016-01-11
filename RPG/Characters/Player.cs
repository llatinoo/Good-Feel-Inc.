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

        public Player(string charName, int vita, int mana, int strength, int mag, int def, int res, int luck, List<int> levellist, List<int> angelLevelCap, List<int> demonLevelCap) 
            : base(charName, vita, mana, strength, mag, def, res, luck, levellist)
        {
            this.AngelLevelcap = angelLevelCap;
            this.DemonLevelcap = demonLevelCap;

            this.AngelExp = 0;
            this.DemonExp = 0;
        }
    }
}
