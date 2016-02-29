namespace RPG.Characters
{
    //Klasse zur Unterscheidung von Gegnern
    public class Enemy : Character
    {
        //Abfrage ob der Gegner ein Boss ist
        public bool isBoss;
        //Abfrage ob der Gegner eine ANimation besitzt
        public bool isAnimated;

        public Enemy(string charName, Classes className, bool isboss, int vita, int mana, int strength,
            int mag, int def, int res, int luck, string standardAnimationPath, string attackAnimationPath, string deathAnimationPath, bool isAnimated)
            : base(charName, className, vita, mana, strength, mag, def, res, luck, standardAnimationPath, attackAnimationPath, deathAnimationPath)
        {
            this.isBoss = isboss;
            this.isAnimated = isAnimated;
        }

        //Ausführen der Gegner KI
        public void PerformAIActions()
        {
            
        }
    }
}
