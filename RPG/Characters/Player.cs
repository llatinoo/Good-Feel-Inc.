using RPG.Skills;
using System.Collections.Generic;

namespace RPG
{
    //Klasse für Spielerdaten
    public class Player : PartyMember
    {
        public string HiddenName { get; private set; }
        private string JosDemon = "Jos Dämon";
        private string JosAngel = "Jos Engel";


        //Erfahrung für Dämonen Skills und Engel Skills
        public int AngelExp { get; set; }
        public int DemonExp { get; set; }


        public Player(string charName, Classes className, int level, List<int> levellist, int ultimatePointsToCast, string standardAnimationPath,string attackanimationPath, string deathAnimationPath) 
            : base(charName, className, level, levellist, ultimatePointsToCast, standardAnimationPath, attackanimationPath, deathAnimationPath)
        {
            this.HiddenName = this.JosDemon;
            this.AngelExp = 0;
            this.DemonExp = 0;

            LoadSkillHelperClass.AddSkillsToParty(this);
        }

        public override void LevelUp()
        {
            this.Level++;
            if (this.DemonExp > this.AngelExp)
            {
                this.Class = Classes.Warrior;
                this.HiddenName = this.JosAngel;
            }
            else if(this.AngelExp > this.DemonExp)
            {
                this.Class = Classes.Patron;
                this.HiddenName = this.JosDemon;

            }
            this.ChangeAttributes(AttributesChange.LevelUpAttributes(this.Class));

        }


    }
}
