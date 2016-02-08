using RPG.Skills;
using System.Collections.Generic;

namespace RPG
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

        public Player(string charName, Classes className, string race, int vita, int mana, int strength, int mag,
            int def, int res, int luck, List<int> levellist, int ultimatePointsToCast, List<int> angelLevelCap, List<int> demonLevelCap,string texturePath) 
            : base(charName, className, race, vita, mana, strength, mag, def, res, luck, levellist, ultimatePointsToCast, texturePath)
        {
            this.AngelLevelcap = angelLevelCap;
            this.DemonLevelcap = demonLevelCap;

            this.AngelExp = 0;
            this.DemonExp = 0;
        }
    }
}
