using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace RPG.Events
{
    class BattleEvent
    {
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

        private Vector2 targetPosition_1 = new Vector2(30, 480);
        private Vector2 targetPosition_2 = new Vector2(30, 500);
        private Vector2 targetPosition_3 = new Vector2(30, 520);
        private Vector2 targetPosition_4 = new Vector2(30, 540);

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

        TextElement Enemie1Name;
        TextElement Enemie2Name;
        TextElement Enemie3Name;
        TextElement Enemie4Name;

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
        }

        //Läd alle Texturen und Daten die das Event benötigt
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

            Background.LoadContent(content);

            GameOver = new GameOverEvent("Backgrounds\\Menus\\Options_Screen_Background");
            GameOver.LoadContent(content);

            battleEvaluation = new BattleEvaluationEvent("Backgrounds\\Menus\\Options_Screen_Background");
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
            skillBox.moveElement(185,245);

            targetBox = new GUIElement("Boxes\\SkillBox");
            targetBox.LoadContent(content);
            targetBox.CenterElement(576, 720);
            targetBox.moveElement(-300, 245);

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

        //Führt aus was beim Klick auf ein Ziel passieren soll
        public void onClickTarget(String target)
        {
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

        //Führt aus was beim Klick auf einen Skill passieren soll
        public void OnClickSkill(String skillName)
        {
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
                            TurnStart();
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
                            TurnStart();
                        }
                    }
                    break;
                }
            }
            if (skillName == "Ausruhen")
            {
                this.activeChar.RestSkill.Execute(activeChar, new List<Character> { activeChar });
                targetClicked = true;
                Thread.Sleep(120);
                TurnStart();
            }
            if(skillName == "Angriff")
            {
                activeSkill = this.activeChar.AttackSkill;
                Thread.Sleep(120);
                this.singleTargetEnemies = true;
            }
            
        }

        //führt die Logik aus wie beispielsweise die Steuerung oder das Abspielen der Animationen
        public void Update(GameTime gameTime)
        {
            if(FightCadre.All(member => member.Life == 0))
            {
                GameOver.Update();
            }
            else if(Enemies.All(enemie => enemie.Life == 0))
            {
                battleEvaluation.Update(gameTime);
            }
            //Die KI wird ausgeführt wenn es sich bei dem Aktiven Character um einen Gegner handelt
            if (activeChar.GetType() == typeof(Enemy))
            {
                //führe KI aus
                TurnStart();
            }
            //führt ein Update der Animationen und Texte aus wenn es sich bei dem aktiven Character um ein Gruppenmitglied handelt
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
                        else if (character.Name.Equals(Enemie1Name.SkillName))
                        {
                            bleedIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie2Name.SkillName))
                        {
                            bleedIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie3Name.SkillName))
                        {
                            bleedIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie4Name.SkillName))
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
                        else if (character.Name.Equals(Enemie1Name.SkillName))
                        {
                            mindBlownIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie2Name.SkillName))
                        {
                            mindBlownIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie3Name.SkillName))
                        {
                            mindBlownIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie4Name.SkillName))
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
                        else if (character.Name.Equals(Enemie1Name.SkillName))
                        {
                            blessedIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie2Name.SkillName))
                        {
                            blessedIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie3Name.SkillName))
                        {
                            blessedIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie4Name.SkillName))
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
                        else if (character.Name.Equals(Enemie1Name.SkillName))
                        {
                            haloIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie2Name.SkillName))
                        {
                            haloIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie3Name.SkillName))
                        {
                            haloIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie4Name.SkillName))
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
                        else if (character.Name.Equals(Enemie1Name.SkillName))
                        {
                            toxicIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie2Name.SkillName))
                        {
                            toxicIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie3Name.SkillName))
                        {
                            toxicIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie4Name.SkillName))
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
                        else if (character.Name.Equals(Enemie1Name.SkillName))
                        {
                            burnIcoEnemy_1.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie2Name.SkillName))
                        {
                            burnIcoEnemy_2.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie3Name.SkillName))
                        {
                            burnIcoEnemy_3.Draw(spriteBatch);
                        }
                        else if (character.Name.Equals(Enemie4Name.SkillName))
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
                if (!this.skillClicked)
                {
                    skillBox.Draw(spriteBatch);
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
                            targetBox.Draw(spriteBatch);
                            if (this.Character1Name != null)
                            {
                                this.Character1Name.Draw(spriteBatch);
                            }
                            if (this.Character2Name != null)
                            {
                                this.Character2Name.Draw(spriteBatch);
                            }
                            if (this.Character3Name != null)
                            {
                                this.Character3Name.Draw(spriteBatch);
                            }
                            if (this.Character4Name != null)
                            {
                                this.Character4Name.Draw(spriteBatch);
                            }
                        }
                    }

                    if (this.singleTargetEnemies)
                    {
                        if (!this.targetClicked)
                        {
                            targetBox.Draw(spriteBatch);
                            if (this.Enemie1Name != null)
                            {
                                this.Enemie1Name.Draw(spriteBatch);
                            }
                            if (this.Enemie2Name != null)
                            {
                                this.Enemie2Name.Draw(spriteBatch);
                            }
                            if (this.Enemie3Name != null)
                            {
                                this.Enemie3Name.Draw(spriteBatch);
                            }
                            if (this.Enemie4Name != null)
                            {
                                this.Enemie4Name.Draw(spriteBatch);
                            }
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
                DrawIcons(spriteBatch);
            }
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
        public void TurnStart()
        {
            if (activeChar.Life <= 0 || activeChar.IsMindBlown)
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
                this.ExecuteStatuseffects(activeChar);
                activeChar.IsMindBlown = false;
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
            this.ExecuteStatuseffects(activeChar);
            skillClicked = false;
        }
    }
}
