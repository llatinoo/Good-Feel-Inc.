using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RPG.Characters
{
    //Klasse zur Unterscheidung von Gegnern
    public class Enemy : Character
    {
        public Enemy(string charName, int vita, int strength, int mag, int def, int mana, int luck, List<int> levellist) 
            : base(charName, vita, strength, mag, def, mana, luck, levellist) { }
    }
}
