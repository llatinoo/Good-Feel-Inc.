﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RPG.Characters
{
    //Klasse zur Unterscheidung von Verbündeten
    public class PartyMember : Character
    {
        public PartyMember(string charName, Classes className, string race, int vita, int mana, int strength, int mag, int def, int res, int luck, List<int> levellist)
            : base(charName, className, race, vita, mana, strength, mag, def, res, luck, levellist) { }
    }
}
