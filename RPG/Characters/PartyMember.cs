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
            int def, int res, int luck, List<int> levellist, int ultimatePointsToCast,string standardAnimationPath, string attackAnimationPath, string deathAnimationPath)
            : base(charName, className, race, vita, mana, strength, mag, def, res, luck, standardAnimationPath, attackAnimationPath, deathAnimationPath)
        {
            this.Exp = 0;
            this.LevelList = levellist;

            this.UltimatePoints = 0;
            this.UltimatePointsToCast = ultimatePointsToCast;
        }

        public void CheckLevel()
        {
            this.LevelList.OrderBy(x => x);
            if (this.Exp >= this.LevelList.ElementAt(0))
            {
                this.LevelUp();
                LevelList.Remove(this.LevelList.ElementAt(0));
            }
        }

        public void LevelUp()
        {
            this.Level++;
            this.LevelUpAttributes(LevelUpClass.LevelUpAttributes(this.Class));
            LoadSkillHelperClass.AddCertainSkillToParty(this);
        }
    }
}
