using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using Microsoft.Xna.Framework.Audio;
using System.Timers;

namespace RPG.Events
{
    class BattleEvent
    {
        bool AllowDeathAnimation = false;
        Controls controls = new Controls();
        SpriteFont AwesomeFont;
        GameOverEvent GameOver;
        
        BattleEvaluationEvent battleEvaluation;
        public BattleEvaluationEvent BattleEvaluation
        {
            get { return battleEvaluation; }
        }

        //Alle Character im BattleEvent
        List<Character> FightClub = new List<Character>();

        //Benutzer Gruppe
        List<PartyMember> FightCadre = new List<PartyMember>();
        
        //Gegner Gruppe
        List<Enemy> Enemies = new List<Enemy>();

        //Aktiver Skill
        Skill activeSkill;

        //Boolean für Drawings
        bool singleTargetParty = false;
        bool singleTargetEnemies = false;
        bool skillClicked = false;
        bool targetClicked = false;
        
        //Boolean für das Ende der Runde
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
        private Vector2 attackSkillPosition = new Vector2(400, 475);
        private Vector2 restSkillPosition = new Vector2(400, 500);
        private Vector2 skillPosition_1 = new Vector2(400, 525);
        private Vector2 skillPosition_2 = new Vector2(400, 550);
        private Vector2 skillPosition_3 = new Vector2(550, 475);
        private Vector2 skillPosition_4 = new Vector2(550, 500);

        private Vector2 targetPosition_1 = new Vector2(30, 475);
        private Vector2 targetPosition_2 = new Vector2(30, 500);
        private Vector2 targetPosition_3 = new Vector2(30, 525);
        private Vector2 targetPosition_4 = new Vector2(30, 550);

        private Vector2 icoPositionCharacter_1 = new Vector2(650, 380);
        private Vector2 icoPositionCharacter_2 = new Vector2(645, 325);
        private Vector2 icoPositionCharacter_3 = new Vector2(635, 260);
        private Vector2 icoPositionCharacter_4 = new Vector2(625, 195);

        Vector2 icoPositionEnemy_1 = new Vector2(40, 390);
        Vector2 icoPositionEnemy_2 = new Vector2(50, 350);
        Vector2 icoPositionEnemy_3 = new Vector2(60, 285);
        Vector2 icoPositionEnemy_4 = new Vector2(70, 220);

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

        TextElement enemy1Name;
        TextElement enemy2Name;
        TextElement enemy3Name;
        TextElement enemy4Name;

        TextElement Back;

        GUIElement mindBlownIcoCharacter_1;
        GUIElement bleedIcoCharacter_1;
        GUIElement burnIcoCharacter_1;
        GUIElement blessedIcoCharacter_1;
        GUIElement haloIcoCharacter_1;
        GUIElement toxicIcoCharacter_1;

        GUIElement mindBlownIcoCharacter_2;
        GUIElement bleedIcoCharacter_2;
        GUIElement burnIcoCharacter_2;
        GUIElement blessedIcoCharacter_2;
        GUIElement haloIcoCharacter_2;
        GUIElement toxicIcoCharacter_2;

        GUIElement mindBlownIcoCharacter_3;
        GUIElement bleedIcoCharacter_3;
        GUIElement burnIcoCharacter_3;
        GUIElement blessedIcoCharacter_3;
        GUIElement haloIcoCharacter_3;
        GUIElement toxicIcoCharacter_3;

        GUIElement mindBlownIcoCharacter_4;
        GUIElement bleedIcoCharacter_4;
        GUIElement burnIcoCharacter_4;
        GUIElement blessedIcoCharacter_4;
        GUIElement haloIcoCharacter_4;
        GUIElement toxicIcoCharacter_4;

        GUIElement mindBlownIcoEnemy_1;
        GUIElement bleedIcoEnemy_1;
        GUIElement burnIcoEnemy_1;
        GUIElement blessedIcoEnemy_1;
        GUIElement haloIcoEnemy_1;
        GUIElement toxicIcoEnemy_1;

        GUIElement mindBlownIcoEnemy_2;
        GUIElement bleedIcoEnemy_2;
        GUIElement burnIcoEnemy_2;
        GUIElement blessedIcoEnemy_2;
        GUIElement haloIcoEnemy_2;
        GUIElement toxicIcoEnemy_2;

        GUIElement mindBlownIcoEnemy_3;
        GUIElement bleedIcoEnemy_3;
        GUIElement burnIcoEnemy_3;
        GUIElement blessedIcoEnemy_3;
        GUIElement haloIcoEnemy_3;
        GUIElement toxicIcoEnemy_3;

        GUIElement mindBlownIcoEnemy_4;
        GUIElement bleedIcoEnemy_4;
        GUIElement burnIcoEnemy_4;
        GUIElement blessedIcoEnemy_4;
        GUIElement haloIcoEnemy_4;
        GUIElement toxicIcoEnemy_4;

        GUIElement skillBox;
        GUIElement targetBox;
        GUIElement Background;

        GUIElement ActivePartymember1Arrow;
        GUIElement ActivePartymember2Arrow;
        GUIElement ActivePartymember3Arrow;
        GUIElement ActivePartymember4Arrow;

        GUIElement ActiveEnemy1Arrow;
        GUIElement ActiveEnemy2Arrow;
        GUIElement ActiveEnemy3Arrow;
        GUIElement ActiveEnemy4Arrow;

        GUIElement CharacterStatBox;

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

        Animation hitAnimation = new Animation();
        Animation healAnimation = new Animation();

        Skill Hit;
        Skill Heal;

        SoundEffect Click;
        SoundEffect Punch;

        public BattleEvent(List<PartyMember> fightCadre, List<Enemy> enemies, string background)
        {
            //Zuweisung der Listen
            this.FightCadre = fightCadre;
            this.Enemies = enemies;
            Background = new GUIElement(background);

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
            targetClicked = true;
        }

        //Läd alle Texturen und Daten die das Event benötigt
        public void LoadContent(ContentManager content)
        {
            Click = content.Load<SoundEffect>("Sounds\\Effects\\click");
            Punch = content.Load<SoundEffect>("Sounds\\Effects\\Punch");
            this.LoadTextures(content);

            //GUIElemente für die Statischen Gegner erstellt
            GUIElement enemy_1;
            GUIElement enemy_2;
            GUIElement enemy_3;
            GUIElement enemy_4;

            int groupCount = 0;
            int enemyCount = 0;

            hitAnimation.LoadContent(content.Load<Texture2D>("Animations\\Skills\\Physical_Hit"), Vector2.Zero, 192, 192, this.animationSpeed - 200, Color.White, 1f, false, 1, 5, false, false);
            Hit = new Skill("PhysicalHit", 0, null, null, null);
            Hit.LoadContent(hitAnimation, new Vector2(0, 0));
            hitAnimation.active = false;

            healAnimation.LoadContent(content.Load<Texture2D>("Animations\\Skills\\Heal"), Vector2.Zero, 80, 80, this.animationSpeed - 200, Color.White, 1f, false, 1, 10, false, false);
            Heal = new Skill("Heal", 0, null, null, null);
            Heal.LoadContent(healAnimation, new Vector2(0, 0));
            healAnimation.active = false;

            foreach (Character chars in this.FightCadre)
            {
                //Anpassung benötigt da am Ende Festwerte eingetragen wurden
                if (groupCount == 0)
                {
                    charStandardAnimation_1.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(0).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false, false);
                    this.FightCadre.ElementAt<Character>(0).LoadContent(charStandardAnimation_1, this.characterPosition_1);
                    charAttackAnimation_1.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(0).attackAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 1, 6, false, false);
                    charDeathAnimation_1.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(0).deathAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 6, 1, false,true);
                    charAttackAnimation_1.active = false;
                }

