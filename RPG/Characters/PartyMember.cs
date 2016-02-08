using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    //Klasse zur Unterscheidung von Verbündeten
    public class PartyMember : Character
    {
        //Level Attribute
        public int Exp { get; set; }
        public List<int> LevelList { get; private set; }


        //Ultimative Fähigkeit
        public int UltimatePoints { get; set; }
        public int UltimatePointsToCast { get; set; }


        public PartyMember(string charName, Classes className, string race, int vita, int mana, int strength, int mag,
            int def, int res, int luck, List<int> levellist, int ultimatePointsToCast)
            : base(charName, className, race, vita, mana, strength, mag, def, res, luck)
        {
            this.Exp = 0;
            this.LevelList = levellist;

            this.UltimatePoints = 0;
            this.UltimatePointsToCast = ultimatePointsToCast;
        }

        public void CheckLevel()
        {
            this.LevelList.OrderBy(x => x.ToString());
            if (this.Exp >= this.LevelList.ElementAt(0))
            {
                this.LevelUp();
                LevelList.Remove(this.LevelList.ElementAt(0));
            }
        }

        public void LevelUp()
        {
            this.Level++;

            LoadSkillHelperClass.AddCertainSkillToParty(this);
        }
    }
}
