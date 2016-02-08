using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Events
{
    class BattleEvent
    {
        //Alle Character im BattleEvent
        List<Character> FightClub = new List<Character>();

        //Benutzer Gruppe
        List<PartyMember> FightCadre = new List<PartyMember>();
        
        //Gegner Gruppe
        List<Enemy> Enemies = new List<Enemy>();
        
        //Character in Pixeln
        private int characterSize = 64;

        //Spieler Character Position
        private Vector2 characterPosition_1 = new Vector2(630, 415);
        private Vector2 characterPosition_2 = new Vector2(620, 350);
        private Vector2 characterPosition_3 = new Vector2(610, 285);
        private Vector2 characterPosition_4 = new Vector2(600, 220);

        //Position der Gegner
        Vector2 enemyPosition_1 = new Vector2(100, 415);
        Vector2 enemyPosition_2 = new Vector2(110, 350);
        Vector2 enemyPosition_3 = new Vector2(120, 285);
        Vector2 enemyPosition_4 = new Vector2(130, 220);
        Vector2 normalBossPosition;
        Vector2 finalBossPosition;

        //Skill Position
        private Vector2 skillPosition_1 = new Vector2();
        private Vector2 skillPosition_2 = new Vector2();
        private Vector2 skillPosition_3 = new Vector2();
        private Vector2 skillPosition_4 = new Vector2();
        private Vector2 ultiPosition = new Vector2();

        //Animation Speed
        private int animationSpeed = 300;

        //Member Skills
        private int member_1_Skills;
        private int member_2_Skills;
        private int member_3_Skills;
        private int member_4_Skills;


        public BattleEvent(List<PartyMember> FightCadre, List<Enemy> Enemies)
        {
            //Zuweisung der Listen
            this.FightCadre = FightCadre;
            this.Enemies = Enemies;

            //Skill Counter 
            member_1_Skills = FightCadre.ElementAt<PartyMember>(0).Skills.Count();
            member_2_Skills = FightCadre.ElementAt<PartyMember>(1).Skills.Count();
            member_3_Skills = FightCadre.ElementAt<PartyMember>(2).Skills.Count();
            member_4_Skills = FightCadre.ElementAt<PartyMember>(3).Skills.Count();

            //FightCader wird der Liste FightClub hinzugefügt
            foreach(Character character in FightCadre)
            {
                FightClub.Add(character);
            }

            //Enemies wird der Liste FightClub hinzugefügt
            foreach (Character character in Enemies)
            {
                FightClub.Add(character);
            }

            // FightClub Member werden nach dem Initiative wert sortiert
            FightClub.OrderBy(character => character.GetInitiative());

        }

        public void LoadContent(ContentManager content)
        {
            //Animation erstellt
            Animation charAnimation = new Animation();
            Animation enemyAnimation = new Animation();
            GUIElement enemy;
            int groupCount=0;
            int enemyCount = 0;

           foreach(Character chars in FightCadre)
            {
                //Anpassung benötigt da am Ende Festwerte eingetragen wurden
                if (groupCount == 0)
                {
                    charAnimation.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(0).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(0).LoadContent(charAnimation, characterPosition_1);
                }

                if (groupCount==1)
                {
                    charAnimation.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(1).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(1).LoadContent(charAnimation, characterPosition_2);
                }
                    
                if(groupCount==2)
                {
                    charAnimation.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(2).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(2).LoadContent(charAnimation, characterPosition_3);
                }

                if (groupCount==3)
                { 
                    charAnimation.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(3).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(3).LoadContent(charAnimation, characterPosition_4);
                }

                groupCount++;
            }


           foreach(Enemy chars in Enemies)
            {
                // Sobald der Gegner eine Animation bestizt wird dies erkannt und die Animationen werden geladen
                if (chars.isAnimated)
                {
                    if (enemyCount == 0)
                    {
                        charAnimation.LoadContent(content.Load<Texture2D>(Enemies.ElementAt<Enemy>(0).standardAnimationPath), Vector2.Zero, 400, 400, animationSpeed, Color.White, 1f, true, 1, 3, false);
                        Enemies.ElementAt<Enemy>(0).LoadContent(charAnimation, enemyPosition_1);
                    }

                    if (enemyCount == 1)
                    {
                        charAnimation.LoadContent(content.Load<Texture2D>(Enemies.ElementAt<Enemy>(1).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                        Enemies.ElementAt<Enemy>(1).LoadContent(charAnimation, characterPosition_2);
                    }

                    if (enemyCount == 2)
                    {
                        charAnimation.LoadContent(content.Load<Texture2D>(Enemies.ElementAt<Enemy>(2).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                        Enemies.ElementAt<Enemy>(2).LoadContent(charAnimation, characterPosition_3);
                    }

                    if (enemyCount == 3)
                    {
                        charAnimation.LoadContent(content.Load<Texture2D>(Enemies.ElementAt<Enemy>(3).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                        Enemies.ElementAt<Enemy>(3).LoadContent(charAnimation, characterPosition_4);
                    }

                    enemyCount++;
                }
                // Wenn der Gegner erstellt wird und es keine Animation für den Gegner gibt wird dem entsprechend nur ein Bild des gegeners geladen
                else
                {

                    if (enemyCount == 0)
                    {
                        enemy = new GUIElement(Enemies.ElementAt<Enemy>(0).standardAnimationPath,(int) enemyPosition_1.X, (int) enemyPosition_1.Y);
                    }

                    if (enemyCount == 1)
                    {
                        enemy = new GUIElement(Enemies.ElementAt<Enemy>(1).standardAnimationPath,(int) enemyPosition_2.X, (int) enemyPosition_2.Y);
                    }

                    if (enemyCount == 2)
                    {
                        enemy = new GUIElement(Enemies.ElementAt<Enemy>(2).standardAnimationPath,(int) enemyPosition_3.X, (int) enemyPosition_3.Y);
                    }

                    if (enemyCount == 3)
                    {
                        enemy = new GUIElement(Enemies.ElementAt<Enemy>(3).standardAnimationPath, (int) enemyPosition_4.X, (int) enemyPosition_4.Y);
                    }

                }

            }
           
        }

        public void Update(GameTime gameTime)
        {
            //Animationen der befreundeten Charakter werden geladen
            foreach (Character chars in FightCadre)
            {
                chars.Update(gameTime);
            }
            
            //Animationen der Gegner werden geladen
            foreach (Character chars in Enemies)
            {
                chars.Update(gameTime);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Zeichnet die Charaktere auf dem Bildschirm
            foreach(Character chars in FightCadre)
            {
                chars.Draw(spriteBatch);
            }

            // Zeichnet die Gegner auf dem Bildschirm
            foreach (Character chars in Enemies)
            {
                chars.Draw(spriteBatch);
            }
        }

    }
}
