using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RPG.Characters
{
    //Klasse zur Unterscheidung von Verbündeten
    public class PartyMember : Character
    {
        //Level Attribute
        public int Level { get; set; }
        public int Exp { get; set; }
        public List<int> Levelcap { get; private set; }


        //Ultimative Fähigkeit
        public int UltimatePoints { get; set; }
        public int UltimatePointsToCast { get; set; }


        public PartyMember(string charName, Classes className, string race, int vita, int mana, int strength, int mag,
            int def, int res, int luck, List<int> levellist, int ultimatePointsToCast)
            : base(charName, className, race, vita, mana, strength, mag, def, res, luck)
        {
            this.Exp = 0;
            this.Levelcap = levellist;

            this.UltimatePoints = 0;
            this.UltimatePointsToCast = ultimatePointsToCast;
        }
    }
}
