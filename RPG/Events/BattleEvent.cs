using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Boolean skillClicked = false;
        Boolean targetClicked = false;
        
        //Boolean für das Ende der Runde
        Boolean boolTurnOver = false;
        //Aktiver Charakter
        Character activeChar;
        int activeCharCounter;
        int countFightCadre;

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
        private Vector2 skillPosition_1 = new Vector2(400, 75);
        private Vector2 skillPosition_2 = new Vector2(400, 100);
        private Vector2 skillPosition_3 = new Vector2(400, 125);
        private Vector2 skillPosition_4 = new Vector2(400, 150);


        private Vector2 attackSkillPosition = new Vector2(400, 50);
        private Vector2 restSkillPosition = new Vector2(400, 25);


        private Vector2 targetPosition_1 = new Vector2(100, 75);
        private Vector2 targetPosition_2 = new Vector2(100, 100);
        private Vector2 targetPosition_3 = new Vector2(100, 125);
        private Vector2 targetPosition_4 = new Vector2(100, 150);

        //Animation Speed
        private int animationSpeed = 300;

        //Skills draw
        TextElement attackSkill;
        TextElement restSkill;

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

        GUIElement mindBlownIco;
        GUIElement bleedIco;
        GUIElement burnIco;
        GUIElement blessedIco;
        GUIElement haloIco;
        GUIElement toxicIco;


        public BattleEvent(List<PartyMember> fightCadre, List<Enemy> enemies)
        {
            //Zuweisung der Listen
            this.FightCadre = fightCadre;
            this.Enemies = enemies;

            //FightCader wird der Liste FightClub hinzugefügt
            foreach (Character character in this.FightCadre)
            {
                this.FightClub.Add(character);
            }

            //Enemies wird der Liste FightClub hinzugefügt
            foreach (Character character in this.Enemies)
            {
                this.FightClub.Add(character);
            }

            // FightClub Member werden nach dem Initiative wert sortiert
            this.FightClub.OrderBy(character => character.GetInitiative());
            activeChar = FightClub.ElementAt<Character>(0);
            activeCharCounter = 0;
        }

        public void LoadContent(ContentManager content)
        {
            this.LoadTextures(content);
            //Animation erstellt
            Animation charStandardAnimation_1 = new Animation();
            Animation charStandardAnimation_2 = new Animation();
            Animation charStandardAnimation_3 = new Animation();
            Animation charStandardAnimation_4 = new Animation();

            Animation charAttackAnimation_1 = new Animation();
            Animation charAttackAnimation_2 = new Animation();
            Animation charAttackAnimation_3 = new Animation();
            Animation charAttackAnimation_4 = new Animation();
             
            Animation charDeathAnimation_1 = new Animation();
            Animation charDeathAnimation_2 = new Animation();
            Animation charDeathAnimation_3 = new Animation();
            Animation charDeathAnimation_4 = new Animation();

            Animation enemyStandardAnimation_1 = new Animation();
            Animation enemyStandardAnimation_2 = new Animation();
            Animation enemyStandardAnimation_3 = new Animation();
            Animation enemyStandardAnimation_4 = new Animation();

            Animation enemyAttackAnimation_1 = new Animation();
            Animation enemyAttackAnimation_2 = new Animation();
            Animation enemyAttackAnimation_3 = new Animation();
            Animation enemyAttackAnimation_4 = new Animation();

            Animation enemyDeathAnimation_1 = new Animation();
            Animation enemyDeathAnimation_2 = new Animation();
            Animation enemyDeathAnimation_3 = new Animation();
            Animation enemyDeathAnimation_4 = new Animation();

            //GUIElemente für die Statischen Gegner erstellt
            GUIElement enemy_1;
            GUIElement enemy_2;
            GUIElement enemy_3;
            GUIElement enemy_4;

            int groupCount = 0;
            int enemyCount = 0;

            foreach (Character chars in this.FightCadre)
            {
                //Anpassung benötigt da am Ende Festwerte eingetragen wurden
                if (groupCount == 0)
                {
                    charStandardAnimation_1.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(0).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false);
                    this.FightCadre.ElementAt<Character>(0).LoadContent(charStandardAnimation_1, this.characterPosition_1);

                }

                if (groupCount == 1)
                {
                    charStandardAnimation_2.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(1).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false);
                    this.FightCadre.ElementAt<Character>(1).LoadContent(charStandardAnimation_2, this.characterPosition_2);
                }

                if (groupCount == 2)
                {
                    charStandardAnimation_3.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(2).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false);
                    this.FightCadre.ElementAt<Character>(2).LoadContent(charStandardAnimation_3, this.characterPosition_3);
                }

                if (groupCount == 3)
                {
                    charStandardAnimation_4.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(3).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false);
                    this.FightCadre.ElementAt<Character>(3).LoadContent(charStandardAnimation_4, this.characterPosition_4);
                }

                groupCount++;
            }


            foreach (Enemy chars in this.Enemies)
            {
                // Sobald der Gegner eine Animation bestizt wird dies erkannt und die Animationen werden geladen
                if (chars.isAnimated)
                {
                    if (enemyCount == 0)
                    {
                        enemyStandardAnimation_1.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(0).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 0, 2, true);
                        this.Enemies.ElementAt<Enemy>(0).LoadContent(enemyStandardAnimation_1, this.enemyPosition_1);
                    }

                    if (enemyCount == 1)
                    {
                        enemyStandardAnimation_2.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(1).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 0, 2, true);
                        this.Enemies.ElementAt<Enemy>(1).LoadContent(enemyStandardAnimation_2, this.characterPosition_2);
                    }

                    if (enemyCount == 2)
                    {
                        enemyStandardAnimation_3.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(2).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 0, 2, true);
                        this.Enemies.ElementAt<Enemy>(2).LoadContent(enemyStandardAnimation_3, this.characterPosition_3);
                    }

                    if (enemyCount == 3)
                    {
                        enemyStandardAnimation_4.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(3).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false);
                        this.Enemies.ElementAt<Enemy>(3).LoadContent(enemyStandardAnimation_4, this.characterPosition_4);
                    }

                    enemyCount++;
                }
                // Wenn der Gegner erstellt wird und es keine Animation für den Gegner gibt wird dem entsprechend nur ein Bild des gegeners geladen
                else
                {
                    if (enemyCount == 0)
                    {
                        enemy_1 = new GUIElement(this.Enemies.ElementAt<Enemy>(0).standardAnimationPath, (int) this.enemyPosition_1.X, (int) this.enemyPosition_1.Y);
                    }

                    if (enemyCount == 1)
                    {
                        enemy_2 = new GUIElement(this.Enemies.ElementAt<Enemy>(1).standardAnimationPath, (int) this.enemyPosition_2.X, (int) this.enemyPosition_2.Y);
                    }

                    if (enemyCount == 2)
                    {
                        enemy_3 = new GUIElement(this.Enemies.ElementAt<Enemy>(2).standardAnimationPath, (int) this.enemyPosition_3.X, (int) this.enemyPosition_3.Y);
                    }

                    if (enemyCount == 3)
                    {
                        enemy_4 = new GUIElement(this.Enemies.ElementAt<Enemy>(3).standardAnimationPath, (int) this.enemyPosition_4.X, (int) this.enemyPosition_4.Y);
                    }
                    enemyCount++;
                }

            }

        }

        public void LoadTextures(ContentManager content)
        {
            int skillCounter = 0;
            int charCounter = 0;
            int enemieCounter = 0;

            this.attackSkill = new TextElement("Angriff", (int) this.attackSkillPosition.X, (int) this.attackSkillPosition.Y, true);
            this.attackSkill.LoadContent(content);
            this.attackSkill.tclickEvent += OnClickSkill;
            this.restSkill = new TextElement("Ausruhen", (int) this.restSkillPosition.X, (int) this.restSkillPosition.Y, true);
            this.restSkill.LoadContent(content);
            this.restSkill.tclickEvent += OnClickSkill;

            this.mindBlownIco = new GUIElement("Icons\\Mindblown_Icon");
            this.bleedIco = new GUIElement("Icons\\Bleed_Icon");
            this.blessedIco = new GUIElement("Icons\\Blessed_Icon");
            this.burnIco = new GUIElement("Icons\\Burn_Icon");
            this.haloIco = new GUIElement("Icons\\Halo_Icon");
            this.toxicIco = new GUIElement("Icons\\Toxic_Icon");

            foreach (Character character in this.FightCadre)
            {

                if (character.GetType() == typeof(PartyMember))
                {
                    if (charCounter == 0)
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.Character1Name = new TextElement(character.Name, (int) this.targetPosition_1.X, (int) this.targetPosition_1.Y, true);
                                this.character1skill1 = new TextElement(skill.Name, (int) this.skillPosition_1.X, (int) this.skillPosition_1.Y, true);
                                this.character1skill1.LoadContent(content);
                                this.Character1Name.LoadContent(content);
                                this.character1skill1.tclickEvent += this.OnClickSkill;
                                this.Character1Name.tclickEvent += this.onClickTarget;
                            }
                            if (skillCounter == 1)
                            {
                                this.character1skill2 = new TextElement(skill.Name, (int) this.skillPosition_2.X, (int) this.skillPosition_2.Y, true);
                                this.character1skill2.LoadContent(content);
                                this.character1skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character1skill3 = new TextElement(skill.Name, (int) this.skillPosition_3.X, (int) this.skillPosition_3.Y, true);
                                this.character1skill3.LoadContent(content);
                                this.character1skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character1skill4 = new TextElement(skill.Name, (int) this.skillPosition_4.X, (int) this.skillPosition_4.Y, true);
                                this.character1skill4.LoadContent(content);
                                this.character1skill4.tclickEvent += this.OnClickSkill;
                            }
                            skillCounter++;
                        }

                    if (charCounter == 1)
                    {
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.Character2Name = new TextElement(character.Name, (int)this.targetPosition_2.X, (int)this.targetPosition_2.Y, true);
                                this.character2skill1 = new TextElement(skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true);
                                this.character2skill1.LoadContent(content);
                                this.Character2Name.LoadContent(content);
                                this.character2skill1.tclickEvent += this.OnClickSkill;
                                this.Character2Name.tclickEvent += this.onClickTarget;
                            }
                            if (skillCounter == 1)
                            {
                                this.character2skill2 = new TextElement(skill.Name, (int)this.skillPosition_2.X, (int)this.skillPosition_2.Y, true);
                                this.character2skill2.LoadContent(content);
                                this.character2skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character2skill3 = new TextElement(skill.Name, (int)this.skillPosition_3.X, (int)this.skillPosition_3.Y, true);
                                this.character2skill3.LoadContent(content);
                                this.character2skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character2skill4 = new TextElement(skill.Name, (int)this.skillPosition_4.X, (int)this.skillPosition_4.Y, true);
                                this.character2skill4.LoadContent(content);
                                this.character2skill4.tclickEvent += this.OnClickSkill;
                            }

                            skillCounter++;
                        }
                        
                    }

                    if (charCounter == 2)
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.Character3Name = new TextElement(character.Name, (int) this.targetPosition_3.X, (int) this.targetPosition_3.Y, true);
                                this.character3skill1 = new TextElement(skill.Name, (int) this.skillPosition_1.X, (int) this.skillPosition_1.Y, true);
                                this.character3skill1.LoadContent(content);
                                this.Character3Name.LoadContent(content);
                                this.character3skill1.tclickEvent += this.OnClickSkill;
                                this.Character3Name.tclickEvent += this.onClickTarget;
                            }
                            if (skillCounter == 1)
                            {
                                this.character3skill2 = new TextElement(skill.Name, (int) this.skillPosition_2.X, (int) this.skillPosition_2.Y, true);
                                this.character3skill2.LoadContent(content);
                                this.character3skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character3skill3 = new TextElement(skill.Name, (int) this.skillPosition_3.X, (int) this.skillPosition_3.Y, true);
                                this.character3skill3.LoadContent(content);
                                this.character3skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character3skill4 = new TextElement(skill.Name, (int) this.skillPosition_4.X, (int) this.skillPosition_4.Y, true);
                                this.character3skill4.LoadContent(content);
                                this.character3skill4.tclickEvent += this.OnClickSkill;
                            }

                            skillCounter++;
                        }

                    if (charCounter == 3)
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.Character4Name = new TextElement(character.Name, (int) this.targetPosition_4.X, (int) this.targetPosition_4.Y, true);
                                this.character4skill1 = new TextElement(skill.Name, (int) this.skillPosition_1.X, (int) this.skillPosition_1.Y, true);
                                this.character4skill1.LoadContent(content);
                                this.Character4Name.LoadContent(content);
                                this.character4skill1.tclickEvent += this.OnClickSkill;
                                this.Character4Name.tclickEvent += this.onClickTarget;
                            }
                            if (skillCounter == 1)
                            {
                                this.character4skill2 = new TextElement(skill.Name, (int) this.skillPosition_2.X, (int) this.skillPosition_2.Y, true);
                                this.character4skill2.LoadContent(content);
                                this.character4skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character4skill3 = new TextElement(skill.Name, (int) this.skillPosition_3.X, (int) this.skillPosition_3.Y, true);
                                this.character4skill3.LoadContent(content);
                                this.character4skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character4skill4 = new TextElement(skill.Name, (int) this.skillPosition_4.X, (int) this.skillPosition_4.Y, true);
                                this.character4skill4.LoadContent(content);
                                this.character4skill4.tclickEvent += this.OnClickSkill;
                            }
                            skillCounter++;
                        }

                    skillCounter = 0;
                    charCounter++;
                }
            }
            foreach (Enemy enemy in this.Enemies)
            {
                if (enemieCounter == 0)
                {
                    this.Enemie1Name = new TextElement(enemy.Name, (int) this.targetPosition_1.X, (int) this.targetPosition_1.Y, true);
                    this.Enemie1Name.LoadContent(content);
                    this.Enemie1Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 1)
                {
                    this.Enemie2Name = new TextElement(enemy.Name, (int) this.targetPosition_2.X, (int) this.targetPosition_2.Y, true);
                    this.Enemie2Name.LoadContent(content);
                    this.Enemie2Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 2)
                {
                    this.Enemie3Name = new TextElement(enemy.Name, (int) this.targetPosition_3.X, (int) this.targetPosition_3.Y, true);
                    this.Enemie3Name.LoadContent(content);
                    this.Enemie3Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 3)
                {
                    this.Enemie4Name = new TextElement(enemy.Name, (int) this.targetPosition_4.X, (int) this.targetPosition_4.Y, true);
                    this.Enemie4Name.LoadContent(content);
                    this.Enemie4Name.tclickEvent += this.onClickTarget;
                }
                enemieCounter++;
            }
        }

        public void onClickTarget(String target)
        {
            this.targetClicked = false;
            foreach (Character character in this.FightClub)
            {
                if (character.Name.ToLower() == target.ToLower())
                {
                    this.activeSkill.Execute(this.activeChar, new List<Character> { character });
                    this.boolTurnOver = true;
                    this.skillClicked = false;
                    this.targetClicked = true;
                    this.singleTargetEnemies = false;
                    this.singleTargetParty = false;

                    if (activeCharCounter == FightClub.Count - 1)
                    {
                        activeCharCounter = 0;
                        activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                    }
                    else if(activeCharCounter != FightClub.Count - 1)
                    {
                        activeCharCounter++;
                        activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                    }
                    
                }
            }
        }

        //Beim Klicken auf den Skill
        public void OnClickSkill(String skillName)
        {
            // List der Gegner
            List<Character> targets = new List<Character>();
            this.skillClicked = true;
            this.targetClicked = false;

            Skill usedSkill;

            //Skill wird überprüft
            foreach (Skill skill in this.activeChar.Skills)
            {
                if (skillName == skill.Name)
                {
                    usedSkill = skill;

                    /*else if(skillName.ToLower().Equals("Angriff".ToLower()))
                    {
                        usedSkill = activeChar.AttackSkill;
                    }
                    else if (skillName.ToLower().Equals("Ausruhen".ToLower()))
                    {
                        skill.Execute(activeChar, new List<Character> { activeChar});
                        if (activeCharCounter == FightClub.Count - 1)
                        {
                            activeCharCounter = 0;
                            activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                        }
                        else if (activeCharCounter != FightClub.Count - 1)
                        {
                            activeCharCounter++;
                            activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                        }
                        boolTurnOver = true;
                        break;
                    }
                    else
                    {
                        usedSkill = skill;
                    }
                    */
                    //Wenn der Skill auf einzelne Charaktere zielt wird das ausgeführt
                    if (skill.Target.ToLower() == "Single".ToLower())
                    {
                        //Wenn der Skill sich auf PartyMember bezieht soll singleTarget True gesetzt werden
                        if (skill.AreaOfEffect.ToLower() == "Party".ToLower())
                        {
                            this.singleTargetParty = true;
                            this.activeSkill = skill;
                        }

                        // Sonst wird über prüft ob der Skill für einen Gegner bestimmt ist wenn ja dann soll singleTargetEnemies True gesetzt werden
                        else if (skill.AreaOfEffect.ToLower() == "Enemy".ToLower())
                        {
                            this.singleTargetEnemies = true;
                            this.activeSkill = skill;
                        }
                    }
                    else if(skill.Target.ToLower() == "Group".ToLower())
                    {
                        //Wenn der Skill sich auf eine Gruppe bezieht wird der skill ausgeführt dabei wird differenziert zwischen party und enemys
                        if (skill.AreaOfEffect.ToLower() == "Party".ToLower())
                        {
                            foreach (PartyMember member in this.FightCadre)
                            {
                                targets.Add(member);
                            }

                            skill.Execute(this.activeChar, targets);
                            this.boolTurnOver = true;
                        }
                        else if (skill.AreaOfEffect.ToLower() == "Enemy".ToLower())
                        {

                            foreach (Enemy enemy in this.Enemies)
                            {
                                targets.Add(enemy);
                            }
                            skill.Execute(this.activeChar, targets);
                            this.boolTurnOver = true;
                            this.targetClicked = true;
                            TurnStart();
                            break;
                        }
                    }
                }
            }
        }


        //führt die Logik aus wie beispielsweise die Steuerung oder das Abspielen der Animationen
        public void Update(GameTime gameTime)
        {
            if (activeChar.GetType() == typeof(Enemy))
            {
                //führe KI aus
                TurnStart();
                /*
                if (activeCharCounter == FightClub.Count - 1)
                {
                    activeCharCounter = 0;
                    activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                }
                else if(activeCharCounter != FightClub.Count - 1)
                {
                    activeCharCounter++;
                    activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                }*/
               
            }
            else
            {
                if (!skillClicked)
                {
                    for (countFightCadre = 0; countFightCadre < this.FightCadre.Count - 1; countFightCadre++)
                    {
                        if (this.FightCadre.ElementAt(countFightCadre) == this.activeChar)
                            break;
                    }

                    if (countFightCadre == 0)
                    {
                        if (!this.skillClicked)
                        {
                            this.character1skill1.Update();
                            this.character1skill2.Update();
                            this.character1skill3.Update();
                            this.character1skill4.Update();
                        }
                        countFightCadre = 0;
                    }
                    if (countFightCadre == 1)
                    {
                        if (!this.skillClicked)
                        {
                            this.character2skill1.Update();
                            this.character2skill2.Update();
                            this.character2skill3.Update();
                            this.character2skill4.Update();
                        }
                        countFightCadre = 0;
                    }
                    if (countFightCadre == 2)
                    {
                        if (!this.skillClicked)
                        {
                            this.character3skill1.Update();
                            this.character3skill2.Update();
                            this.character3skill3.Update();
                            this.character3skill4.Update();
                        }
                        countFightCadre = 0;
                    }
                    if (countFightCadre == 3)
                    {
                        if (!this.skillClicked)
                        {
                            this.character4skill1.Update();
                            this.character4skill2.Update();
                            this.character4skill3.Update();
                            this.character4skill4.Update();
                        }
                        countFightCadre = 0;
                    }
                    this.attackSkill.Update();
                    this.restSkill.Update();
                }

                if (!targetClicked)
                {
                    this.Character1Name.Update();
                    this.Character2Name.Update();
                    this.Character3Name.Update();
                    this.Character4Name.Update();

                    this.Enemie1Name.Update();
                }
            }

            //Wechselt die Frames der befreundeten Animationen
            foreach (Character chars in this.FightCadre)
            {
                chars.Update(gameTime);
            }
            
            //Wechselt die Frames der Gegnerischen Animation
            foreach (Character chars in this.Enemies)
            {
                chars.Update(gameTime);
            }

        }

        //zeichnet Charactere und Texte auf dem Bildschirm 
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!this.skillClicked)
            {
                for (countFightCadre = 0; countFightCadre < this.FightCadre.Count - 1; countFightCadre++)
                {
                    if (this.FightCadre.ElementAt(countFightCadre) == this.activeChar)
                        break;
                }

                if (countFightCadre == 0)
                {
                    this.character1skill1.Draw(spriteBatch);
                    this.character1skill2.Draw(spriteBatch);
                    this.character1skill3.Draw(spriteBatch);
                    this.character1skill4.Draw(spriteBatch);
                    countFightCadre = 0;
                }
                if (countFightCadre == 1)
                {
                    this.character2skill1.Draw(spriteBatch);
                    this.character2skill2.Draw(spriteBatch);
                    this.character2skill3.Draw(spriteBatch);
                    this.character2skill4.Draw(spriteBatch);
                    countFightCadre = 0;
                }
                if (countFightCadre == 2)
                {
                    this.character3skill1.Draw(spriteBatch);
                    this.character3skill2.Draw(spriteBatch);
                    this.character3skill3.Draw(spriteBatch);
                    this.character3skill4.Draw(spriteBatch);
                    countFightCadre = 0;
                }
                if (countFightCadre == 3)
                {
                    this.character4skill1.Draw(spriteBatch);
                    this.character4skill2.Draw(spriteBatch);
                    this.character4skill3.Draw(spriteBatch);
                    this.character4skill4.Draw(spriteBatch);
                    countFightCadre = 0;
                }
                this.restSkill.Draw(spriteBatch);
                this.attackSkill.Draw(spriteBatch);
            }

            if (activeChar.GetType() != typeof(Enemy))
            {
                if (this.singleTargetParty)
                {
                    if (!this.targetClicked)
                    {
                        if (this.Character1Name != null)
                            this.Character1Name.Draw(spriteBatch);
                        if (this.Character2Name != null)
                            this.Character2Name.Draw(spriteBatch);
                        if (this.Character3Name != null)
                            this.Character3Name.Draw(spriteBatch);
                        if (this.Character4Name != null)
                            this.Character4Name.Draw(spriteBatch);
                    }
                }

                if (this.singleTargetEnemies)
                {
                    if (!this.targetClicked)
                    {
                        if (this.Enemie1Name != null)
                            this.Enemie1Name.Draw(spriteBatch);
                        if (this.Enemie2Name != null)
                            this.Enemie2Name.Draw(spriteBatch);
                        if (this.Enemie3Name != null)
                            this.Enemie3Name.Draw(spriteBatch);
                        if (this.Enemie4Name != null)
                            this.Enemie4Name.Draw(spriteBatch);
                    }
                }

            }

            // Zeichnet die Charaktere auf dem Bildschirm
            foreach (Character chars in this.FightCadre)
            {
                chars.Draw(spriteBatch);
            }

            // Zeichnet die Gegner auf dem Bildschirm
            foreach (Character chars in this.Enemies)
            {
                chars.Draw(spriteBatch);
            }
        }

        private void ExecuteStatuseffects(Character character)
        {
            for (int i = 0; i == character.Statuseffects.Count - 1; i++)
            {
                IStatuseffect currentEffect = character.Statuseffects.ElementAt(i);
                character.Life -= currentEffect.ExecuteStatus();
                if (currentEffect.IsDone())
                {
                    character.Statuseffects.Remove(character.Statuseffects.ElementAt(i));
                }
            }
        }
        public void TurnStart()
        {
            this.ExecuteStatuseffects(activeChar);

            if (activeChar.Life <= 0 || activeChar.IsMindBlown)
            {
                activeChar.IsMindBlown = false;

                if (activeCharCounter == FightClub.Count - 1)
                {
                    activeCharCounter = 0;
                    activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                }
                else if (activeCharCounter != FightClub.Count - 1)
                {
                    activeCharCounter++;
                    activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                }

            }
            else
            {

                if (activeCharCounter == FightClub.Count - 1)
                {
                    activeCharCounter = 0;
                    activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                }
                else if (activeCharCounter != FightClub.Count - 1)
                {
                    activeCharCounter++;
                    activeChar = FightClub.ElementAt<Character>(activeCharCounter);
                }
            }
            boolTurnOver = false;
            skillClicked = false;

        }
    }
}
