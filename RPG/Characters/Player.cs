using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Characters
{
    public class Player : PartyMember
    {
        public int AngelExp { get; set; }
        public int DemonExp { get; set; }

        private List<int> AngelLevelcap { get; set; }
        private List<int> DemonLevelcap { get; set; }

        private List<Skill> AngelSkills { get; set; }
        private List<Skill> DemonSkills { get; set; }

        public Player(string charName, Texture2D texture, Vector2 position, int vita, int strength, int mag, int def, int mana, int luck, List<int> levellist, List<Skill> angelSkills, List<Skill> demonSkills, List<int> angelLevelCap, List<int> demonLevelCap) 
            : base(charName, texture, position, vita, strength, mag, def, mana, luck, levellist)
        {
            this.AngelSkills = angelSkills;
            this.DemonSkills = demonSkills;

            this.AngelLevelcap = angelLevelCap;
            this.DemonLevelcap = demonLevelCap;

            this.AngelExp = 0;
            this.DemonExp = 0;
        }


    }
}
