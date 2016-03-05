using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    //Klasse zur Unterscheidung von Verbündeten
    public class PartyMember : Character
    {
        //Erfahrung des Charakters
        public int Exp { get; set; }
        //Punkte an denen ein Charakter Aufsteigt
        public List<int> LevelList { get; private set; }


        //Ultimative Fähigkeit und Punkte die zum Aktivieren benötigt werden
        public int UltimatePoints { get; set; }
        public int UltimatePointsToCast { get; set; }


        public PartyMember(string charName, Classes className, List<int> levellist, int ultimatePointsToCast,string standardAnimationPath, string attackAnimationPath, string deathAnimationPath)
            : base(charName, className, standardAnimationPath, attackAnimationPath, deathAnimationPath)
        {
            this.Exp = 0;
            this.LevelList = levellist;

            this.UltimatePoints = 0;
            this.UltimatePointsToCast = ultimatePointsToCast;
        }


        //Erhalten von Exp und gegebenfalls LevelUp ausführen
        public void GainExp(int exp)
        {
            this.Exp += exp;
            this.LevelList.OrderBy(x => x);

            while (this.Exp >= this.LevelList.ElementAt(0))
            {
                this.LevelUp();
                this.LevelList.Remove(this.LevelList.ElementAt(0));
                this.LevelList.OrderBy(x => x);
            }
        }


        //Levelupaufruf
        public void LevelUp()
        {
            this.Level++;
            this.SetAttributes(AttributesChange.LevelUpAttributes(this.Class));
            LoadSkillHelperClass.AddLevelUpSkillToParty(this);
        }
    }
}
