namespace RPG
{
    //Klasse zur Unterscheidung von Gegnern
    public class Enemy : Character
    {
        public bool isBoss;

        public Enemy(string charName, Classes className, bool isboss, string race, int vita, int mana, int strength,
            int mag, int def, int res, int luck, string texturePath)
            : base(charName, className, race, vita, mana, strength, mag, def, res, luck,texturePath)
        {
            this.isBoss = isboss;
        }
    }
}
