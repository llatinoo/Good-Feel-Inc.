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

        //Aktiver Skill
        Skill activeSkill;

        //Boolean für Drawings
        Boolean singleTargetParty = false;
        Boolean singleTargetEnemies = false;
        Boolean partyTargetParty = false;
        Boolean partyTargetEnemie = false;

        //Boolean für das Ende der Runde
        Boolean boolTurnOver = false;
        //Aktiver Charakter
        Character activeChar;

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


        private Vector2 targetPosition_1 = new Vector2();
        private Vector2 targetPosition_2 = new Vector2();
        private Vector2 targetPosition_3 = new Vector2();
        private Vector2 targetPosition_4 = new Vector2();

        //Animation Speed
        private int animationSpeed = 300;

        //Skills draw
        TextElement attackskill;
        TextElement restskill;

        TextElement character1skill1;
        TextElement character1skill2;
        TextElement character1skill3;
        TextElement character1skill4;

        TextElement character2skill1;
        TextElement character2skill2;
        TextElement character2skill3;
        TextElement character2skill4;

        TextElement character3skill1;
        TextElement character3skill2;
        TextElement character3skill3;
        TextElement character3skill4;

        TextElement character4skill1;
        TextElement character4skill2;
        TextElement character4skill3;
        TextElement character4skill4;

        TextElement Character1Name;
        TextElement Character2Name;
        TextElement Character3Name;
        TextElement Character4Name;

        TextElement Enemie1Name;
        TextElement Enemie2Name;
        TextElement Enemie3Name;
        TextElement Enemie4Name;


        public void Battle(SpriteBatch spriteBatch)
        {
            do
            {
                foreach (Character character in FightClub)
                {
                    if (character.GetType() == typeof(PartyMember) & character.Life>0)
                    {
                        this.activeChar = character;
                        do
                        {

                        }
                        while (!boolTurnOver);
                    }
                }
            }
            while (FightCadre.All(character=> character.Life>0) && Enemies.All(Enemies=> Enemies.Life>0));
        }

        public void LoadContent(ContentManager content)
        {
            LoadCharacterTextboxData();
            //Animation erstellt
            Animation charAnimation_1 = new Animation();
            Animation charAnimation_2 = new Animation();
            Animation charAnimation_3 = new Animation();
            Animation charAnimation_4 = new Animation();

            Animation enemyAnimation_1 = new Animation();
            Animation enemyAnimation_2 = new Animation();
            Animation enemyAnimation_3 = new Animation();
            Animation enemyAnimation_4 = new Animation();

            //GUIElemente für die Statischen Gegner erstellt
            GUIElement enemy_1;
            GUIElement enemy_2;
            GUIElement enemy_3;
            GUIElement enemy_4;

            int groupCount = 0;
            int enemyCount = 0;

            foreach (Character chars in FightCadre)
            {
                //Anpassung benötigt da am Ende Festwerte eingetragen wurden
                if (groupCount == 0)
                {
                    charAnimation_1.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(0).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(0).LoadContent(charAnimation_1, characterPosition_1);

                }

                if (groupCount == 1)
                {
                    charAnimation_2.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(1).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(1).LoadContent(charAnimation_2, characterPosition_2);
                }

                if (groupCount == 2)
                {
                    charAnimation_3.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(2).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(2).LoadContent(charAnimation_3, characterPosition_3);
                }

                if (groupCount == 3)
                {
                    charAnimation_4.LoadContent(content.Load<Texture2D>(FightCadre.ElementAt<Character>(3).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                    FightCadre.ElementAt<Character>(3).LoadContent(charAnimation_4, characterPosition_4);
                }

                groupCount++;
            }


            foreach (Enemy chars in Enemies)
            {
                // Sobald der Gegner eine Animation bestizt wird dies erkannt und die Animationen werden geladen
                if (chars.isAnimated)
                {
                    if (enemyCount == 0)
                    {
                        enemyAnimation_1.LoadContent(content.Load<Texture2D>(Enemies.ElementAt<Enemy>(0).standardAnimationPath), Vector2.Zero, 400, 400, animationSpeed, Color.White, 1f, true, 1, 3, false);
                        Enemies.ElementAt<Enemy>(0).LoadContent(enemyAnimation_1, enemyPosition_1);
                    }

                    if (enemyCount == 1)
                    {
                        enemyAnimation_2.LoadContent(content.Load<Texture2D>(Enemies.ElementAt<Enemy>(1).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                        Enemies.ElementAt<Enemy>(1).LoadContent(enemyAnimation_2, characterPosition_2);
                    }

                    if (enemyCount == 2)
                    {
                        enemyAnimation_3.LoadContent(content.Load<Texture2D>(Enemies.ElementAt<Enemy>(2).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                        Enemies.ElementAt<Enemy>(2).LoadContent(enemyAnimation_3, characterPosition_3);
                    }

                    if (enemyCount == 3)
                    {
                        enemyAnimation_4.LoadContent(content.Load<Texture2D>(Enemies.ElementAt<Enemy>(3).standardAnimationPath), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false);
                        Enemies.ElementAt<Enemy>(3).LoadContent(enemyAnimation_4, characterPosition_4);
                    }

                    enemyCount++;
                }
                // Wenn der Gegner erstellt wird und es keine Animation für den Gegner gibt wird dem entsprechend nur ein Bild des gegeners geladen
                else
                {
                    if (enemyCount == 0)
                    {
                        enemy_1 = new GUIElement(Enemies.ElementAt<Enemy>(0).standardAnimationPath, (int)enemyPosition_1.X, (int)enemyPosition_1.Y);
                    }

                    if (enemyCount == 1)
                    {
                        enemy_2 = new GUIElement(Enemies.ElementAt<Enemy>(1).standardAnimationPath, (int)enemyPosition_2.X, (int)enemyPosition_2.Y);
                    }

                    if (enemyCount == 2)
                    {
                        enemy_3 = new GUIElement(Enemies.ElementAt<Enemy>(2).standardAnimationPath, (int)enemyPosition_3.X, (int)enemyPosition_3.Y);
                    }

                    if (enemyCount == 3)
                    {
                        enemy_4 = new GUIElement(Enemies.ElementAt<Enemy>(3).standardAnimationPath, (int)enemyPosition_4.X, (int)enemyPosition_4.Y);
                    }
                    enemyCount++;
                }

            }

        }

        public void LoadCharacterTextboxData()
        {
            int skillCounter = 0;
            int charCounter = 0;
            int enemieCounter = 0;

            attackskill = new TextElement("Angriff", (int)skillPosition_1.X, (int)skillPosition_1.Y);
            restskill = new TextElement("Ausruhen", (int)skillPosition_1.X, (int)skillPosition_1.Y);

            foreach (Character character in FightCadre)
            {

                if (character.GetType() == typeof(PartyMember))
                {
                    if(charCounter==0)
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                Character1Name = new TextElement(character.Name, (int)targetPosition_1.X, (int)targetPosition_1.Y); 
                                character1skill1 = new TextElement(skill.Name, (int)skillPosition_1.X, (int)skillPosition_1.Y);
                                character1skill1.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                character1skill2 = new TextElement(skill.Name, (int)skillPosition_2.X, (int)skillPosition_2.Y);
                                character1skill2.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                character1skill3 = new TextElement(skill.Name, (int)skillPosition_3.X, (int)skillPosition_3.Y);
                                character1skill3.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                character1skill4 = new TextElement(skill.Name, (int)skillPosition_4.X, (int)skillPosition_4.Y);
                                character1skill4.tclickEvent += OnClickSkill;
                            }
                            skillCounter++;
                        }
                
                    if (charCounter == 1)
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                Character2Name = new TextElement(character.Name, (int)targetPosition_2.X, (int)targetPosition_2.Y);
                                character2skill1 = new TextElement(skill.Name, (int)skillPosition_1.X, (int)skillPosition_1.Y);
                                character2skill1.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                character2skill2 = new TextElement(skill.Name, (int)skillPosition_2.X, (int)skillPosition_2.Y);
                                character2skill2.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                character2skill3 = new TextElement(skill.Name, (int)skillPosition_3.X, (int)skillPosition_3.Y);
                                character2skill2.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                character2skill4 = new TextElement(skill.Name, (int)skillPosition_4.X, (int)skillPosition_4.Y);
                                character2skill4.tclickEvent += OnClickSkill;
                            }

                            skillCounter++;
                        }

                    if (charCounter == 2)
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                Character3Name = new TextElement(character.Name, (int)targetPosition_3.X, (int)targetPosition_3.Y);
                                character3skill1 = new TextElement(skill.Name, (int)skillPosition_1.X, (int)skillPosition_1.Y);
                                character3skill1.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                character3skill2 = new TextElement(skill.Name, (int)skillPosition_2.X, (int)skillPosition_2.Y);
                                character3skill2.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                character3skill3 = new TextElement(skill.Name, (int)skillPosition_3.X, (int)skillPosition_3.Y);
                                character3skill3.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                character3skill4 = new TextElement(skill.Name, (int)skillPosition_4.X, (int)skillPosition_4.Y);
                                character3skill4.tclickEvent += OnClickSkill;
                            }

                            skillCounter++;
                        }

                    if (charCounter == 3)
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                Character4Name = new TextElement(character.Name, (int)targetPosition_4.X, (int)targetPosition_4.Y);
                                character3skill1 = new TextElement(skill.Name, (int)skillPosition_1.X, (int)skillPosition_1.Y);
                                character3skill1.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                character3skill2 = new TextElement(skill.Name, (int)skillPosition_2.X, (int)skillPosition_2.Y);
                                character3skill2.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                character3skill3 = new TextElement(skill.Name, (int)skillPosition_3.X, (int)skillPosition_3.Y);
                                character3skill3.tclickEvent += OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                character3skill4 = new TextElement(skill.Name, (int)skillPosition_4.X, (int)skillPosition_4.Y);
                                character3skill4.tclickEvent += OnClickSkill;
                            }
                            skillCounter++;
                        }

                    skillCounter = 0;
                    charCounter++;
                }
            }
            foreach(Enemy enemy in Enemies)
            {
                if(enemieCounter == 0)
                    Enemie1Name = new TextElement(enemy.Name, (int)targetPosition_1.X, (int)targetPosition_1.Y);
                if(enemieCounter == 1)
                    Enemie2Name = new TextElement(enemy.Name, (int)targetPosition_2.X, (int)targetPosition_2.Y);
                if(enemieCounter == 2)
                    Enemie3Name = new TextElement(enemy.Name, (int)targetPosition_3.X, (int)targetPosition_3.Y);
                if(enemieCounter == 3)
                    Enemie3Name = new TextElement(enemy.Name, (int)targetPosition_4.X, (int)targetPosition_4.Y);

                enemieCounter++;
            }
        }

        //Malt die AUswahlbox der Gegner bei ausgewähltem Skill
        public void DrawTargetBox(SpriteBatch spriteBatch)
        {

            if (singleTargetParty)
            {
                if(Character1Name != null)
                Character1Name.Draw(spriteBatch);
                if(Character2Name != null)
                Character2Name.Draw(spriteBatch);
                if(Character3Name != null)
                Character3Name.Draw(spriteBatch);
                if(Character4Name != null)
                Character4Name.Draw(spriteBatch);
            }

            if (singleTargetEnemies)
            {
                if (Enemie1Name != null)
                    Enemie1Name.Draw(spriteBatch);
                if (Enemie2Name != null)
                    Enemie2Name.Draw(spriteBatch);
                if (Enemie3Name != null)
                    Enemie3Name.Draw(spriteBatch);
                if (Enemie4Name != null)
                    Enemie4Name.Draw(spriteBatch);
            }

            Character1Name.tclickEvent += onClickTarget;
        }

        public void onClickTarget(String target)
        {
            foreach(Character character in FightClub)
            {
                if(character.Name.ToLower() == target.ToLower())
                {
                    activeSkill.Execute(activeChar, new List<Character> {character});
                    boolTurnOver = true;
                }
            }
        }

        //Beim Klicken auf den Skill
        public void OnClickSkill(String skill)
        {
            // List der Gegner
            List<Character> targets = new List<Character>();

            //Skill wird überprüft
            foreach (Skill skills in activeChar.Skills)
            {
                if (skill == skills.Name)
                        
                //Wenn der Skill auf einzelne Charaktere zielt wird das ausgeführt
                if (skills.Target.ToLower() == "single".ToLower())
                {
                    //Wenn der Skill sich auf PartyMember bezieht soll singleTarget True gesetzt werden
                    if (skills.AreaOfEffect.ToLower() == "party".ToLower())
                    {
                        singleTargetParty = true;
                        activeSkill = skills;
                        }

                    // Sonst wird über prüft ob der Skill für einen Gegner bestimmt ist wenn ja dann soll singleTargetEnemies True gesetzt werden
                    else if (skills.AreaOfEffect.ToLower() == "enemy".ToLower())
                    {
                        singleTargetEnemies = true;
                        activeSkill = skills;
                    }
                }
                else
                {
                    //Wenn der Skill sich auf eine Gruppe bezieht wird der skill ausgeführt dabei wird differenziert zwischen party und enemys
                    if (skills.AreaOfEffect.ToLower() == "party".ToLower())
                    {
                        foreach (PartyMember member in FightCadre)
                        {
                            targets.Add(member);
                        }

                        skills.Execute(activeChar, targets);
                        boolTurnOver = true;
                        }
                    else if (skills.AreaOfEffect.ToLower() == "enemy".ToLower())
                    {

                        foreach (Enemy enemy in Enemies)
                        {
                            targets.Add(enemy);
                        }
                        skills.Execute(activeChar, targets);
                        boolTurnOver = true;
                        }
                }
            }
        }

        public BattleEvent(List<PartyMember> fightCadre, List<Enemy> enemies)
        {
            //Zuweisung der Listen
            this.FightCadre = fightCadre;
            this.Enemies = enemies;

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
            int i;
            for ( i = 0; i < FightCadre.Count-1; i++)
            {
                if (FightCadre.ElementAt(i) == activeChar)
                    break;
            }

            if (i == 0)
            {
               character1skill1.Draw(spriteBatch);
               character1skill2.Draw(spriteBatch);
               character1skill3.Draw(spriteBatch);
               character1skill4.Draw(spriteBatch);
            }
            if(i == 1)
            {
                character2skill1.Draw(spriteBatch);
                character2skill2.Draw(spriteBatch);
                character2skill3.Draw(spriteBatch);
                character2skill4.Draw(spriteBatch);
            }
            if (i == 2)
            {
                character3skill1.Draw(spriteBatch);
                character3skill2.Draw(spriteBatch);
                character3skill3.Draw(spriteBatch);
                character3skill4.Draw(spriteBatch);
            }
            if (i == 3)
            {
                character4skill1.Draw(spriteBatch);
                character4skill2.Draw(spriteBatch);
                character4skill3.Draw(spriteBatch);
                character4skill4.Draw(spriteBatch);
            }

            attackskill.Draw(spriteBatch);
            restskill.Draw(spriteBatch);

            // Zeichnet die Charaktere auf dem Bildschirm
            foreach (Character chars in FightCadre)
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