                if (groupCount == 1)
                {
                    charStandardAnimation_2.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(1).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false, false);
                    this.FightCadre.ElementAt<Character>(1).LoadContent(charStandardAnimation_2, this.characterPosition_2);
                    charAttackAnimation_2.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(1).attackAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 1, 6, false, false);
                    charDeathAnimation_2.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(1).deathAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 6, 1, false, true);
                    charAttackAnimation_2.active = false;
                }

                if (groupCount == 2)
                {
                    charStandardAnimation_3.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(2).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false, false);
                    this.FightCadre.ElementAt<Character>(2).LoadContent(charStandardAnimation_3, this.characterPosition_3);
                    charAttackAnimation_3.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(2).attackAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 1, 6, false, false);
                    charDeathAnimation_3.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(2).deathAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 6, 1, false, true);
                    charAttackAnimation_3.active = false;
                }

                if (groupCount == 3)
                {
                    charStandardAnimation_4.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(3).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false, false);
                    this.FightCadre.ElementAt<Character>(3).LoadContent(charStandardAnimation_4, this.characterPosition_4);
                    charAttackAnimation_4.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(3).attackAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 1, 6, false, false);
                    charDeathAnimation_4.LoadContent(content.Load<Texture2D>(this.FightCadre.ElementAt<Character>(3).deathAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 6, 1, false, true);
                    charAttackAnimation_4.active = false;
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
                        enemyStandardAnimation_1.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(0).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 0, 2, true, false);
                        this.Enemies.ElementAt<Enemy>(0).LoadContent(enemyStandardAnimation_1, this.enemyPosition_1);
                        enemyAttackAnimation_1.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(0).attackAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 0, 5, true, false);
                        enemyDeathAnimation_1.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(0).deathAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 6, 1, false, true);
                        enemyAttackAnimation_1.active = false;
                    }

                    if (enemyCount == 1)
                    {
                        enemyStandardAnimation_2.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(1).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 0, 2, true, false);
                        this.Enemies.ElementAt<Enemy>(1).LoadContent(enemyStandardAnimation_2, this.characterPosition_2);
                        enemyAttackAnimation_2.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(1).attackAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 0, 2, true, false);
                        enemyDeathAnimation_2.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(1).deathAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 0, 2, true, true);
                        enemyAttackAnimation_2.active = false;
                    }

                    if (enemyCount == 2)
                    {
                        enemyStandardAnimation_3.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(2).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 0, 2, true, false);
                        this.Enemies.ElementAt<Enemy>(2).LoadContent(enemyStandardAnimation_3, this.characterPosition_3);
                        enemyAttackAnimation_3.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(2).attackAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 0, 2, true, false);
                        enemyDeathAnimation_3.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(2).deathAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 0, 2, true, true);
                        enemyAttackAnimation_3.active = false;
                    }

                    if (enemyCount == 3)
                    {
                        enemyStandardAnimation_4.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(3).standardAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, true, 1, 3, false, false);
                        this.Enemies.ElementAt<Enemy>(3).LoadContent(enemyStandardAnimation_4, this.characterPosition_4);
                        enemyAttackAnimation_4.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(3).attackAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 0, 2, true, false);
                        enemyDeathAnimation_4.LoadContent(content.Load<Texture2D>(this.Enemies.ElementAt<Enemy>(3).deathAnimationPath), Vector2.Zero, this.characterSize, this.characterSize, this.animationSpeed, Color.White, 1f, false, 0, 2, true, true);
                        enemyAttackAnimation_4.active = false;
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
            AwesomeFont = content.Load<SpriteFont>("Fonts\\AwesomeFont");
            int skillCounter = 0;
            int charCounter = 0;
            int enemieCounter = 0;

            Background.LoadContent(content);
            Back = new TextElement("Back", (int)targetPosition_4.X, (int)targetPosition_4.Y + 25, true);
            Back.LoadContent(content);
            Back.tclickEvent += OnClickElement;

            ActivePartymember1Arrow = new GUIElement("Others\\ActivePartymemberArrow", (int)characterPosition_1.X - 60, (int)characterPosition_1.Y - 10);
            ActivePartymember1Arrow.LoadContent(content);
            ActivePartymember2Arrow = new GUIElement("Others\\ActivePartymemberArrow", (int)characterPosition_2.X - 60, (int)characterPosition_2.Y - 10);
            ActivePartymember2Arrow.LoadContent(content);
            ActivePartymember3Arrow = new GUIElement("Others\\ActivePartymemberArrow", (int)characterPosition_3.X - 60, (int)characterPosition_3.Y - 10);
            ActivePartymember3Arrow.LoadContent(content);
            ActivePartymember4Arrow = new GUIElement("Others\\ActivePartymemberArrow", (int)characterPosition_4.X - 60, (int)characterPosition_4.Y - 10);
            ActivePartymember4Arrow.LoadContent(content);

            ActiveEnemy1Arrow = new GUIElement("Others\\ActiveEnemyArrow", (int)enemyPosition_1.X - 60, (int)enemyPosition_1.Y - 10);
            ActiveEnemy1Arrow.LoadContent(content);
            ActiveEnemy2Arrow = new GUIElement("Others\\ActiveEnemyArrow", (int)enemyPosition_2.X - 60, (int)enemyPosition_2.Y - 10);
            ActiveEnemy2Arrow.LoadContent(content);
            ActiveEnemy3Arrow = new GUIElement("Others\\ActiveEnemyArrow", (int)enemyPosition_3.X - 60, (int)enemyPosition_3.Y - 10);
            ActiveEnemy3Arrow.LoadContent(content);
            ActiveEnemy4Arrow = new GUIElement("Others\\ActiveEnemyArrow", (int)enemyPosition_4.X - 60, (int)enemyPosition_4.Y - 10);
            ActiveEnemy4Arrow.LoadContent(content);

            GameOver = new GameOverEvent("Backgrounds\\Menus\\Options_Screen_Background");
            GameOver.LoadContent(content);

            battleEvaluation = new BattleEvaluationEvent("Boxes\\SkillBox");
            battleEvaluation.LoadContent(content);

            this.attackSkill = new TextElement("Angriff", (int) this.attackSkillPosition.X, (int) this.attackSkillPosition.Y, true);
            this.attackSkill.LoadContent(content);
            this.attackSkill.tclickEvent += OnClickSkill;
            this.restSkill = new TextElement("Ausruhen", (int) this.restSkillPosition.X, (int) this.restSkillPosition.Y, true);
            this.restSkill.LoadContent(content);
            this.restSkill.tclickEvent += OnClickSkill;

            skillBox = new GUIElement("Boxes\\SkillBox");
            skillBox.LoadContent(content);
            skillBox.CenterElement(576,720);
            skillBox.moveElement(0,245);

            targetBox = new GUIElement("Boxes\\SkillBox");
            targetBox.LoadContent(content);
            targetBox.CenterElement(576, 720);
            targetBox.moveElement(0, 245);

            CharacterStatBox = new GUIElement("Boxes\\Character_Stat_Box",118,88);
            CharacterStatBox.LoadContent(content);

            this.mindBlownIcoCharacter_1 = new GUIElement("Icons\\Mindblown_Icon", (int)icoPositionCharacter_1.X, (int)icoPositionCharacter_1.Y);
            this.bleedIcoCharacter_1 = new GUIElement("Icons\\Bleed_Icon", (int)icoPositionCharacter_1.X, (int)icoPositionCharacter_1.Y);
            this.blessedIcoCharacter_1 = new GUIElement("Icons\\Blessed_Icon", (int)icoPositionCharacter_1.X, (int)icoPositionCharacter_1.Y);
            this.burnIcoCharacter_1 = new GUIElement("Icons\\Burn_Icon", (int)icoPositionCharacter_1.X, (int)icoPositionCharacter_1.Y);
            this.haloIcoCharacter_1 = new GUIElement("Icons\\Halo_Icon", (int)icoPositionCharacter_1.X, (int)icoPositionCharacter_1.Y);
            this.toxicIcoCharacter_1 = new GUIElement("Icons\\Toxic_Icon", (int)icoPositionCharacter_1.X, (int)icoPositionCharacter_1.Y);

            this.mindBlownIcoCharacter_2 = new GUIElement("Icons\\Mindblown_Icon", (int)icoPositionCharacter_2.X, (int)icoPositionCharacter_2.Y);
            this.bleedIcoCharacter_2 = new GUIElement("Icons\\Bleed_Icon", (int)icoPositionCharacter_2.X, (int)icoPositionCharacter_2.Y);
            this.blessedIcoCharacter_2 = new GUIElement("Icons\\Blessed_Icon", (int)icoPositionCharacter_2.X, (int)icoPositionCharacter_2.Y);
            this.burnIcoCharacter_2 = new GUIElement("Icons\\Burn_Icon", (int)icoPositionCharacter_2.X, (int)icoPositionCharacter_2.Y);
            this.haloIcoCharacter_2 = new GUIElement("Icons\\Halo_Icon", (int)icoPositionCharacter_2.X, (int)icoPositionCharacter_2.Y);
            this.toxicIcoCharacter_2 = new GUIElement("Icons\\Toxic_Icon", (int)icoPositionCharacter_2.X, (int)icoPositionCharacter_2.Y);

            this.mindBlownIcoCharacter_3 = new GUIElement("Icons\\Mindblown_Icon", (int)icoPositionCharacter_3.X, (int)icoPositionCharacter_3.Y);
            this.bleedIcoCharacter_3 = new GUIElement("Icons\\Bleed_Icon", (int)icoPositionCharacter_3.X, (int)icoPositionCharacter_3.Y);
            this.blessedIcoCharacter_3 = new GUIElement("Icons\\Blessed_Icon", (int)icoPositionCharacter_3.X, (int)icoPositionCharacter_3.Y);
            this.burnIcoCharacter_3 = new GUIElement("Icons\\Burn_Icon", (int)icoPositionCharacter_3.X, (int)icoPositionCharacter_3.Y);
            this.haloIcoCharacter_3 = new GUIElement("Icons\\Halo_Icon", (int)icoPositionCharacter_3.X, (int)icoPositionCharacter_3.Y);
            this.toxicIcoCharacter_3 = new GUIElement("Icons\\Toxic_Icon", (int)icoPositionCharacter_3.X, (int)icoPositionCharacter_3.Y);

            this.mindBlownIcoCharacter_4 = new GUIElement("Icons\\Mindblown_Icon", (int)icoPositionCharacter_4.X, (int)icoPositionCharacter_4.Y);
            this.bleedIcoCharacter_4 = new GUIElement("Icons\\Bleed_Icon", (int)icoPositionCharacter_4.X, (int)icoPositionCharacter_4.Y);
            this.blessedIcoCharacter_4 = new GUIElement("Icons\\Blessed_Icon", (int)icoPositionCharacter_4.X, (int)icoPositionCharacter_4.Y);
            this.burnIcoCharacter_4 = new GUIElement("Icons\\Burn_Icon", (int)icoPositionCharacter_4.X, (int)icoPositionCharacter_4.Y);
            this.haloIcoCharacter_4 = new GUIElement("Icons\\Halo_Icon", (int)icoPositionCharacter_4.X, (int)icoPositionCharacter_4.Y);
            this.toxicIcoCharacter_4 = new GUIElement("Icons\\Toxic_Icon", (int)icoPositionCharacter_4.X, (int)icoPositionCharacter_4.Y);


            this.mindBlownIcoEnemy_1 = new GUIElement("Icons\\Mindblown_Icon", (int)icoPositionEnemy_1.X, (int)icoPositionEnemy_1.Y);
            this.bleedIcoEnemy_1 = new GUIElement("Icons\\Bleed_Icon", (int)icoPositionEnemy_1.X, (int)icoPositionEnemy_1.Y);
            this.blessedIcoEnemy_1 = new GUIElement("Icons\\Blessed_Icon", (int)icoPositionEnemy_1.X, (int)icoPositionEnemy_1.Y);
            this.burnIcoEnemy_1 = new GUIElement("Icons\\Burn_Icon", (int)icoPositionEnemy_1.X, (int)icoPositionEnemy_1.Y);
            this.haloIcoEnemy_1 = new GUIElement("Icons\\Halo_Icon", (int)icoPositionEnemy_1.X, (int)icoPositionEnemy_1.Y);
            this.toxicIcoEnemy_1 = new GUIElement("Icons\\Toxic_Icon", (int)icoPositionEnemy_1.X, (int)icoPositionEnemy_1.Y);

            this.mindBlownIcoEnemy_2 = new GUIElement("Icons\\Mindblown_Icon", (int)icoPositionEnemy_2.X, (int)icoPositionEnemy_2.Y);
            this.bleedIcoEnemy_2 = new GUIElement("Icons\\Bleed_Icon", (int)icoPositionEnemy_2.X, (int)icoPositionEnemy_2.Y);
            this.blessedIcoEnemy_2 = new GUIElement("Icons\\Blessed_Icon", (int)icoPositionEnemy_2.X, (int)icoPositionEnemy_2.Y);
            this.burnIcoEnemy_2 = new GUIElement("Icons\\Burn_Icon", (int)icoPositionEnemy_2.X, (int)icoPositionEnemy_2.Y);
            this.haloIcoEnemy_2 = new GUIElement("Icons\\Halo_Icon", (int)icoPositionEnemy_2.X, (int)icoPositionEnemy_2.Y);
            this.toxicIcoEnemy_2 = new GUIElement("Icons\\Toxic_Icon", (int)icoPositionEnemy_2.X, (int)icoPositionEnemy_2.Y);

            this.mindBlownIcoEnemy_3 = new GUIElement("Icons\\Mindblown_Icon", (int)icoPositionEnemy_3.X, (int)icoPositionEnemy_3.Y);
            this.bleedIcoEnemy_3 = new GUIElement("Icons\\Bleed_Icon", (int)icoPositionEnemy_3.X, (int)icoPositionEnemy_3.Y);
            this.blessedIcoEnemy_3 = new GUIElement("Icons\\Blessed_Icon", (int)icoPositionEnemy_3.X, (int)icoPositionEnemy_3.Y);
            this.burnIcoEnemy_3 = new GUIElement("Icons\\Burn_Icon", (int)icoPositionEnemy_3.X, (int)icoPositionEnemy_3.Y);
            this.haloIcoEnemy_3 = new GUIElement("Icons\\Halo_Icon", (int)icoPositionEnemy_3.X, (int)icoPositionEnemy_3.Y);
            this.toxicIcoEnemy_3 = new GUIElement("Icons\\Toxic_Icon", (int)icoPositionEnemy_3.X, (int)icoPositionEnemy_3.Y);

            this.mindBlownIcoEnemy_4 = new GUIElement("Icons\\Mindblown_Icon", (int)icoPositionEnemy_4.X, (int)icoPositionEnemy_4.Y);
            this.bleedIcoEnemy_4 = new GUIElement("Icons\\Bleed_Icon", (int)icoPositionEnemy_4.X, (int)icoPositionEnemy_4.Y);
            this.blessedIcoEnemy_4 = new GUIElement("Icons\\Blessed_Icon", (int)icoPositionEnemy_4.X, (int)icoPositionEnemy_4.Y);
            this.burnIcoEnemy_4 = new GUIElement("Icons\\Burn_Icon", (int)icoPositionEnemy_4.X, (int)icoPositionEnemy_4.Y);
            this.haloIcoEnemy_4 = new GUIElement("Icons\\Halo_Icon", (int)icoPositionEnemy_4.X, (int)icoPositionEnemy_4.Y);
            this.toxicIcoEnemy_4 = new GUIElement("Icons\\Toxic_Icon", (int)icoPositionEnemy_4.X, (int)icoPositionEnemy_4.Y);



            mindBlownIcoCharacter_1.LoadContent(content);
            bleedIcoCharacter_1.LoadContent(content);
            blessedIcoCharacter_1.LoadContent(content);
            burnIcoCharacter_1.LoadContent(content);
            haloIcoCharacter_1.LoadContent(content);
            toxicIcoCharacter_1.LoadContent(content);

            mindBlownIcoCharacter_2.LoadContent(content);
            bleedIcoCharacter_2.LoadContent(content);
            blessedIcoCharacter_2.LoadContent(content);
            burnIcoCharacter_2.LoadContent(content);
            haloIcoCharacter_2.LoadContent(content);
            toxicIcoCharacter_2.LoadContent(content);

            mindBlownIcoCharacter_3.LoadContent(content);
            bleedIcoCharacter_3.LoadContent(content);
            blessedIcoCharacter_3.LoadContent(content);
            burnIcoCharacter_3.LoadContent(content);
            haloIcoCharacter_3.LoadContent(content);
            toxicIcoCharacter_3.LoadContent(content);

            mindBlownIcoCharacter_4.LoadContent(content);
            bleedIcoCharacter_4.LoadContent(content);
            blessedIcoCharacter_4.LoadContent(content);
            burnIcoCharacter_4.LoadContent(content);
            haloIcoCharacter_4.LoadContent(content);
            toxicIcoCharacter_4.LoadContent(content);

            mindBlownIcoEnemy_1.LoadContent(content);
            bleedIcoEnemy_1.LoadContent(content);
            blessedIcoEnemy_1.LoadContent(content);
            burnIcoEnemy_1.LoadContent(content);
            haloIcoEnemy_1.LoadContent(content);
            toxicIcoEnemy_1.LoadContent(content);

            mindBlownIcoEnemy_2.LoadContent(content);
            bleedIcoEnemy_2.LoadContent(content);
            blessedIcoEnemy_2.LoadContent(content);
            burnIcoEnemy_2.LoadContent(content);
            haloIcoEnemy_2.LoadContent(content);
            toxicIcoEnemy_2.LoadContent(content);

            mindBlownIcoEnemy_3.LoadContent(content);
            bleedIcoEnemy_3.LoadContent(content);
            blessedIcoEnemy_3.LoadContent(content);
            burnIcoEnemy_3.LoadContent(content);
            haloIcoEnemy_3.LoadContent(content);
            toxicIcoEnemy_3.LoadContent(content);

            mindBlownIcoEnemy_4.LoadContent(content);
            bleedIcoEnemy_4.LoadContent(content);
            blessedIcoEnemy_4.LoadContent(content);
            burnIcoEnemy_4.LoadContent(content);
            haloIcoEnemy_4.LoadContent(content);
            toxicIcoEnemy_4.LoadContent(content);

            foreach (Character character in this.FightCadre)
            {

                if (character.GetType() == typeof(PartyMember))
                {

                    if (charCounter == 0)
                    {
                        this.Character1Name = new TextElement(character.Name, (int)this.targetPosition_1.X, (int)this.targetPosition_1.Y, true);
                        this.Character1Name.LoadContent(content);
                        this.Character1Name.tclickEvent += this.onClickTarget;
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.character1skill1 = new TextElement(skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true);
                                this.character1skill1.LoadContent(content);
                                this.character1skill1.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                this.character1skill2 = new TextElement(skill.Name, (int)this.skillPosition_2.X, (int)this.skillPosition_2.Y, true);
                                this.character1skill2.LoadContent(content);
                                this.character1skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character1skill3 = new TextElement(skill.Name, (int)this.skillPosition_3.X, (int)this.skillPosition_3.Y, true);
                                this.character1skill3.LoadContent(content);
                                this.character1skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character1skill4 = new TextElement(skill.Name, (int)this.skillPosition_4.X, (int)this.skillPosition_4.Y, true);
                                this.character1skill4.LoadContent(content);
                                this.character1skill4.tclickEvent += this.OnClickSkill;
                            }
                            skillCounter++;
                        }
                    }
                    if (charCounter == 1)
                    {
                        this.Character2Name = new TextElement(character.Name, (int)this.targetPosition_2.X, (int)this.targetPosition_2.Y, true);
                        this.Character2Name.LoadContent(content);
                        this.Character2Name.tclickEvent += this.onClickTarget;
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.character2skill1 = new TextElement(skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true);
                                this.character2skill1.LoadContent(content);
                                this.character2skill1.tclickEvent += this.OnClickSkill;
                                
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
                    {
                        this.Character3Name = new TextElement(character.Name, (int)this.targetPosition_3.X, (int)this.targetPosition_3.Y, true);
                        this.Character3Name.LoadContent(content);
                        this.Character3Name.tclickEvent += this.onClickTarget;

                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.character3skill1 = new TextElement(skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true);
                                this.character3skill1.LoadContent(content);
                                this.character3skill1.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                this.character3skill2 = new TextElement(skill.Name, (int)this.skillPosition_2.X, (int)this.skillPosition_2.Y, true);
                                this.character3skill2.LoadContent(content);
                                this.character3skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character3skill3 = new TextElement(skill.Name, (int)this.skillPosition_3.X, (int)this.skillPosition_3.Y, true);
                                this.character3skill3.LoadContent(content);
                                this.character3skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character3skill4 = new TextElement(skill.Name, (int)this.skillPosition_4.X, (int)this.skillPosition_4.Y, true);
                                this.character3skill4.LoadContent(content);
                                this.character3skill4.tclickEvent += this.OnClickSkill;
                            }

                            skillCounter++;
                        }
                    }
                    if (charCounter == 3)
                    {
                        this.Character4Name = new TextElement(character.Name, (int)this.targetPosition_4.X, (int)this.targetPosition_4.Y, true);
                        this.Character4Name.LoadContent(content);
                        this.Character4Name.tclickEvent += this.onClickTarget;
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.character4skill1 = new TextElement(skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true);
                                this.character4skill1.LoadContent(content);
                                this.character4skill1.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                this.character4skill2 = new TextElement(skill.Name, (int)this.skillPosition_2.X, (int)this.skillPosition_2.Y, true);
                                this.character4skill2.LoadContent(content);
                                this.character4skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character4skill3 = new TextElement(skill.Name, (int)this.skillPosition_3.X, (int)this.skillPosition_3.Y, true);
                                this.character4skill3.LoadContent(content);
                                this.character4skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character4skill4 = new TextElement(skill.Name, (int)this.skillPosition_4.X, (int)this.skillPosition_4.Y, true);
                                this.character4skill4.LoadContent(content);
                                this.character4skill4.tclickEvent += this.OnClickSkill;
                            }
                            skillCounter++;
                        }
                    }
                    skillCounter = 0;
                    charCounter++;
                }
            }
            foreach (Enemy enemy in this.Enemies)
            {
                if (enemieCounter == 0)
                {
                    this.enemy1Name = new TextElement(enemy.Name, (int) this.targetPosition_1.X, (int) this.targetPosition_1.Y, true);
                    this.enemy1Name.LoadContent(content);
                    this.enemy1Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 1)
                {
                    this.enemy2Name = new TextElement(enemy.Name, (int) this.targetPosition_2.X, (int) this.targetPosition_2.Y, true);
                    this.enemy2Name.LoadContent(content);
                    this.enemy2Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 2)
                {
                    this.enemy3Name = new TextElement(enemy.Name, (int) this.targetPosition_3.X, (int) this.targetPosition_3.Y, true);
                    this.enemy3Name.LoadContent(content);
                    this.enemy3Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 3)
                {
                    this.enemy4Name = new TextElement(enemy.Name, (int) this.targetPosition_4.X, (int) this.targetPosition_4.Y, true);
                    this.enemy4Name.LoadContent(content);
                    this.enemy4Name.tclickEvent += this.onClickTarget;
                }
                enemieCounter++;
            }
        }

        public void LoadAnimatedSkillsFromPartymember(Character actualTarget, string targetName)
        {
            if (actualTarget.GetType() == typeof(Enemy))
            {
                if (enemy1Name != null)
                {
                    if (targetName == enemy1Name.SkillName)
                    {
                        Hit.LoadContent(hitAnimation, enemyPosition_1);
                    }
                }
                if (enemy2Name != null)
                {
                    if (targetName == enemy2Name.SkillName)
                    {
                        Hit.LoadContent(hitAnimation, enemyPosition_2);
                    }
                }
                if (enemy3Name != null)
                {
                    if (targetName == enemy3Name.SkillName)
                    {
                        Hit.LoadContent(hitAnimation, enemyPosition_3);
                    }
                }
                if (enemy4Name != null)
                {
                    if (targetName == enemy4Name.SkillName)
                    {
                        Hit.LoadContent(hitAnimation, enemyPosition_4);
                    }
                }
            }
            else
            {
                if (Character1Name != null)
                {
                    if (targetName == Character1Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, characterPosition_1);
                    }
                }
                if (Character2Name != null)
                {
                    if (targetName == Character2Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, characterPosition_2);
                    }
                }
                if (Character3Name != null)
                {
                    if (targetName == Character3Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, characterPosition_3);
                    }
                }
                if (Character4Name != null)
                {
                    if (targetName == Character4Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, characterPosition_4);
                    }
                }
            }
        }

        public void LoadAnimatedSkillsFromEnemies(Character actualTarget, string targetName)
        {
            if (actualTarget.GetType() == typeof(Enemy))
            {
                if (enemy1Name != null)
                {
                    if (targetName == enemy1Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, enemyPosition_1);
                    }
                }
                if (enemy2Name != null)
                {
                    if (targetName == enemy2Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, enemyPosition_2);
                    }
                }
                if (enemy3Name != null)
                {
                    if (targetName == enemy3Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, enemyPosition_3);
                    }
                }
                if (enemy4Name != null)
                {
                    if (targetName == enemy4Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, enemyPosition_4);
                    }
                }
            }
            else
            {
                if (Character1Name != null)
                {
                    if (targetName == Character1Name.SkillName)
                    {
                        Hit.LoadContent(hitAnimation, characterPosition_1);
                    }
                }
                if (Character2Name != null)
                {
                    if (targetName == Character2Name.SkillName)
                    {
                        Hit.LoadContent(hitAnimation, characterPosition_2);
                    }
                }
                if (Character3Name != null)
                {
                    if (targetName == Character3Name.SkillName)
                    {
                        Hit.LoadContent(hitAnimation, characterPosition_3);
                    }
                }
                if (Character4Name != null)
                {
                    if (targetName == Character4Name.SkillName)
                    {
                        Hit.LoadContent(hitAnimation, characterPosition_4);
                    }
                }
            }
        }

        //Führt aus was beim Klick auf ein Ziel passieren soll
        public void onClickTarget(String target)
        {
            Click.Play(1.0f, 0.0f, 0.0f);
            this.targetClicked = false;
            foreach (Character character in this.FightClub)
            {
                if (character.Name.ToLower() == target.ToLower())
                {
                    this.activeSkill.Execute(this.activeChar, new List<Character> { character });
                    this.skillClicked = false;
                    this.targetClicked = true;
                    this.singleTargetEnemies = false;
                    this.singleTargetParty = false;
                    LoadAnimatedSkillsFromPartymember(character, target);
                }
                if (activeChar.Name == Character1Name.SkillName)
                {
                    activeChar.LoadContent(charAttackAnimation_1, characterPosition_1);
                    charAttackAnimation_1.active = true;
                }
                else if (activeChar.Name == Character2Name.SkillName)
                {
                    activeChar.LoadContent(charAttackAnimation_2, characterPosition_2);
                    charAttackAnimation_2.active = true;
                }
                else if (activeChar.Name == Character3Name.SkillName)
                {
                    activeChar.LoadContent(charAttackAnimation_3, characterPosition_3);
                    charAttackAnimation_3.active = true;
                }
                else if (activeChar.Name == Character4Name.SkillName)
                {
                    activeChar.LoadContent(charAttackAnimation_4, characterPosition_4);
                    charAttackAnimation_4.active = true;
                }
            }
        }

        //Führt aus was beim Klick auf einen Skill passieren soll
        public void OnClickSkill(String skillName)
        {
            Click.Play(1.0f,0.0f,0.0f);
            // Liste der Ziele auf die der Skill ausgeführt werden soll
            List<Character> targets = new List<Character>();

            //Damit anstelle der Skills die möglichen Ziele gezeichnet werden, wird skillClicked auf true gesetzt und targetClicked auf false
            this.skillClicked = true;
            this.targetClicked = false;

            //Skill wird überprüft
            foreach (Skill skill in this.activeChar.Skills)
            {
                if(skillName == skill.Name)
                {

                    //Wenn der Skill auf einzelne Charaktere zielt wird das ausgeführt
                    if (skill.Target.ToLower() == "Single".ToLower())
                    {
                        //Wenn der Skill sich auf PartyMember bezieht soll singleTarget True gesetzt werden
                        if (skill.AreaOfEffect.ToLower() == "Party".ToLower())
                        {
                            Thread.Sleep(120);
                            this.singleTargetParty = true;
                            this.activeSkill = skill;
                        }

                        // Sonst wird über prüft ob der Skill für einen Gegner bestimmt ist wenn ja dann soll singleTargetEnemies True gesetzt werden
                        else if (skill.AreaOfEffect.ToLower() == "Enemy".ToLower())
                        {
                            Thread.Sleep(120);
                            this.singleTargetEnemies = true;
                            this.activeSkill = skill;
                        }
                    }
                    else if (skill.Target.ToLower() == "Group".ToLower())
                    {
                        //Wenn der Skill sich auf eine Gruppe bezieht wird der skill ausgeführt dabei wird differenziert zwischen party und enemys
                        if (skill.AreaOfEffect.ToLower() == "Party".ToLower())
                        {
                            foreach (PartyMember member in this.FightCadre)
                            {
                                targets.Add(member);
                            }

                            skill.Execute(this.activeChar, targets);
                            this.targetClicked = true;
                            skillClicked = true;
                            Thread.Sleep(120);
                            this.StartNextTurn();
                        }
                        else if (skill.AreaOfEffect.ToLower() == "Enemy".ToLower())
                        {

                            foreach (Enemy enemy in this.Enemies)
                            {
                                targets.Add(enemy);
                            }
                            skill.Execute(this.activeChar, targets);
                            this.targetClicked = true;
                            skillClicked = true;
                            Thread.Sleep(120);
                            this.StartNextTurn();
                        }
                    }
                    break;
                }
            }
            if (skillName == "Ausruhen")
            {
                if (Character1Name != null)
                {
                    if (activeChar.Name == Character1Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, characterPosition_1);
                    }
                }
                if (Character2Name != null)
                {
                    if (activeChar.Name == Character2Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, characterPosition_2);
                    }
                }
                if (Character3Name != null)
                {
                    if (activeChar.Name == Character3Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, characterPosition_3);
                    }
                }
                if (Character4Name != null)
                {
                    if (activeChar.Name == Character4Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, characterPosition_4);
                    }
                }
                if (enemy1Name != null)
                {
                    if (activeChar.Name == enemy1Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, enemyPosition_1);
                    }
                }
                if (enemy2Name != null)
                {
                    if (activeChar.Name == enemy2Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, enemyPosition_2);
                    }
                }
                if (enemy3Name != null)
                {
                    if (activeChar.Name == enemy3Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, enemyPosition_3);
                    }
                }
                if (enemy4Name != null)
                {
                    if (activeChar.Name == enemy4Name.SkillName)
                    {
                        Heal.LoadContent(healAnimation, enemyPosition_4);
                    }
                }
                healAnimation.active = true;
                this.activeChar.RestSkill.Execute(activeChar, new List<Character> { activeChar });
                targetClicked = true;
                Thread.Sleep(120);
                this.StartNextTurn();
            }
            if(skillName == "Angriff")
            {
                activeSkill = this.activeChar.AttackSkill;
                Thread.Sleep(120);
                this.singleTargetEnemies = true;
            }
            
        }

        public void UpdateAnimatedSkillsFromPartymember()
        {
            if (!healAnimation.active && healAnimation.Done)
            {
                hitAnimation.Done = false;
            }
            if (!hitAnimation.active && hitAnimation.Done)
            {
                hitAnimation.Done = false;
            }
            if (!charAttackAnimation_1.active && charAttackAnimation_1.Done)
            {
                Punch.Play();
                hitAnimation.active = true;
                this.FightCadre.ElementAt<PartyMember>(0).LoadContent(charStandardAnimation_1, this.characterPosition_1);
                this.StartNextTurn();
                charAttackAnimation_1.Done = false;
                AllowDeathAnimation = true;
            }
            if (!charAttackAnimation_2.active && charAttackAnimation_2.Done)
            {
                Punch.Play();
                hitAnimation.active = true;
                this.StartNextTurn();
                this.FightCadre.ElementAt<PartyMember>(1).LoadContent(charStandardAnimation_2, this.characterPosition_2);
                charAttackAnimation_2.Done = false;
                AllowDeathAnimation = true;
            }
            if (!charAttackAnimation_3.active && charAttackAnimation_3.Done)
            {
                Punch.Play();
                hitAnimation.active = true;
                this.StartNextTurn();
                this.FightCadre.ElementAt<PartyMember>(2).LoadContent(charStandardAnimation_3, this.characterPosition_3);
                charAttackAnimation_3.Done = false;
                AllowDeathAnimation = true;
            }
            if (!charAttackAnimation_4.active && charAttackAnimation_4.Done)
            {
                Punch.Play();
                hitAnimation.active = true;
                this.StartNextTurn();
                this.FightCadre.ElementAt<PartyMember>(3).LoadContent(charStandardAnimation_4, this.characterPosition_4);
                charAttackAnimation_4.Done = false;
                AllowDeathAnimation = true;
            }

            if (!enemyAttackAnimation_1.active && enemyAttackAnimation_1.Done)
            {
                Punch.Play();
                hitAnimation.active = true;
                this.StartNextTurn();
                this.Enemies.ElementAt<Enemy>(0).LoadContent(enemyStandardAnimation_1, this.enemyPosition_1);
                enemyAttackAnimation_1.Done = false;
                AllowDeathAnimation = true;
            }
            if (!enemyAttackAnimation_2.active && enemyAttackAnimation_2.Done)
            {
                Punch.Play();
                hitAnimation.active = true;
                this.StartNextTurn();
                this.Enemies.ElementAt<Enemy>(1).LoadContent(enemyStandardAnimation_2, this.enemyPosition_2);
                enemyAttackAnimation_2.Done = false;
                AllowDeathAnimation = true;
            }
            if (!enemyAttackAnimation_3.active && enemyAttackAnimation_3.Done)
            {
                Punch.Play();
                hitAnimation.active = true;
                this.StartNextTurn();
                this.Enemies.ElementAt<Enemy>(2).LoadContent(enemyStandardAnimation_3, this.enemyPosition_3);
                enemyAttackAnimation_3.Done = false;
                AllowDeathAnimation = true;
            }
            if (!enemyAttackAnimation_4.active && enemyAttackAnimation_4.Done)
            {
                Punch.Play();
                hitAnimation.active = true;
                this.StartNextTurn();
                this.Enemies.ElementAt<Enemy>(3).LoadContent(enemyStandardAnimation_4, this.enemyPosition_4);
                enemyAttackAnimation_4.Done = false;
                AllowDeathAnimation = true;
            }
        }
        public void UpdateDeathAnimations()
        {
            if (AllowDeathAnimation)
            {
                AllowDeathAnimation = false;
                if (FightCadre.Count == 1)
                {
                    if (FightCadre.ElementAt<PartyMember>(0).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(0).LoadContent(charDeathAnimation_1, this.characterPosition_1);
                    }
                }
                if (FightCadre.Count == 2)
                {
                    if (FightCadre.ElementAt<PartyMember>(0).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(0).LoadContent(charDeathAnimation_1, this.characterPosition_1);
                    }
                    if (FightCadre.ElementAt<PartyMember>(1).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(1).LoadContent(charDeathAnimation_2, this.characterPosition_2);
                    }
                }
                if (FightCadre.Count == 3)
                {
                    if (FightCadre.ElementAt<PartyMember>(0).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(0).LoadContent(charDeathAnimation_1, this.characterPosition_1);
                    }
                    if (FightCadre.ElementAt<PartyMember>(1).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(1).LoadContent(charDeathAnimation_2, this.characterPosition_2);
                    }
                    if (FightCadre.ElementAt<PartyMember>(2).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(2).LoadContent(charDeathAnimation_3, this.characterPosition_3);
                    }
                }
                if (FightCadre.Count == 4)
                {
                    if (FightCadre.ElementAt<PartyMember>(0).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(0).LoadContent(charDeathAnimation_1, this.characterPosition_1);
                    }
                    if (FightCadre.ElementAt<PartyMember>(1).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(1).LoadContent(charDeathAnimation_2, this.characterPosition_2);
                    }
                    if (FightCadre.ElementAt<PartyMember>(2).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(2).LoadContent(charDeathAnimation_3, this.characterPosition_3);
                    }
                    if (FightCadre.ElementAt<PartyMember>(3).Life <= 0)
                    {
                        this.FightCadre.ElementAt<Character>(3).LoadContent(charDeathAnimation_4, this.characterPosition_4);
                    }
                }

                if (Enemies.Count == 1)
                {
                    if (Enemies.ElementAt<Enemy>(0).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(0).LoadContent(enemyDeathAnimation_1, this.enemyPosition_1);
                    }
                }
                if (Enemies.Count == 2)
                {
                    if (Enemies.ElementAt<Enemy>(0).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(0).LoadContent(enemyDeathAnimation_1, this.enemyPosition_1);
                    }
                    if (Enemies.ElementAt<Enemy>(1).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(1).LoadContent(enemyDeathAnimation_2, this.enemyPosition_2);
                    }
                }
                if (Enemies.Count == 3)
                {
                    if (Enemies.ElementAt<Enemy>(0).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(0).LoadContent(enemyDeathAnimation_1, this.enemyPosition_1);
                    }
                    if (Enemies.ElementAt<Enemy>(1).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(1).LoadContent(enemyDeathAnimation_2, this.enemyPosition_2);
                    }
                    if (Enemies.ElementAt<Enemy>(2).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(2).LoadContent(enemyDeathAnimation_3, this.enemyPosition_3);
                    }
                }
                if (Enemies.Count == 4)
                {
                    if (Enemies.ElementAt<Enemy>(0).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(0).LoadContent(enemyDeathAnimation_1, this.enemyPosition_1);
                    }
                    if (Enemies.ElementAt<Enemy>(1).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(1).LoadContent(enemyDeathAnimation_2, this.enemyPosition_2);
                    }
                    if (Enemies.ElementAt<Enemy>(2).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(2).LoadContent(enemyDeathAnimation_3, this.enemyPosition_3);
                    }
                    if (Enemies.ElementAt<Enemy>(3).Life == 0)
                    {
                        this.Enemies.ElementAt<Enemy>(3).LoadContent(enemyDeathAnimation_4, this.enemyPosition_4);
                    }
                }
            }
        }
        //führt die Logik aus wie beispielsweise die Steuerung oder das Abspielen der Animationen
        public void Update(GameTime gameTime)
        {
            controls.Update();
            Heal.Update(gameTime);
            Hit.Update(gameTime);

            UpdateAnimatedSkillsFromPartymember();
            UpdateDeathAnimations();
            
            if (FightCadre.All(member => member.Life == 0))
            {
                GameOver.Update();
            }
            else if (Enemies.All(enemie => enemie.Life == 0))
            {
                battleEvaluation.Update(gameTime);
            }
            else
            {
                //Die KI wird ausgeführt wenn es sich bei dem Aktiven Character um einen Gegner handelt
                if (activeChar.GetType() == typeof(Enemy))
                {
                    ((Enemy)this.activeChar).PerformAI(this.FightCadre, this.Enemies.Cast<Character>().ToList());
                    if (((Enemy)this.activeChar).Targets.Count == 1)
                    {
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(0), ((Enemy)this.activeChar).TargetName);
                    }
                    if (((Enemy)this.activeChar).Targets.Count == 2)
                    {
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(0), ((Enemy)this.activeChar).TargetName);
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(1), ((Enemy)this.activeChar).TargetName);
                    }
                    if (((Enemy)this.activeChar).Targets.Count == 3)
                    {
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(0), ((Enemy)this.activeChar).TargetName);
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(1), ((Enemy)this.activeChar).TargetName);
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(2), ((Enemy)this.activeChar).TargetName);
                    }
                    if (((Enemy)this.activeChar).Targets.Count == 4)
                    {
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(0), ((Enemy)this.activeChar).TargetName);
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(1), ((Enemy)this.activeChar).TargetName);
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(2), ((Enemy)this.activeChar).TargetName);
                        LoadAnimatedSkillsFromEnemies(((Enemy)this.activeChar).Targets.ElementAt<Character>(3), ((Enemy)this.activeChar).TargetName);
                    }
                    if (activeChar.Name == enemy1Name.SkillName)
                    {
                        activeChar.LoadContent(enemyAttackAnimation_1, enemyPosition_1);
                        enemyAttackAnimation_1.active = true;
                    }
                    else if (activeChar.Name == enemy2Name.SkillName)
                    {
                        activeChar.LoadContent(enemyAttackAnimation_2, enemyPosition_2);
                        enemyAttackAnimation_2.active = true;
                    }
                    else if (activeChar.Name == enemy3Name.SkillName)
                    {
                        activeChar.LoadContent(enemyAttackAnimation_3, enemyPosition_3);
                        enemyAttackAnimation_3.active = true;
                    }
                    else if (activeChar.Name == enemy4Name.SkillName)
                    {
                        activeChar.LoadContent(enemyAttackAnimation_4, enemyPosition_4);
                        enemyAttackAnimation_4.active = true;
                    }
                }
                //führt ein Update der Animationen und Texte aus wenn es sich bei dem aktiven Character um ein Gruppenmitglied handelt
                else
                {
                    if (!skillClicked && !charAttackAnimation_1.active && !charAttackAnimation_2.active && !charAttackAnimation_3.active && !charAttackAnimation_4.active && !enemyAttackAnimation_1.active && !enemyAttackAnimation_2.active && !enemyAttackAnimation_3.active && !enemyAttackAnimation_4.active)
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
                                if (character1skill1 != null)
                                {
                                    this.character1skill1.Update();
                                }
                                if (character1skill2 != null)
                                {
                                    this.character1skill2.Update();
                                }
                                if (character1skill3 != null)
                                {
                                    this.character1skill3.Update();
                                }
                                if (character1skill4 != null)
                                {
                                    this.character1skill4.Update();
                                }
                            }
                            countFightCadre = 0;
                        }
                        if (countFightCadre == 1)
                        {
                            if (!this.skillClicked)
                            {
                                if (character2skill1 != null)
                                {
                                    this.character2skill1.Update();
                                }
                                if (character2skill2 != null)
                                {
                                    this.character2skill2.Update();
                                }
                                if (character2skill3 != null)
                                {
                                    this.character2skill3.Update();
                                }
                                if (character2skill4 != null)
                                {
                                    this.character2skill4.Update();
                                }
                            }
                            countFightCadre = 0;
                        }
                        if (countFightCadre == 2)
                        {
                            if (!this.skillClicked)
                            {
                                if (character3skill1 != null)
                                {
                                    this.character1skill1.Update();
                                }
                                if (character3skill2 != null)
                                {
                                    this.character3skill2.Update();
                                }
                                if (character3skill3 != null)
                                {
                                    this.character3skill3.Update();
                                }
                                if (character3skill4 != null)
                                {
                                    this.character3skill4.Update();
                                }
                            }
                            countFightCadre = 0;
                        }
                        if (countFightCadre == 3)
                        {
                            if (!this.skillClicked)
                            {
                                if (character4skill1 != null)
                                {
                                    this.character4skill1.Update();
                                }
                                if (character4skill2 != null)
                                {
                                    this.character4skill2.Update();
                                }
                                if (character4skill3 != null)
                                {
                                    this.character4skill3.Update();
                                }
                                if (character4skill4 != null)
                                {
                                    this.character4skill4.Update();
                                }
                            }
                            countFightCadre = 0;
                        }
                        this.attackSkill.Update();
                        this.restSkill.Update();
                    }

                    if (!targetClicked)
                    {
                        if (singleTargetParty)
                        {
                            if (Character1Name != null)
                            {
                                this.Character1Name.Update();
                            }
                            if (Character2Name != null)
                            {
                                this.Character2Name.Update();
                            }
                            if (Character3Name != null)
                            {
                                this.Character3Name.Update();
                            }
                            if (Character4Name != null)
                            {
                                this.Character4Name.Update();
                            }
                        }
                        else if (singleTargetEnemies)
                        {
                            if (enemy1Name != null)
                            {
                                this.enemy1Name.Update();
                            }
                            if (enemy2Name != null)
                            {
                                this.enemy2Name.Update();
                                if (enemy3Name != null)
                                {
                                    this.enemy3Name.Update();
                                }
                                if (enemy4Name != null)
                                {
                                    this.enemy4Name.Update();
                                }
                                Back.Update();
                            }
                        }
                    }
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

        //Zeichnet die Icons
        public void DrawIcons(SpriteBatch spriteBatch)
        {
            foreach (Character character in FightClub)
            {
                foreach (IStatuseffect effect in character.Statuseffects)
                {
                    if (effect.GetType() == typeof(Bleeding))
                    {
                        if (character.Name.Equals(Character1Name.SkillName))
                        {
                            bleedIcoCharacter_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character2Name.SkillName))
                        {
                            bleedIcoCharacter_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character3Name.SkillName))
                        {
                            bleedIcoCharacter_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character4Name.SkillName))
                        {
                            bleedIcoCharacter_4.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy1Name.SkillName))
                        {
                            bleedIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy2Name.SkillName))
                        {
                            bleedIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy3Name.SkillName))
                        {
                            bleedIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy4Name.SkillName))
                        {
                            bleedIcoEnemy_4.Draw(spriteBatch);
                        }
                    }

                    else if (effect.GetType() == typeof(Mindblown))
                    {
                        if (character.Name.Equals(Character1Name.SkillName))
                        {
                            mindBlownIcoCharacter_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character2Name.SkillName))
                        {
                            mindBlownIcoCharacter_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character3Name.SkillName))
                        {
                            mindBlownIcoCharacter_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character4Name.SkillName))
                        {
                            mindBlownIcoCharacter_4.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy1Name.SkillName))
                        {
                            mindBlownIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy2Name.SkillName))
                        {
                            mindBlownIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy3Name.SkillName))
                        {
                            mindBlownIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy4Name.SkillName))
                        {
                            mindBlownIcoEnemy_4.Draw(spriteBatch);
                        }
                    }
                    else if (effect.GetType() == typeof(Blessing))
                    {
                        if (character.Name.Equals(Character1Name.SkillName))
                        {
                            blessedIcoCharacter_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character2Name.SkillName))
                        {
                            blessedIcoCharacter_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character3Name.SkillName))
                        {
                            blessedIcoCharacter_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character4Name.SkillName))
                        {
                            blessedIcoCharacter_4.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy1Name.SkillName))
                        {
                            blessedIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy2Name.SkillName))
                        {
                            blessedIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy3Name.SkillName))
                        {
                            blessedIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy4Name.SkillName))
                        {
                            blessedIcoEnemy_4.Draw(spriteBatch);
                        }
                    }
                    else if (effect.GetType() == typeof(HasHalo))
                    {
                        if (character.Name.Equals(Character1Name.SkillName))
                        {
                            haloIcoCharacter_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character2Name.SkillName))
                        {
                            haloIcoCharacter_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character3Name.SkillName))
                        {
                            haloIcoCharacter_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character4Name.SkillName))
                        {
                            haloIcoCharacter_4.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy1Name.SkillName))
                        {
                            haloIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy2Name.SkillName))
                        {
                            haloIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy3Name.SkillName))
                        {
                            haloIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy4Name.SkillName))
                        {
                            haloIcoEnemy_4.Draw(spriteBatch);
                        }
                    }
                    else if (effect.GetType() == typeof(Poisoned))
                    {
                        if (character.Name.Equals(Character1Name.SkillName))
                        {
                            toxicIcoCharacter_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character2Name.SkillName))
                        {
                            toxicIcoCharacter_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character3Name.SkillName))
                        {
                            toxicIcoCharacter_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character4Name.SkillName))
                        {
                            toxicIcoCharacter_4.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy1Name.SkillName))
                        {
                            toxicIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy2Name.SkillName))
                        {
                            toxicIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy3Name.SkillName))
                        {
                            toxicIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy4Name.SkillName))
                        {
                            toxicIcoEnemy_4.Draw(spriteBatch);
                        }
                    }
                    else if (effect.GetType() == typeof(Burning))
                    {
                        if (character.Name.Equals(Character1Name.SkillName))
                        {
                            burnIcoCharacter_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character2Name.SkillName))
                        {
                            burnIcoCharacter_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character3Name.SkillName))
                        {
                            burnIcoCharacter_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Character4Name.SkillName))
                        {
                            burnIcoCharacter_4.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy1Name.SkillName))
                        {
                            burnIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy2Name.SkillName))
                        {
                            burnIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy3Name.SkillName))
                        {
                            burnIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(enemy4Name.SkillName))
                        {
                            burnIcoEnemy_4.Draw(spriteBatch);
                        }
                    }
                }
            }
        }

        //Stellt die Grafiken dar
        public void Draw(SpriteBatch spriteBatch)
        {

            Background.Draw(spriteBatch);
            if (FightCadre.All(member => member.Life == 0))
            {
                GameOver.Draw(spriteBatch);
            }
            if (Enemies.All(enemie => enemie.Life == 0))
            {
                BattleEvaluation.Draw(spriteBatch);
            }
            if (!Enemies.All(enemie => enemie.Life == 0))
            {
                if (!this.skillClicked && !charAttackAnimation_1.active && !charAttackAnimation_2.active && !charAttackAnimation_3.active && !charAttackAnimation_4.active && !enemyAttackAnimation_1.active && !enemyAttackAnimation_2.active && !enemyAttackAnimation_3.active && !enemyAttackAnimation_4.active)
                {
                    skillBox.Draw(spriteBatch);
                    for (countFightCadre = 0; countFightCadre < this.FightCadre.Count - 1; countFightCadre++)
                    {
                        if (this.FightCadre.ElementAt(countFightCadre) == this.activeChar)
                        break;
                    }

                    if (countFightCadre == 0)
                    {
                        if (character1skill1 != null)
                        {
                            this.character1skill1.Draw(spriteBatch);
                        }
                        if (character1skill2 != null)
                        {
                            this.character1skill2.Draw(spriteBatch);
                        }
                        if (character1skill3 != null)
                        {
                            this.character1skill3.Draw(spriteBatch);
                        }
                        if (character1skill4 != null)
                        {
                            this.character1skill4.Draw(spriteBatch);
                        }
                        ActivePartymember1Arrow.Draw(spriteBatch);
                        countFightCadre = 0;
                    }
                    if (countFightCadre == 1)
                    {
                        if (character2skill1 != null)
                        {
                            this.character2skill1.Draw(spriteBatch);
                        }
                        if (character2skill2 != null)
                        {
                            this.character2skill2.Draw(spriteBatch);
                        }
                        if (character2skill3 != null)
                        {
                            this.character2skill3.Draw(spriteBatch);
                        }
                        if (character2skill4 != null)
                        {
                            this.character2skill4.Draw(spriteBatch);
                        }
                        ActivePartymember2Arrow.Draw(spriteBatch);
                        countFightCadre = 0;
                    }
                    if (countFightCadre == 2)
                    {
                        if (character3skill1 != null)
                        {
                            this.character3skill1.Draw(spriteBatch);
                        }
                        if (character3skill2 != null)
                        {
                            this.character3skill2.Draw(spriteBatch);
                        }
                        if (character3skill3 != null)
                        {
                            this.character3skill3.Draw(spriteBatch);
                        }
                        if (character3skill4 != null)
                        {
                            this.character3skill4.Draw(spriteBatch);
                        }
                        ActivePartymember3Arrow.Draw(spriteBatch);
                        countFightCadre = 0;
                    }
                    if (countFightCadre == 3)
                    {
                        if (character4skill1 != null)
                        {
                            this.character4skill1.Draw(spriteBatch);
                        }
                        if (character4skill2 != null)
                        {
                            this.character4skill2.Draw(spriteBatch);
                        }
                        if (character4skill3 != null)
                        {
                            this.character1skill3.Draw(spriteBatch);
                        }
                        if (character4skill4 != null)
                        {
                            this.character4skill4.Draw(spriteBatch);
                        }
                        ActivePartymember4Arrow.Draw(spriteBatch);
                        countFightCadre = 0;
                    }
                    this.restSkill.Draw(spriteBatch);
                    this.attackSkill.Draw(spriteBatch);
                }

                if (activeChar.GetType() != typeof(Enemy))
                {
                    if (controls.CurrentKeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Tab))
                    {
                        CharacterStatBox.Draw(spriteBatch);
                        if (this.Character1Name != null)
                        {
                            spriteBatch.DrawString(AwesomeFont, Character1Name.SkillName, new Vector2(135,110), Color.White);
                            spriteBatch.DrawString(AwesomeFont, "Leben: " + FightCadre.ElementAt<PartyMember>(0).Life + " \\ " + FightCadre.ElementAt<PartyMember>(0).FightVitality, new Vector2(215, 110), Color.White);
                            spriteBatch.DrawString(AwesomeFont, "Mana: " + FightCadre.ElementAt<PartyMember>(0).Mana + " \\ " + FightCadre.ElementAt<PartyMember>(0).FightManaPool, new Vector2(415, 110), Color.White);
                        }
                        if (this.Character2Name != null)
                        {
                            spriteBatch.DrawString(AwesomeFont, Character2Name.SkillName, new Vector2(135, 135), Color.White);
                            spriteBatch.DrawString(AwesomeFont, "Leben: " + FightCadre.ElementAt<PartyMember>(1).Life + " \\ " + FightCadre.ElementAt<PartyMember>(1).FightVitality, new Vector2(215, 135), Color.White);
                            spriteBatch.DrawString(AwesomeFont, "Mana: " + FightCadre.ElementAt<PartyMember>(1).Mana + " \\ " + FightCadre.ElementAt<PartyMember>(1).FightManaPool, new Vector2(415, 135), Color.White);
                        }
                        if (this.Character3Name != null)
                        {
                            spriteBatch.DrawString(AwesomeFont, Character3Name.SkillName, new Vector2(135, 160), Color.White);
                            spriteBatch.DrawString(AwesomeFont, "Leben: " + FightCadre.ElementAt<PartyMember>(2).Life + " \\ " + FightCadre.ElementAt<PartyMember>(2).FightVitality, new Vector2(215, 160), Color.White);
                            spriteBatch.DrawString(AwesomeFont, "Mana: " + FightCadre.ElementAt<PartyMember>(2).Mana + " \\ " + FightCadre.ElementAt<PartyMember>(2).FightManaPool, new Vector2(415, 160), Color.White);
                        }
                        if (this.Character4Name != null)
                        {
                            spriteBatch.DrawString(AwesomeFont, Character4Name.SkillName, new Vector2(135, 185), Color.White);
                            spriteBatch.DrawString(AwesomeFont, "Leben: " + FightCadre.ElementAt<PartyMember>(3).Life + " \\ " + FightCadre.ElementAt<PartyMember>(3).FightVitality, new Vector2(215, 185), Color.White);
                            spriteBatch.DrawString(AwesomeFont, "Mana: " + FightCadre.ElementAt<PartyMember>(3).Mana + " \\ " + FightCadre.ElementAt<PartyMember>(3).FightManaPool, new Vector2(415, 185), Color.White);
                        }
                    }
                    if (this.singleTargetParty)
                    {
                        
                        if (!this.targetClicked)
                        {
                            targetBox.Draw(spriteBatch);
                            Back.Draw(spriteBatch);
                            if (this.Character1Name != null)
                            {
                                this.Character1Name.Draw(spriteBatch);
                                spriteBatch.DrawString(AwesomeFont, "Leben: " + FightCadre.ElementAt<PartyMember>(0).Life + " \\ " + FightCadre.ElementAt<PartyMember>(0).FightVitality, new Vector2((int)targetPosition_1.X + 80, (int)targetPosition_1.Y), Color.White);
                                spriteBatch.DrawString(AwesomeFont, "Mana: " + FightCadre.ElementAt<PartyMember>(0).Mana + " \\ " + FightCadre.ElementAt<PartyMember>(0).FightManaPool, new Vector2((int)targetPosition_1.X + 270, (int)targetPosition_1.Y), Color.White);
                            }
                            if (this.Character2Name != null)
                            {
                                this.Character2Name.Draw(spriteBatch);
                                spriteBatch.DrawString(AwesomeFont, "Leben: " + FightCadre.ElementAt<PartyMember>(1).Life + " \\ " + FightCadre.ElementAt<PartyMember>(1).FightVitality, new Vector2((int)targetPosition_2.X + 80, (int)targetPosition_2.Y), Color.White);
                                spriteBatch.DrawString(AwesomeFont, "Mana: " + FightCadre.ElementAt<PartyMember>(1).Mana + " \\ " + FightCadre.ElementAt<PartyMember>(1).FightManaPool, new Vector2((int)targetPosition_2.X + 270, (int)targetPosition_2.Y), Color.White);
                            }
                            if (this.Character3Name != null)
                            {
                                this.Character3Name.Draw(spriteBatch);
                                spriteBatch.DrawString(AwesomeFont, "Leben: " + FightCadre.ElementAt<PartyMember>(2).Life + " \\ " + FightCadre.ElementAt<PartyMember>(2).FightVitality, new Vector2((int)targetPosition_3.X + 80, (int)targetPosition_3.Y), Color.White);
                                spriteBatch.DrawString(AwesomeFont, "Mana: " + FightCadre.ElementAt<PartyMember>(2).Mana + " \\ " + FightCadre.ElementAt<PartyMember>(2).FightManaPool, new Vector2((int)targetPosition_3.X + 270, (int)targetPosition_3.Y), Color.White);
                            }
                            if (this.Character4Name != null)
                            {
                                this.Character4Name.Draw(spriteBatch);
                                spriteBatch.DrawString(AwesomeFont, "Leben: " + FightCadre.ElementAt<PartyMember>(3).Life + " \\ " + FightCadre.ElementAt<PartyMember>(3).FightVitality, new Vector2((int)targetPosition_4.X + 80, (int)targetPosition_4.Y), Color.White);
                                spriteBatch.DrawString(AwesomeFont, "Mana: " + FightCadre.ElementAt<PartyMember>(3).Mana + " \\ " + FightCadre.ElementAt<PartyMember>(3).FightManaPool, new Vector2((int)targetPosition_4.X + 270, (int)targetPosition_4.Y), Color.White);
                            }
                        }
                    }

                    if (this.singleTargetEnemies)
                    {
                        if (!this.targetClicked)
                        {
                            targetBox.Draw(spriteBatch);
                            Back.Draw(spriteBatch);
                            if (this.enemy1Name != null)
                            {
                                this.enemy1Name.Draw(spriteBatch);
                                spriteBatch.DrawString(AwesomeFont, "Leben: " + Enemies.ElementAt<Enemy>(0).Life + " \\ " + Enemies.ElementAt<Enemy>(0).FightVitality, new Vector2((int)targetPosition_1.X + 80, (int)targetPosition_1.Y), Color.White);
                                spriteBatch.DrawString(AwesomeFont, "Mana: " + Enemies.ElementAt<Enemy>(0).Mana + " \\ " + Enemies.ElementAt<Enemy>(0).FightManaPool, new Vector2((int)targetPosition_1.X + 270, (int)targetPosition_1.Y), Color.White);
                            }
                            if (this.enemy2Name != null)
                            {
                                this.enemy2Name.Draw(spriteBatch);
                                spriteBatch.DrawString(AwesomeFont, "Leben: " + Enemies.ElementAt<Enemy>(1).Life + " \\ " + Enemies.ElementAt<Enemy>(1).FightVitality, new Vector2((int)targetPosition_2.X + 80, (int)targetPosition_2.Y), Color.White);
                                spriteBatch.DrawString(AwesomeFont, "Mana: " + Enemies.ElementAt<Enemy>(1).Mana + " \\ " + Enemies.ElementAt<Enemy>(1).FightManaPool, new Vector2((int)targetPosition_2.X + 270, (int)targetPosition_2.Y), Color.White);
                            }
                            if (this.enemy3Name != null)
                            {
                                this.enemy3Name.Draw(spriteBatch);
                                spriteBatch.DrawString(AwesomeFont, "Leben: " + Enemies.ElementAt<Enemy>(2).Life + " \\ " + Enemies.ElementAt<Enemy>(2).FightVitality, new Vector2((int)targetPosition_3.X + 80, (int)targetPosition_3.Y), Color.White);
                                spriteBatch.DrawString(AwesomeFont, "Mana: " + Enemies.ElementAt<Enemy>(2).Mana + " \\ " + Enemies.ElementAt<Enemy>(2).FightManaPool, new Vector2((int)targetPosition_3.X + 270, (int)targetPosition_3.Y), Color.White);
                            }
                            if (this.enemy4Name != null)
                            {
                                this.enemy4Name.Draw(spriteBatch);
                                spriteBatch.DrawString(AwesomeFont, "Leben: " + Enemies.ElementAt<Enemy>(3).Life + " \\ " + Enemies.ElementAt<Enemy>(3).FightVitality, new Vector2((int)targetPosition_4.X + 80, (int)targetPosition_4.Y), Color.White);
                                spriteBatch.DrawString(AwesomeFont, "Mana: " + Enemies.ElementAt<Enemy>(3).Mana + " \\ " + Enemies.ElementAt<Enemy>(3).FightManaPool, new Vector2((int)targetPosition_4.X + 270, (int)targetPosition_4.Y), Color.White);
                            }
                        }
                    }
                
                }

            

                DrawIcons(spriteBatch);
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
            Hit.Draw(spriteBatch);
            Heal.Draw(spriteBatch);
        }

        //führt die Statuseffekte aus
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

        //Startet einen neuen Zug und weist den nächsten Character zu
        public void StartNextTurn()
        {
            
            if (this.activeChar.Life <= 0)
            {
                this.activeChar.Statuseffects.RemoveAll(effect => effect.GetType() != typeof (Blessing));
            }

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

            this.ExecuteStatuseffects(activeChar);

            if (this.activeChar.Life <= 0 && this.activeChar.IsBlessed)
            {
                this.activeChar.IsBlessed = false;
                this.activeChar.Life = 1;
            }
            else if (activeChar.Life <= 0 || activeChar.IsMindBlown)
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
            skillClicked = false;
        }

        public void OnClickElement(string element)
        {
            Click.Play(1.0f, 0.0f, 0.0f);
            if (element == "back")
            {

            }
        }
        }
    }

