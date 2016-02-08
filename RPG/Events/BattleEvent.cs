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
            int i=0;

           foreach(Character chars in FightCadre)
            {
                //Anpassung benötigt da am Ende Festwerte eingetragen wurden

                if (i == 0)
                {
                    charAnimation.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(0).texturePath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(0).LoadContent(charAnimation, characterPosition_1);
                }

                if (i==1)
                {
                    charAnimation.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(0).texturePath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(0).LoadContent(charAnimation, characterPosition_2);
                }
                    
                if(i==2)
                {
                    charAnimation.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(0).texturePath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(0).LoadContent(charAnimation, characterPosition_3);
                }

                if (i==3)
                { 
                    charAnimation.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(0).texturePath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(0).LoadContent(charAnimation, characterPosition_4);
                }

                i++;
            }
           
        }

        public void Update(GameTime gameTime)
        {


        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }




    }
}
