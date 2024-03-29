﻿using RPG.Skills;
using System.Collections.Generic;

namespace RPG
{
    //Klasse für Spielerdaten
    public class Player : PartyMember
    {
        //Erfahrung für Dämonen Skills und Engel Skills
        public int AngelExp { get; set; }
        public int DemonExp { get; set; }

        public List<int> AngelLevelcap { get; private set; }
        public List<int> DemonLevelcap { get; private set; }

        public List<Skill> AngelSkills { get; private set; }
        public List<Skill> DemonSkills { get; private set; }

        public Player(string charName, Classes className, int level, List<int> levellist, int ultimatePointsToCast, List<int> angelLevelCap, List<int> demonLevelCap,string standardAnimationPath,string attackanimationPath, string deathAnimationPath) 
            : base(charName, className, level, levellist, ultimatePointsToCast, standardAnimationPath, attackanimationPath, deathAnimationPath)
        {
            this.AngelLevelcap = angelLevelCap;
            this.DemonLevelcap = demonLevelCap;

            this.AngelExp = 0;
            this.DemonExp = 0;
        }
    }
}
