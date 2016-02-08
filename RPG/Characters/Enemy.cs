﻿namespace RPG
{
    //Klasse zur Unterscheidung von Gegnern
    public class Enemy : Character
    {
        public bool isBoss;

        public Enemy(string charName, Classes className, bool isboss, string race, int vita, int mana, int strength,
            int mag, int def, int res, int luck, string standardAnimationPath, string attackAnimationPath, string deathAnimationPath)
            : base(charName, className, race, vita, mana, strength, mag, def, res, luck, standardAnimationPath, attackAnimationPath, deathAnimationPath)
        {
            this.isBoss = isboss;
        }
    }
}
