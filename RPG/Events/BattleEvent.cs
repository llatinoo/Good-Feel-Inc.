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
using RPG.Extensions_And_Helper_Classes;

namespace RPG.Events
{
    class BattleEvent : IEvent
    {
        public bool isOver { get; set; }
        public int ID { get; }
        bool enemyHitDone;
        public bool firstStart { get; set; }
        bool AllowDeathAnimation = false;
        Controls controls = new Controls();
        GameOverEvent GameOver;
        
        BattleEvaluationEvent battleEvaluation;
        public BattleEvaluationEvent BattleEvaluation
        {
            get { return battleEvaluation; }
        }

        //Alle Character im BattleEvent
        List<Character> FightClub = new List<Character>();

        //Benutzer Gruppe
        List<PartyMember> fightCadre = new List<PartyMember>();
        public List<PartyMember> FightCadre
        {
            get { return fightCadre; }
            set { fightCadre = value; }
        }
        
        //Gegner Gruppe
        List<Enemy> Enemies = new List<Enemy>();

        //Aktiver Skill
        Skill activeSkill;

        //Boolean für Drawings
        bool singleTargetParty = false;
        bool singleTargetEnemies = false;
        bool GroupTargetParty = false;
        bool GroupTargetEnemy = false;
        bool skillClicked = false;
        bool targetClicked = false;
        
        //Boolean für das Ende der Runde
        //Aktiver Charakter
        Character activeChar;
        Character activeTarget;
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

        Vector2 skillDescriptionPosition = new Vector2(23, 473);

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

        GUIElement staticEnemy_1;
        GUIElement staticEnemy_2;
        GUIElement staticEnemy_3;
        GUIElement staticEnemy_4;

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

        Animation groupHitAnimation = new Animation();
        Animation groupHealAnimation = new Animation();

        Skill Hit;
        Skill Heal;

        Skill groupHit;
        Skill groupHeal;


        SoundEffect Click;
        SoundEffect Punch;
        SoundEffect MouseIntersect;
        

        public BattleEvent(List<PartyMember> fightCadre, List<Enemy> enemies, string background)
        {
            //Zuweisung der Listen
            this.fightCadre = fightCadre;
            this.Enemies = enemies;
            Background = new GUIElement(background);

            //FightCader wird der Liste FightClub hinzugefügt
            foreach (Character character in this.fightCadre)
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
            firstStart = true; 
        }

        public void InitializeData()
        {
            int groupCount = 0;
            int enemyCount = 0;
            foreach (Character character in this.fightCadre)
            {
                //Anpassung benötigt da am Ende Festwerte eingetragen wurden
                if (groupCount == 0)
                {
                    if (character.Name == "Anna")
                    {
                        charStandardAnimation_1 = LoadContentHelper.AnnaStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.AnnaAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.AnnaDeathAnimation;
                    }
                    else if (character.Name == "Elena")
                    {
                        charStandardAnimation_1 = LoadContentHelper.ElenaStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.ElenaAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.ElenaDeathAnimation;
                    }
                    else if (character.Name == "Ells")
                    {
                        charStandardAnimation_1 = LoadContentHelper.EllsStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.EllsAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.EllsDeathAnimation;
                    }
                    else if (character.Name == "Genefe")
                    {
                        charStandardAnimation_1 = LoadContentHelper.GenefeStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.GenefeAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.GenefeDeathAnimation;
                    }
                    else if (character.Name == "Marlein")
                    {
                        charStandardAnimation_1 = LoadContentHelper.MarleinStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.MarleinAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.MarleinDeathAnimation;
                    }
                    else if (character.Name == "Caspar")
                    {
                        charStandardAnimation_1 = LoadContentHelper.CasparStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.CasparAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.CasparDeathAnimation;
                    }
                    else if (character.Name == "Jos")
                    {
                        charStandardAnimation_1 = LoadContentHelper.JosStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.JosAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.JosDeathAnimation;
                    }
                    else if (character.Name == "Kaiser")
                    {
                        charStandardAnimation_1 = LoadContentHelper.KaiserStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.KaiserAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.KaiserDeathAnimation;
                    }
                    else if (character.Name == "Nick")
                    {
                        charStandardAnimation_1 = LoadContentHelper.NickStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.NickAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.NickDeathAnimation;
                    }
                    else if (character.Name == "Seitz")
                    {
                        charStandardAnimation_1 = LoadContentHelper.SeitzStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.SeitzAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.SeitzDeathAnimation;
                    }
                    else if (character.Name == "Seyfrid")
                    {
                        charStandardAnimation_1 = LoadContentHelper.SeyfridStandardAnimation;
                        charAttackAnimation_1 = LoadContentHelper.SeyfridAttackAnimation;
                        charDeathAnimation_1 = LoadContentHelper.SeyfridDeathAnimation;
                    }
                    charAttackAnimation_1.active = false;
                    this.fightCadre.ElementAt<Character>(0).LoadContent(charStandardAnimation_1, this.characterPosition_1);
                }

                if (groupCount == 1)
                {
                    if (character.Name == "Anna")
                    {
                        charStandardAnimation_2 = LoadContentHelper.AnnaStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.AnnaAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.AnnaDeathAnimation;
                    }
                    else if (character.Name == "Elena")
                    {
                        charStandardAnimation_2 = LoadContentHelper.ElenaStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.ElenaAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.ElenaDeathAnimation;
                    }
                    else if (character.Name == "Ells")
                    {
                        charStandardAnimation_2 = LoadContentHelper.EllsStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.EllsAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.EllsDeathAnimation;
                    }
                    else if (character.Name == "Genefe")
                    {
                        charStandardAnimation_2 = LoadContentHelper.GenefeStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.GenefeAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.GenefeDeathAnimation;
                    }
                    else if (character.Name == "Marlein")
                    {
                        charStandardAnimation_2 = LoadContentHelper.MarleinStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.MarleinAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.MarleinDeathAnimation;
                    }
                    else if (character.Name == "Caspar")
                    {
                        charStandardAnimation_2 = LoadContentHelper.CasparStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.CasparAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.CasparDeathAnimation;
                    }
                    else if (character.Name == "Jos")
                    {
                        charStandardAnimation_2 = LoadContentHelper.JosStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.JosAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.JosDeathAnimation;
                    }
                    else if (character.Name == "Kaiser")
                    {
                        charStandardAnimation_2 = LoadContentHelper.KaiserStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.KaiserAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.KaiserDeathAnimation;
                    }
                    else if (character.Name == "Nick")
                    {
                        charStandardAnimation_2 = LoadContentHelper.NickStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.NickAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.NickDeathAnimation;
                    }
                    else if (character.Name == "Seitz")
                    {
                        charStandardAnimation_2 = LoadContentHelper.SeitzStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.SeitzAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.SeitzDeathAnimation;
                    }
                    else if (character.Name == "Seyfrid")
                    {
                        charStandardAnimation_2 = LoadContentHelper.SeyfridStandardAnimation;
                        charAttackAnimation_2 = LoadContentHelper.SeyfridAttackAnimation;
                        charDeathAnimation_2 = LoadContentHelper.SeyfridDeathAnimation;
                    }
                    charAttackAnimation_2.active = false;
                    this.fightCadre.ElementAt<Character>(1).LoadContent(charStandardAnimation_2, this.characterPosition_2);
                }

                if (groupCount == 2)
                {
                    if (character.Name == "Anna")
                    {
                        charStandardAnimation_3 = LoadContentHelper.AnnaStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.AnnaAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.AnnaDeathAnimation;
                    }
                    else if (character.Name == "Elena")
                    {
                        charStandardAnimation_3 = LoadContentHelper.ElenaStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.ElenaAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.ElenaDeathAnimation;
                    }
                    else if (character.Name == "Ells")
                    {
                        charStandardAnimation_3 = LoadContentHelper.EllsStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.EllsAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.EllsDeathAnimation;
                    }
                    else if (character.Name == "Genefe")
                    {
                        charStandardAnimation_3 = LoadContentHelper.GenefeStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.GenefeAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.GenefeDeathAnimation;
                    }
                    else if (character.Name == "Marlein")
                    {
                        charStandardAnimation_3 = LoadContentHelper.MarleinStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.MarleinAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.MarleinDeathAnimation;
                    }
                    else if (character.Name == "Caspar")
                    {
                        charStandardAnimation_3 = LoadContentHelper.CasparStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.CasparAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.CasparDeathAnimation;
                    }
                    else if (character.Name == "Jos")
                    {
                        charStandardAnimation_3 = LoadContentHelper.JosStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.JosAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.JosDeathAnimation;
                    }
                    else if (character.Name == "Kaiser")
                    {
                        charStandardAnimation_3 = LoadContentHelper.KaiserStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.KaiserAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.KaiserDeathAnimation;
                    }
                    else if (character.Name == "Nick")
                    {
                        charStandardAnimation_3 = LoadContentHelper.NickStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.NickAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.NickDeathAnimation;
                    }
                    else if (character.Name == "Seitz")
                    {
                        charStandardAnimation_3 = LoadContentHelper.SeitzStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.SeitzAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.SeitzDeathAnimation;
                    }
                    else if (character.Name == "Seyfrid")
                    {
                        charStandardAnimation_3 = LoadContentHelper.SeyfridStandardAnimation;
                        charAttackAnimation_3 = LoadContentHelper.SeyfridAttackAnimation;
                        charDeathAnimation_3 = LoadContentHelper.SeyfridDeathAnimation;
                    }
                    charAttackAnimation_3.active = false;
                    this.fightCadre.ElementAt<Character>(2).LoadContent(charStandardAnimation_3, this.characterPosition_3);
                }

                if (groupCount == 3)
                {
                    if (character.Name == "Anna")
                    {
                        charStandardAnimation_4 = LoadContentHelper.AnnaStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.AnnaAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.AnnaDeathAnimation;
                    }
                    else if (character.Name == "Elena")
                    {
                        charStandardAnimation_4 = LoadContentHelper.ElenaStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.ElenaAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.ElenaDeathAnimation;
                    }
                    else if (character.Name == "Ells")
                    {
                        charStandardAnimation_4 = LoadContentHelper.EllsStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.EllsAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.EllsDeathAnimation;
                    }
                    else if (character.Name == "Genefe")
                    {
                        charStandardAnimation_4 = LoadContentHelper.GenefeStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.GenefeAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.GenefeDeathAnimation;
                    }
                    else if (character.Name == "Marlein")
                    {
                        charStandardAnimation_4 = LoadContentHelper.MarleinStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.MarleinAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.MarleinDeathAnimation;
                    }
                    else if (character.Name == "Caspar")
                    {
                        charStandardAnimation_4 = LoadContentHelper.CasparStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.CasparAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.CasparDeathAnimation;
                    }
                    else if (character.Name == "Jos")
                    {
                        charStandardAnimation_4 = LoadContentHelper.JosStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.JosAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.JosDeathAnimation;
                    }
                    else if (character.Name == "Kaiser")
                    {
                        charStandardAnimation_4 = LoadContentHelper.KaiserStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.KaiserAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.KaiserDeathAnimation;
                    }
                    else if (character.Name == "Nick")
                    {
                        charStandardAnimation_4 = LoadContentHelper.NickStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.NickAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.NickDeathAnimation;
                    }
                    else if (character.Name == "Seitz")
                    {
                        charStandardAnimation_4 = LoadContentHelper.SeitzStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.SeitzAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.SeitzDeathAnimation;
                    }
                    else if (character.Name == "Seyfrid")
                    {
                        charStandardAnimation_4 = LoadContentHelper.SeyfridStandardAnimation;
                        charAttackAnimation_4 = LoadContentHelper.SeyfridAttackAnimation;
                        charDeathAnimation_4 = LoadContentHelper.SeyfridDeathAnimation;
                    }
                    charAttackAnimation_4.active = false;
                    this.fightCadre.ElementAt<Character>(3).LoadContent(charStandardAnimation_4, this.characterPosition_4);
                }

                groupCount++;
            }

            foreach (Enemy enemy in this.Enemies)
            {
                // Sobald der Gegner eine Animation bestizt wird dies erkannt und die Animationen werden geladen
                if (enemy.isAnimated)
                {
                    if (enemyCount == 0)
                    {
                        if (enemy.Name == "Anna")
                        {
                            enemyStandardAnimation_1 = LoadContentHelper.EnemyAnnaStandardAnimation;
                            enemyAttackAnimation_1 = LoadContentHelper.EnemyAnnaAttackAnimation;
                            enemyDeathAnimation_1 = LoadContentHelper.EnemyAnnaDeathAnimation;
                        }
                        else if (enemy.Name == "Elena")
                        {
                            enemyStandardAnimation_1 = LoadContentHelper.EnemyElenaStandardAnimation;
                            enemyAttackAnimation_1 = LoadContentHelper.EnemyElenaAttackAnimation;
                            enemyDeathAnimation_1 = LoadContentHelper.EnemyElenaDeathAnimation;
                        }
                        else if (enemy.Name == "Ells")
                        {
                            enemyStandardAnimation_1 = LoadContentHelper.EnemyEllsStandardAnimation;
                            enemyAttackAnimation_1 = LoadContentHelper.EnemyEllsAttackAnimation;
                            enemyDeathAnimation_1 = LoadContentHelper.EnemyEllsDeathAnimation;
                        }
                        else if (enemy.Name == "Irene")
                        {
                            enemyStandardAnimation_1 = LoadContentHelper.EnemyIreneStandardAnimation;
                            enemyAttackAnimation_1 = LoadContentHelper.EnemyIreneAttackAnimation;
                            enemyDeathAnimation_1 = LoadContentHelper.EnemyIreneDeathAnimation;
                        }
                        else if (enemy.Name == "Marlein")
                        {
                            enemyStandardAnimation_1 = LoadContentHelper.EnemyMarleinStandardAnimation;
                            enemyAttackAnimation_1 = LoadContentHelper.EnemyMarleinAttackAnimation;
                            enemyDeathAnimation_1 = LoadContentHelper.EnemyMarleinDeathAnimation;
                        }
                        else if (enemy.Name == "Kaiser")
                        {
                            enemyStandardAnimation_1 = LoadContentHelper.EnemyKaiserStandardAnimation;
                            enemyAttackAnimation_1 = LoadContentHelper.EnemyKaiserAttackAnimation;
                            enemyDeathAnimation_1 = LoadContentHelper.EnemyKaiserDeathAnimation;
                        }
                        else if (enemy.Name == "Michael")
                        {
                            enemyStandardAnimation_1 = LoadContentHelper.EnemyMichaelStandardAnimation;
                            enemyAttackAnimation_1 = LoadContentHelper.EnemyMichaelAttackAnimation;
                            enemyDeathAnimation_1 = LoadContentHelper.EnemyMichaelDeathAnimation;
                        }
                        else if (enemy.Name == "Reinhardt")
                        {
                            enemyStandardAnimation_1 = LoadContentHelper.EnemyReinhardtStandardAnimation;
                            enemyAttackAnimation_1 = LoadContentHelper.EnemyReinhardtAttackAnimation;
                            enemyDeathAnimation_1 = LoadContentHelper.EnemyReinhardtDeathAnimation;
                        }
                        enemyAttackAnimation_1.active = false;
                        this.Enemies.ElementAt<Character>(0).LoadContent(enemyStandardAnimation_1, this.enemyPosition_1);
                    }

                    if (enemyCount == 1)
                    {
                        if (enemy.Name == "Anna")
                        {
                            enemyStandardAnimation_2 = LoadContentHelper.EnemyAnnaStandardAnimation;
                            enemyAttackAnimation_2 = LoadContentHelper.EnemyAnnaAttackAnimation;
                            enemyDeathAnimation_2 = LoadContentHelper.EnemyAnnaDeathAnimation;
                        }
                        else if (enemy.Name == "Elena")
                        {
                            enemyStandardAnimation_2 = LoadContentHelper.EnemyElenaStandardAnimation;
                            enemyAttackAnimation_2 = LoadContentHelper.EnemyElenaAttackAnimation;
                            enemyDeathAnimation_2 = LoadContentHelper.EnemyElenaDeathAnimation;
                        }
                        else if (enemy.Name == "Ells")
                        {
                            enemyStandardAnimation_2 = LoadContentHelper.EnemyEllsStandardAnimation;
                            enemyAttackAnimation_2 = LoadContentHelper.EnemyEllsAttackAnimation;
                            enemyDeathAnimation_2 = LoadContentHelper.EnemyEllsDeathAnimation;
                        }
                        else if (enemy.Name == "Irene")
                        {
                            enemyStandardAnimation_2 = LoadContentHelper.EnemyIreneStandardAnimation;
                            enemyAttackAnimation_2 = LoadContentHelper.EnemyIreneAttackAnimation;
                            enemyDeathAnimation_2 = LoadContentHelper.EnemyIreneDeathAnimation;
                        }
                        else if (enemy.Name == "Marlein")
                        {
                            enemyStandardAnimation_2 = LoadContentHelper.EnemyMarleinStandardAnimation;
                            enemyAttackAnimation_2 = LoadContentHelper.EnemyMarleinAttackAnimation;
                            enemyDeathAnimation_2 = LoadContentHelper.EnemyMarleinDeathAnimation;
                        }
                        else if (enemy.Name == "Kaiser")
                        {
                            enemyStandardAnimation_2 = LoadContentHelper.EnemyKaiserStandardAnimation;
                            enemyAttackAnimation_2 = LoadContentHelper.EnemyKaiserAttackAnimation;
                            enemyDeathAnimation_2 = LoadContentHelper.EnemyKaiserDeathAnimation;
                        }
                        else if (enemy.Name == "Michael")
                        {
                            enemyStandardAnimation_2 = LoadContentHelper.EnemyMichaelStandardAnimation;
                            enemyAttackAnimation_2 = LoadContentHelper.EnemyMichaelAttackAnimation;
                            enemyDeathAnimation_2 = LoadContentHelper.EnemyMichaelDeathAnimation;
                        }
                        else if (enemy.Name == "Reinhardt")
                        {
                            enemyStandardAnimation_2 = LoadContentHelper.EnemyReinhardtStandardAnimation;
                            enemyAttackAnimation_2 = LoadContentHelper.EnemyReinhardtAttackAnimation;
                            enemyDeathAnimation_2 = LoadContentHelper.EnemyReinhardtDeathAnimation;
                        }
                        enemyAttackAnimation_2.active = false;
                        this.Enemies.ElementAt<Character>(1).LoadContent(enemyStandardAnimation_2, this.enemyPosition_2);
                    }

                    if (enemyCount == 2)
                    {
                        if (enemy.Name == "Anna")
                        {
                            enemyStandardAnimation_3 = LoadContentHelper.EnemyAnnaStandardAnimation;
                            enemyAttackAnimation_3 = LoadContentHelper.EnemyAnnaAttackAnimation;
                            enemyDeathAnimation_3 = LoadContentHelper.EnemyAnnaDeathAnimation;
                        }
                        else if (enemy.Name == "Elena")
                        {
                            enemyStandardAnimation_3 = LoadContentHelper.EnemyElenaStandardAnimation;
                            enemyAttackAnimation_3 = LoadContentHelper.EnemyElenaAttackAnimation;
                            enemyDeathAnimation_3 = LoadContentHelper.EnemyElenaDeathAnimation;
                        }
                        else if (enemy.Name == "Ells")
                        {
                            enemyStandardAnimation_3 = LoadContentHelper.EnemyEllsStandardAnimation;
                            enemyAttackAnimation_3 = LoadContentHelper.EnemyEllsAttackAnimation;
                            enemyDeathAnimation_3 = LoadContentHelper.EnemyEllsDeathAnimation;
                        }
                        else if (enemy.Name == "Irene")
                        {
                            enemyStandardAnimation_3 = LoadContentHelper.EnemyIreneStandardAnimation;
                            enemyAttackAnimation_3 = LoadContentHelper.EnemyIreneAttackAnimation;
                            enemyDeathAnimation_3 = LoadContentHelper.EnemyIreneDeathAnimation;
                        }
                        else if (enemy.Name == "Marlein")
                        {
                            enemyStandardAnimation_3 = LoadContentHelper.EnemyMarleinStandardAnimation;
                            enemyAttackAnimation_3 = LoadContentHelper.EnemyMarleinAttackAnimation;
                            enemyDeathAnimation_3 = LoadContentHelper.EnemyMarleinDeathAnimation;
                        }
                        else if (enemy.Name == "Kaiser")
                        {
                            enemyStandardAnimation_3 = LoadContentHelper.EnemyKaiserStandardAnimation;
                            enemyAttackAnimation_3 = LoadContentHelper.EnemyKaiserAttackAnimation;
                            enemyDeathAnimation_3 = LoadContentHelper.EnemyKaiserDeathAnimation;
                        }
                        else if (enemy.Name == "Michael")
                        {
                            enemyStandardAnimation_3 = LoadContentHelper.EnemyMichaelStandardAnimation;
                            enemyAttackAnimation_3 = LoadContentHelper.EnemyMichaelAttackAnimation;
                            enemyDeathAnimation_3 = LoadContentHelper.EnemyMichaelDeathAnimation;
                        }
                        else if (enemy.Name == "Reinhardt")
                        {
                            enemyStandardAnimation_3 = LoadContentHelper.EnemyReinhardtStandardAnimation;
                            enemyAttackAnimation_3 = LoadContentHelper.EnemyReinhardtAttackAnimation;
                            enemyDeathAnimation_3 = LoadContentHelper.EnemyReinhardtDeathAnimation;
                        }
                        enemyAttackAnimation_3.active = false;
                        this.Enemies.ElementAt<Character>(2).LoadContent(enemyStandardAnimation_3, this.enemyPosition_3);
                    }

                    if (enemyCount == 3)
                    {
                        if (enemy.Name == "Anna")
                        {
                            enemyStandardAnimation_4 = LoadContentHelper.EnemyAnnaStandardAnimation;
                            enemyAttackAnimation_4 = LoadContentHelper.EnemyAnnaAttackAnimation;
                            enemyDeathAnimation_4 = LoadContentHelper.EnemyAnnaDeathAnimation;
                        }
                        else if (enemy.Name == "Elena")
                        {
                            enemyStandardAnimation_4 = LoadContentHelper.EnemyElenaStandardAnimation;
                            enemyAttackAnimation_4 = LoadContentHelper.EnemyElenaAttackAnimation;
                            enemyDeathAnimation_4 = LoadContentHelper.EnemyElenaDeathAnimation;
                        }
                        else if (enemy.Name == "Ells")
                        {
                            enemyStandardAnimation_4 = LoadContentHelper.EnemyEllsStandardAnimation;
                            enemyAttackAnimation_4 = LoadContentHelper.EnemyEllsAttackAnimation;
                            enemyDeathAnimation_4 = LoadContentHelper.EnemyEllsDeathAnimation;
                        }
                        else if (enemy.Name == "Irene")
                        {
                            enemyStandardAnimation_4 = LoadContentHelper.EnemyIreneStandardAnimation;
                            enemyAttackAnimation_4 = LoadContentHelper.EnemyIreneAttackAnimation;
                            enemyDeathAnimation_4 = LoadContentHelper.EnemyIreneDeathAnimation;
                        }
                        else if (enemy.Name == "Marlein")
                        {
                            enemyStandardAnimation_4 = LoadContentHelper.EnemyMarleinStandardAnimation;
                            enemyAttackAnimation_4 = LoadContentHelper.EnemyMarleinAttackAnimation;
                            enemyDeathAnimation_4 = LoadContentHelper.EnemyMarleinDeathAnimation;
                        }
                        else if (enemy.Name == "Kaiser")
                        {
                            enemyStandardAnimation_4 = LoadContentHelper.EnemyKaiserStandardAnimation;
                            enemyAttackAnimation_4 = LoadContentHelper.EnemyKaiserAttackAnimation;
                            enemyDeathAnimation_4 = LoadContentHelper.EnemyKaiserDeathAnimation;
                        }
                        else if (enemy.Name == "Michael")
                        {
                            enemyStandardAnimation_4 = LoadContentHelper.EnemyMichaelStandardAnimation;
                            enemyAttackAnimation_4 = LoadContentHelper.EnemyMichaelAttackAnimation;
                            enemyDeathAnimation_4 = LoadContentHelper.EnemyMichaelDeathAnimation;
                        }
                        else if (enemy.Name == "Reinhardt")
                        {
                            enemyStandardAnimation_4 = LoadContentHelper.EnemyReinhardtStandardAnimation;
                            enemyAttackAnimation_4 = LoadContentHelper.EnemyReinhardtAttackAnimation;
                            enemyDeathAnimation_4 = LoadContentHelper.EnemyReinhardtDeathAnimation;
                        }
                        enemyAttackAnimation_4.active = false;
                        this.Enemies.ElementAt<Character>(3).LoadContent(enemyStandardAnimation_4, this.enemyPosition_4);
                    }

                    enemyCount++;
                }
                // Wenn der Gegner erstellt wird und es keine Animation für den Gegner gibt wird dem entsprechend nur ein Bild des gegeners geladen
                else
                {
                    if (enemyCount == 0)
                    {
                        staticEnemy_1 = new GUIElement(this.Enemies.ElementAt<Enemy>(0).standardAnimationPath, (int)this.enemyPosition_1.X, (int)this.enemyPosition_1.Y);
                    }

                    if (enemyCount == 1)
                    {
                        staticEnemy_2 = new GUIElement(this.Enemies.ElementAt<Enemy>(1).standardAnimationPath, (int)this.enemyPosition_2.X, (int)this.enemyPosition_2.Y);
                    }

                    if (enemyCount == 2)
                    {
                        staticEnemy_3 = new GUIElement(this.Enemies.ElementAt<Enemy>(2).standardAnimationPath, (int)this.enemyPosition_3.X, (int)this.enemyPosition_3.Y);
                    }

                    if (enemyCount == 3)
                    {
                        staticEnemy_4 = new GUIElement(this.Enemies.ElementAt<Enemy>(3).standardAnimationPath, (int)this.enemyPosition_4.X, (int)this.enemyPosition_4.Y);
                    }
                    enemyCount++;
                }

            }




            int skillCounter = 0;
            int charCounter = 0;
            int enemieCounter = 0;



            foreach (Character character in this.fightCadre)
            {

                if (character.GetType() == typeof(PartyMember) || character.GetType() == typeof(Player))
                {

                    if (charCounter == 0)
                    {
                        this.Character1Name = new TextElement(LoadContentHelper.AwesomeFont, character.Name, (int)this.targetPosition_1.X, (int)this.targetPosition_1.Y, true, MouseIntersect);
                        this.Character1Name.tclickEvent += this.onClickTarget;
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.character1skill1 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true, MouseIntersect);
                                this.character1skill1.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                this.character1skill2 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_2.X, (int)this.skillPosition_2.Y, true, MouseIntersect);
                                this.character1skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character1skill3 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_3.X, (int)this.skillPosition_3.Y, true, MouseIntersect);
                                this.character1skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character1skill4 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_4.X, (int)this.skillPosition_4.Y, true, MouseIntersect);
                                this.character1skill4.tclickEvent += this.OnClickSkill;
                            }
                            skillCounter++;
                        }
                    }
                    if (charCounter == 1)
                    {
                        this.Character2Name = new TextElement(LoadContentHelper.AwesomeFont, character.Name, (int)this.targetPosition_2.X, (int)this.targetPosition_2.Y, true, MouseIntersect);
                        this.Character2Name.tclickEvent += this.onClickTarget;
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.character2skill1 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true, MouseIntersect);
                                this.character2skill1.tclickEvent += this.OnClickSkill;

                            }
                            if (skillCounter == 1)
                            {
                                this.character2skill2 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_2.X, (int)this.skillPosition_2.Y, true, MouseIntersect);
                                this.character2skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character2skill3 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_3.X, (int)this.skillPosition_3.Y, true, MouseIntersect);
                                this.character2skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character2skill4 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_4.X, (int)this.skillPosition_4.Y, true, MouseIntersect);
                                this.character2skill4.tclickEvent += this.OnClickSkill;
                            }

                            skillCounter++;
                        }

                    }

                    if (charCounter == 2)
                    {
                        this.Character3Name = new TextElement(LoadContentHelper.AwesomeFont, character.Name, (int)this.targetPosition_3.X, (int)this.targetPosition_3.Y, true, MouseIntersect);
                        this.Character3Name.tclickEvent += this.onClickTarget;

                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.character3skill1 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true, MouseIntersect);
                                this.character3skill1.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                this.character3skill2 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_2.X, (int)this.skillPosition_2.Y, true, MouseIntersect);
                                this.character3skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character3skill3 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_3.X, (int)this.skillPosition_3.Y, true, MouseIntersect);
                                this.character3skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character3skill4 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_4.X, (int)this.skillPosition_4.Y, true, MouseIntersect);
                                this.character3skill4.tclickEvent += this.OnClickSkill;
                            }

                            skillCounter++;
                        }
                    }
                    if (charCounter == 3)
                    {
                        this.Character4Name = new TextElement(LoadContentHelper.AwesomeFont, character.Name, (int)this.targetPosition_4.X, (int)this.targetPosition_4.Y, true, MouseIntersect);
                        this.Character4Name.tclickEvent += this.onClickTarget;
                        foreach (Skill skill in character.Skills)
                        {
                            if (skillCounter == 0)
                            {
                                this.character4skill1 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_1.X, (int)this.skillPosition_1.Y, true, MouseIntersect);
                                this.character4skill1.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 1)
                            {
                                this.character4skill2 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_2.X, (int)this.skillPosition_2.Y, true, MouseIntersect);
                                this.character4skill2.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 2)
                            {
                                this.character4skill3 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_3.X, (int)this.skillPosition_3.Y, true, MouseIntersect);
                                this.character4skill3.tclickEvent += this.OnClickSkill;
                            }
                            if (skillCounter == 3)
                            {
                                this.character4skill4 = new TextElement(LoadContentHelper.AwesomeFont, skill.Name, (int)this.skillPosition_4.X, (int)this.skillPosition_4.Y, true, MouseIntersect);
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
                    this.enemy1Name = new TextElement(LoadContentHelper.AwesomeFont, enemy.Name, (int)this.targetPosition_1.X, (int)this.targetPosition_1.Y, true, MouseIntersect);
                    this.enemy1Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 1)
                {
                    this.enemy2Name = new TextElement(LoadContentHelper.AwesomeFont, enemy.Name, (int)this.targetPosition_2.X, (int)this.targetPosition_2.Y, true, MouseIntersect);
                    this.enemy2Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 2)
                {
                    this.enemy3Name = new TextElement(LoadContentHelper.AwesomeFont, enemy.Name, (int)this.targetPosition_3.X, (int)this.targetPosition_3.Y, true, MouseIntersect);
                    this.enemy3Name.tclickEvent += this.onClickTarget;
                }
                if (enemieCounter == 3)
                {
                    this.enemy4Name = new TextElement(LoadContentHelper.AwesomeFont, enemy.Name, (int)this.targetPosition_4.X, (int)this.targetPosition_4.Y, true, MouseIntersect);
                    this.enemy4Name.tclickEvent += this.onClickTarget;
                }
                enemieCounter++;
            }
        }

        //Läd alle Texturen und Daten die das Event benötigt
        public void LoadContent(ContentManager content)
        {
            Click = content.Load<SoundEffect>("Sounds\\Effects\\click");
            Punch = content.Load<SoundEffect>("Sounds\\Effects\\Punch");
            MouseIntersect = content.Load<SoundEffect>("Sounds\\Effects\\MouseIntersect");

            hitAnimation.LoadContent(content.Load<Texture2D>("Animations\\Skills\\Physical_Hit"), Vector2.Zero, 192, 192, this.animationSpeed - 200, Color.White, 1f, false, 1, 5, false, false);
            Hit = new Skill("PhysicalHit", 0, null, null, null, null);
            Hit.LoadContent(hitAnimation, new Vector2(0, 0));
            hitAnimation.active = false;

            healAnimation.LoadContent(content.Load<Texture2D>("Animations\\Skills\\Heal"), Vector2.Zero, 80, 80, this.animationSpeed - 200, Color.White, 1f, false, 1, 10, false, false);
            Heal = new Skill("Heal", 0, null, null, null, null);
            Heal.LoadContent(healAnimation, new Vector2(0, 0));
            healAnimation.active = false;

            groupHealAnimation.LoadContent(content.Load<Texture2D>("Animations\\Skills\\Heal"), Vector2.Zero, 80, 80, this.animationSpeed - 200, Color.White, 1f, false, 1, 10, false, false);
            groupHeal = new Skill("GroupHeal", 0, null, null, null, null);
            groupHeal.LoadContent(healAnimation, new Vector2(0, 0));
            groupHealAnimation.active = false;

            groupHitAnimation.LoadContent(content.Load<Texture2D>("Animations\\Skills\\Physical_Hit"), Vector2.Zero, 192, 192, this.animationSpeed - 200, Color.White, 1f, false, 1, 5, false, false);
            groupHit = new Skill("GroupHit", 0, null, null, null, null);
            groupHit.LoadContent(hitAnimation, new Vector2(0, 0));
            groupHitAnimation.active = false;

            Background.LoadContent(content);
            Back = new TextElement(LoadContentHelper.AwesomeFont, "Back", (int)targetPosition_4.X, (int)targetPosition_4.Y + 25, true, MouseIntersect);
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

            GameOver = new GameOverEvent();
            GameOver.LoadContent(content);

            battleEvaluation = new BattleEvaluationEvent();
            battleEvaluation.LoadContent(content);

            this.attackSkill = new TextElement(LoadContentHelper.AwesomeFont, "Angriff", (int)this.attackSkillPosition.X, (int)this.attackSkillPosition.Y, true, MouseIntersect);
            this.attackSkill.tclickEvent += OnClickSkill;
            this.restSkill = new TextElement(LoadContentHelper.AwesomeFont, "Ausruhen", (int)this.restSkillPosition.X, (int)this.restSkillPosition.Y, true, MouseIntersect);
            this.restSkill.tclickEvent += OnClickSkill;

            skillBox = new GUIElement("Boxes\\SkillBox");
            skillBox.LoadContent(content);
            skillBox.CenterElement(576, 720);
            skillBox.moveElement(0, 245);

            targetBox = new GUIElement("Boxes\\SkillBox");
            targetBox.LoadContent(content);
            targetBox.CenterElement(576, 720);
            targetBox.moveElement(0, 245);

            CharacterStatBox = new GUIElement("Boxes\\Character_Stat_Box", 118, 88);
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

        }

        public void LoadAnimatedSkillsFromPartymember(List<Character> actualTargets, string targetName)
        {
            if (activeSkill.Target.ToLower() == "Single".ToLower())
            {
                if (activeSkill.AreaOfEffect == "Enemy")
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
                else if(activeSkill.AreaOfEffect == "Party")
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
        }

        public void LoadAnimatedSkillsFromEnemies(List<Character> actualTarget, string targetName)
        {
            if (activeSkill.Target.ToLower() == "Single".ToLower())
            {
                if (activeSkill.AreaOfEffect == "Enemy")
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
                else if (activeSkill.AreaOfEffect == "Party")
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
            }
        }
        
        //Führt aus was beim Klick auf ein Ziel passieren soll
        public void onClickTarget(String target)
        {
            Click.Play(1.0f, 0.0f, 0.0f);
            this.targetClicked = false;
            Thread.Sleep(120);
            foreach (Character character in this.FightClub)
            {
                if (character.Name.ToLower() == target.ToLower())
                {
                    this.activeSkill.Execute(this.activeChar, new List<Character> { character });
                    this.skillClicked = false;
                    this.targetClicked = true;
                    this.singleTargetEnemies = false;
                    this.singleTargetParty = false;
                    LoadAnimatedSkillsFromPartymember(new List<Character> { character }, target);
                    activeTarget = character;
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

            Hit.LoadContent(hitAnimation, new Vector2(-60, 0));
            Heal.LoadContent(healAnimation, new Vector2(-60, 0));

            //Skill wird überprüft
            foreach (Skill skill in this.activeChar.Skills)
            {
                if(skillName == skill.Name)
                {
                    this.activeSkill = skill;
                    //Wenn der Skill auf einzelne Charaktere zielt wird das ausgeführt
                    if (skill.Target.ToLower() == "Single".ToLower())
                    {
                        //Wenn der Skill sich auf PartyMember bezieht soll singleTarget True gesetzt werden
                        if (skill.AreaOfEffect.ToLower() == "Party".ToLower())
                        {
                            Thread.Sleep(200);
                            this.singleTargetParty = true;
                        }

                        // Sonst wird über prüft ob der Skill für einen Gegner bestimmt ist wenn ja dann soll singleTargetEnemies True gesetzt werden
                        else if (skill.AreaOfEffect.ToLower() == "Enemy".ToLower())
                        {
                            Thread.Sleep(200);
                            this.singleTargetEnemies = true;
                        }
                    }
                    else if (skill.Target.ToLower() == "Group".ToLower())
                    {
                        //Wenn der Skill sich auf eine Gruppe bezieht wird der skill ausgeführt dabei wird differenziert zwischen party und enemys
                        if (skill.AreaOfEffect.ToLower() == "Party".ToLower())
                        {
                            GroupTargetParty = true;
                            Thread.Sleep(200);
                            foreach (Character character in fightCadre)
                            {
                                targets.Add(character);
                            }
                            skill.Execute(this.activeChar, targets);
                            LoadAnimatedSkillsFromPartymember(targets, enemy1Name.SkillName);
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
                            healAnimation.active = true;
                            targets.Clear();
                            this.targetClicked = true;
                            skillClicked = true;

                        }
                        else if (skill.AreaOfEffect.ToLower() == "Enemy".ToLower())
                        {
                            GroupTargetEnemy = true;
                            Thread.Sleep(200);
                            foreach (Enemy enemy in this.Enemies)
                            {
                                targets.Add(enemy);
                            }
                            skill.Execute(this.activeChar, targets);
                            LoadAnimatedSkillsFromPartymember(targets, enemy1Name.SkillName);
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
                            targets.Clear();
                            this.targetClicked = true;
                            skillClicked = true;
                        }
                    }
                    break;
                }
            }
            if (skillName == "Ausruhen")
            {
                Thread.Sleep(300);
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
                healAnimation.active = true;
                this.activeChar.RestSkill.Execute(activeChar, new List<Character> { activeChar });
                targetClicked = true;
                this.StartNextTurn();
            }
            if(skillName == "Angriff")
            {
                activeSkill = this.activeChar.AttackSkill;
                Thread.Sleep(200);
                this.singleTargetEnemies = true;
            }
            
        }
        
        public void UpdateAnimatedSkillsFromPartymember()
        {
            if (!healAnimation.active && healAnimation.Done)
            {
                healAnimation.Done = false;
            }
            if (!hitAnimation.active && hitAnimation.Done)
            {
                hitAnimation.Done = false;
            }

                    if (!charAttackAnimation_1.active && charAttackAnimation_1.Done)
                    {
                        Punch.Play();
                        hitAnimation.active = true;
                        healAnimation.active = true;
                        this.fightCadre.ElementAt<PartyMember>(0).LoadContent(charStandardAnimation_1, this.characterPosition_1);
                        this.StartNextTurn();
                        charAttackAnimation_1.Done = false;
                        AllowDeathAnimation = true;
                    }
                    if (!charAttackAnimation_2.active && charAttackAnimation_2.Done)
                    {
                        Punch.Play();
                        hitAnimation.active = true;
                healAnimation.active = true;
                this.StartNextTurn();
                        this.fightCadre.ElementAt<PartyMember>(1).LoadContent(charStandardAnimation_2, this.characterPosition_2);
                        charAttackAnimation_2.Done = false;
                        AllowDeathAnimation = true;
                    }
                    if (!charAttackAnimation_3.active && charAttackAnimation_3.Done)
                    {
                        Punch.Play();
                        hitAnimation.active = true;
                healAnimation.active = true;
                this.StartNextTurn();
                        this.fightCadre.ElementAt<PartyMember>(2).LoadContent(charStandardAnimation_3, this.characterPosition_3);
                        charAttackAnimation_3.Done = false;
                        AllowDeathAnimation = true;
                    }
                    if (!charAttackAnimation_4.active && charAttackAnimation_4.Done)
                    {
                        Punch.Play();
                        hitAnimation.active = true;
                healAnimation.active = true;
                this.StartNextTurn();
                        this.fightCadre.ElementAt<PartyMember>(3).LoadContent(charStandardAnimation_4, this.characterPosition_4);
                        charAttackAnimation_4.Done = false;
                        AllowDeathAnimation = true;
                    }

                    if (!enemyAttackAnimation_1.active && enemyAttackAnimation_1.Done)
                    {
                        Punch.Play();
                        hitAnimation.active = true;
                healAnimation.active = true;
                this.StartNextTurn();
                        this.Enemies.ElementAt<Enemy>(0).LoadContent(enemyStandardAnimation_1, this.enemyPosition_1);
                        enemyAttackAnimation_1.Done = false;
                        AllowDeathAnimation = true;
                    }
                    if (!enemyAttackAnimation_2.active && enemyAttackAnimation_2.Done)
                    {
                        Punch.Play();
                        hitAnimation.active = true;
                healAnimation.active = true;
                this.StartNextTurn();
                        this.Enemies.ElementAt<Enemy>(1).LoadContent(enemyStandardAnimation_2, this.enemyPosition_2);
                        enemyAttackAnimation_2.Done = false;
                        AllowDeathAnimation = true;
                    }
                    if (!enemyAttackAnimation_3.active && enemyAttackAnimation_3.Done)
                    {
                        Punch.Play();
                        hitAnimation.active = true;
                healAnimation.active = true;
                this.StartNextTurn();
                        this.Enemies.ElementAt<Enemy>(2).LoadContent(enemyStandardAnimation_3, this.enemyPosition_3);
                        enemyAttackAnimation_3.Done = false;
                        AllowDeathAnimation = true;
                    }
                    if (!enemyAttackAnimation_4.active && enemyAttackAnimation_4.Done)
                    {
                        Punch.Play();
                        hitAnimation.active = true;
                healAnimation.active = true;
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
                if (fightCadre.Count == 1)
                {
                    if (fightCadre.ElementAt<PartyMember>(0).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(0).LoadContent(charDeathAnimation_1, this.characterPosition_1);
                    }
                }
                if (fightCadre.Count == 2)
                {
                    if (fightCadre.ElementAt<PartyMember>(0).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(0).LoadContent(charDeathAnimation_1, this.characterPosition_1);
                    }
                    if (fightCadre.ElementAt<PartyMember>(1).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(1).LoadContent(charDeathAnimation_2, this.characterPosition_2);
                    }
                }
                if (fightCadre.Count == 3)
                {
                    if (fightCadre.ElementAt<PartyMember>(0).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(0).LoadContent(charDeathAnimation_1, this.characterPosition_1);
                    }
                    if (fightCadre.ElementAt<PartyMember>(1).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(1).LoadContent(charDeathAnimation_2, this.characterPosition_2);
                    }
                    if (fightCadre.ElementAt<PartyMember>(2).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(2).LoadContent(charDeathAnimation_3, this.characterPosition_3);
                    }
                }
                if (fightCadre.Count == 4)
                {
                    if (fightCadre.ElementAt<PartyMember>(0).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(0).LoadContent(charDeathAnimation_1, this.characterPosition_1);
                    }
                    if (fightCadre.ElementAt<PartyMember>(1).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(1).LoadContent(charDeathAnimation_2, this.characterPosition_2);
                    }
                    if (fightCadre.ElementAt<PartyMember>(2).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(2).LoadContent(charDeathAnimation_3, this.characterPosition_3);
                    }
                    if (fightCadre.ElementAt<PartyMember>(3).Life <= 0)
                    {
                        this.fightCadre.ElementAt<Character>(3).LoadContent(charDeathAnimation_4, this.characterPosition_4);
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
                AllowDeathAnimation = false;
            }
        }
        
        //führt die Logik aus wie beispielsweise die Steuerung oder das Abspielen der Animationen
        public void Update(GameTime gameTime)
        {
            isOver = BattleEvaluation.EndBattle;
            if(firstStart)
            {
                InitializeData();
                firstStart = false;
            }
            controls.Update();

            Heal.Update(gameTime);
            Hit.Update(gameTime);

            UpdateAnimatedSkillsFromPartymember();
            UpdateDeathAnimations();

            if (fightCadre.All(member => member.Life == 0))
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
                    if (!enemyHitDone)
                    {
                        Hit.LoadContent(hitAnimation, new Vector2(-60, 0));
                        Heal.LoadContent(healAnimation, new Vector2(-60, 0));

                        ((Enemy)this.activeChar).PerformAI(this.fightCadre, this.Enemies.Cast<Character>().ToList());
                        activeSkill = ((Enemy)activeChar).SkillToPerform;
                        LoadAnimatedSkillsFromEnemies(((Enemy)activeChar).Targets, ((Enemy)activeChar).TargetName);
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
                        enemyHitDone = true;
                        ((Enemy)activeChar).Targets.Clear();
                    }
                }
                //führt ein Update der Animationen und Texte aus wenn es sich bei dem aktiven Character um ein Gruppenmitglied handelt
                else
                {
                    if (!skillClicked && !charAttackAnimation_1.active && !charAttackAnimation_2.active && !charAttackAnimation_3.active && !charAttackAnimation_4.active && !enemyAttackAnimation_1.active && !enemyAttackAnimation_2.active && !enemyAttackAnimation_3.active && !enemyAttackAnimation_4.active)
                    {
                        for (countFightCadre = 0; countFightCadre < this.fightCadre.Count - 1; countFightCadre++)
                        {
                            if (this.fightCadre.ElementAt(countFightCadre) == this.activeChar)
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
            foreach (Character chars in this.fightCadre)
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
                        if (Character1Name != null)
                        {
                            if (character.Name.Equals(Character1Name.SkillName))
                            {
                                bleedIcoCharacter_1.Draw(spriteBatch);
                            }
                        }
                        if (Character2Name != null)
                        {
                            if (character.Name.Equals(Character2Name.SkillName))
                            {
                                bleedIcoCharacter_2.Draw(spriteBatch);
                            }
                        }
                        if (Character3Name != null)
                        {
                            if (character.Name.Equals(Character3Name.SkillName))
                            {
                                bleedIcoCharacter_3.Draw(spriteBatch);
                            }
                        }
                        if (Character4Name != null)
                        {
                            if (character.Name.Equals(Character4Name.SkillName))
                            {
                                bleedIcoCharacter_4.Draw(spriteBatch);
                            }
                        }
                        if (enemy1Name != null)
                        {
                            if (character.Name.Equals(enemy1Name.SkillName))
                            {
                                bleedIcoEnemy_1.Draw(spriteBatch);
                            }
                        }
                        if (enemy2Name != null)
                        {
                            if (character.Name.Equals(enemy2Name.SkillName))
                            {
                                bleedIcoEnemy_2.Draw(spriteBatch);
                            }
                        }
                        if (enemy3Name != null)
                        {
                            if (character.Name.Equals(enemy3Name.SkillName))
                            {
                                bleedIcoEnemy_3.Draw(spriteBatch);
                            }
                        }
                        if (enemy4Name != null)
                        {
                            if (character.Name.Equals(enemy4Name.SkillName))
                            {
                                bleedIcoEnemy_4.Draw(spriteBatch);
                            }
                        }
                    }

                    else if (effect.GetType() == typeof(Mindblown))
                    {
                        if (Character1Name != null)
                        {
                            if (character.Name.Equals(Character1Name.SkillName))
                            {
                                mindBlownIcoCharacter_1.Draw(spriteBatch);
                            }
                        }
                        if (Character2Name != null)
                        {
                            if (character.Name.Equals(Character2Name.SkillName))
                            {
                                mindBlownIcoCharacter_2.Draw(spriteBatch);
                            }
                        }
                        if (Character3Name != null)
                        {
                            if (character.Name.Equals(Character3Name.SkillName))
                            {
                                mindBlownIcoCharacter_3.Draw(spriteBatch);
                            }
                        }
                        if (Character4Name != null)
                        {
                            if (character.Name.Equals(Character4Name.SkillName))
                            {
                                mindBlownIcoCharacter_4.Draw(spriteBatch);
                            }
                        }
                        if (enemy1Name != null)
                        {
                            if (character.Name.Equals(enemy1Name.SkillName))
                            {
                                mindBlownIcoEnemy_1.Draw(spriteBatch);
                            }
                        }
                        if (enemy2Name != null)
                        {
                            if (character.Name.Equals(enemy2Name.SkillName))
                            {
                                mindBlownIcoEnemy_2.Draw(spriteBatch);
                            }
                        }
                        if (enemy3Name != null)
                        {
                            if (character.Name.Equals(enemy3Name.SkillName))
                            {
                                mindBlownIcoEnemy_3.Draw(spriteBatch);
                            }
                        }
                        if (enemy4Name != null)
                        {
                            if (character.Name.Equals(enemy4Name.SkillName))
                            {
                                mindBlownIcoEnemy_4.Draw(spriteBatch);
                            }
                        }
                    }
                    else if (effect.GetType() == typeof(Blessing))
                    {
                        if (Character1Name != null)
                        {
                            if (character.Name.Equals(Character1Name.SkillName))
                            {
                                blessedIcoCharacter_1.Draw(spriteBatch);
                            }
                        }
                        if (Character2Name != null)
                        {
                            if (character.Name.Equals(Character2Name.SkillName))
                            {
                                blessedIcoCharacter_2.Draw(spriteBatch);
                            }
                        }
                        if (Character3Name != null)
                        {
                            if (character.Name.Equals(Character3Name.SkillName))
                            {
                                blessedIcoCharacter_3.Draw(spriteBatch);
                            }
                        }
                        if (Character4Name != null)
                        {
                            if (character.Name.Equals(Character4Name.SkillName))
                            {
                                blessedIcoCharacter_4.Draw(spriteBatch);
                            }
                        }
                        if (enemy1Name != null)
                        {
                            if (character.Name.Equals(enemy1Name.SkillName))
                            {
                                blessedIcoEnemy_1.Draw(spriteBatch);
                            }
                        }
                        if (enemy2Name != null)
                        {
                            if (character.Name.Equals(enemy2Name.SkillName))
                            {
                                blessedIcoEnemy_2.Draw(spriteBatch);
                            }
                        }
                        if (enemy3Name != null)
                        {
                            if (character.Name.Equals(enemy3Name.SkillName))
                            {
                                blessedIcoEnemy_3.Draw(spriteBatch);
                            }
                        }
                        if (enemy4Name != null)
                        {
                            if (character.Name.Equals(enemy4Name.SkillName))
                            {
                                blessedIcoEnemy_4.Draw(spriteBatch);
                            }
                        }
                    }
                    else if (effect.GetType() == typeof(HasHalo))
                    {
                        if (Character1Name != null)
                        {
                            if (character.Name.Equals(Character1Name.SkillName))
                            {
                                haloIcoCharacter_1.Draw(spriteBatch);
                            }
                        }
                        if (Character2Name != null)
                        {
                            if (character.Name.Equals(Character2Name.SkillName))
                            {
                                haloIcoCharacter_2.Draw(spriteBatch);
                            }
                        }
                        if (Character3Name != null)
                        {
                            if (character.Name.Equals(Character3Name.SkillName))
                            {
                                haloIcoCharacter_3.Draw(spriteBatch);
                            }
                        }
                        if (Character4Name != null)
                        {
                            if (character.Name.Equals(Character4Name.SkillName))
                            {
                                haloIcoCharacter_4.Draw(spriteBatch);
                            }
                        }
                        if (enemy1Name != null)
                        {
                            if (character.Name.Equals(enemy1Name.SkillName))
                            {
                                haloIcoEnemy_1.Draw(spriteBatch);
                            }
                        }
                        if (enemy2Name != null)
                        {
                            if (character.Name.Equals(enemy2Name.SkillName))
                            {
                                haloIcoEnemy_2.Draw(spriteBatch);
                            }
                        }
                        if (enemy3Name != null)
                        {
                            if (character.Name.Equals(enemy3Name.SkillName))
                            {
                                haloIcoEnemy_3.Draw(spriteBatch);
                            }
                        }
                        if (enemy4Name != null)
                        {
                            if (character.Name.Equals(enemy4Name.SkillName))
                            {
                                haloIcoEnemy_4.Draw(spriteBatch);
                            }
                        }
                    }
                    else if (effect.GetType() == typeof(Poisoned))
                    {
                        if (Character1Name != null)
                        {
                            if (character.Name.Equals(Character1Name.SkillName))
                            {
                                toxicIcoCharacter_1.Draw(spriteBatch);
                            }
                        }
                        if (Character2Name != null)
                        {
                            if (character.Name.Equals(Character2Name.SkillName))
                            {
                                toxicIcoCharacter_2.Draw(spriteBatch);
                            }
                        }
                        if (Character3Name != null)
                        {
                            if (character.Name.Equals(Character3Name.SkillName))
                            {
                                toxicIcoCharacter_3.Draw(spriteBatch);
                            }
                        }
                        if (Character4Name != null)
                        {
                            if (character.Name.Equals(Character4Name.SkillName))
                            {
                                toxicIcoCharacter_4.Draw(spriteBatch);
                            }
                        }
                        if (enemy1Name != null)
                        {
                            if (character.Name.Equals(enemy1Name.SkillName))
                            {
                                toxicIcoEnemy_1.Draw(spriteBatch);
                            }
                        }
                        if (enemy2Name != null)
                        {
                            if (character.Name.Equals(enemy2Name.SkillName))
                            {
                                toxicIcoEnemy_2.Draw(spriteBatch);
                            }
                        }
                        if (enemy3Name != null)
                        {
                            if (character.Name.Equals(enemy3Name.SkillName))
                            {
                                toxicIcoEnemy_3.Draw(spriteBatch);
                            }
                        }
                        if (enemy4Name != null)
                        {
                            if (character.Name.Equals(enemy4Name.SkillName))
                            {
                                toxicIcoEnemy_4.Draw(spriteBatch);
                            }
                        }
                    }
                    else if (effect.GetType() == typeof(Burning))
                    {
                        if (Character1Name != null)
                        {
                            if (character.Name.Equals(Character1Name.SkillName))
                            {
                                burnIcoCharacter_1.Draw(spriteBatch);
                            }
                        }
                        if (Character2Name != null)
                        {
                            if (character.Name.Equals(Character2Name.SkillName))
                            {
                                burnIcoCharacter_2.Draw(spriteBatch);
                            }
                        }
                        if (Character3Name != null)
                        {
                            if (character.Name.Equals(Character3Name.SkillName))
                            {
                                burnIcoCharacter_3.Draw(spriteBatch);
                            }
                        }
                        if (Character4Name != null)
                        {
                            if (character.Name.Equals(Character4Name.SkillName))
                            {
                                burnIcoCharacter_4.Draw(spriteBatch);
                            }
                        }
                        if (enemy1Name != null)
                        {
                            if (character.Name.Equals(enemy1Name.SkillName))
                            {
                                burnIcoEnemy_1.Draw(spriteBatch);
                            }
                        }
                        if (enemy2Name != null)
                        {
                            if (character.Name.Equals(enemy2Name.SkillName))
                            {
                                burnIcoEnemy_2.Draw(spriteBatch);
                            }
                        }
                        if (enemy3Name != null)
                        {
                            if (character.Name.Equals(enemy3Name.SkillName))
                            {
                                burnIcoEnemy_3.Draw(spriteBatch);
                            }
                        }
                        if (enemy4Name != null)
                        {
                            if (character.Name.Equals(enemy4Name.SkillName))
                            {
                                burnIcoEnemy_4.Draw(spriteBatch);
                            }
                        }
                    }
                }
            }
        }

        //Stellt die Grafiken dar
        public void Draw(SpriteBatch spriteBatch)
        {

            
            if (fightCadre.All(member => member.Life == 0))
            {
                GameOver.Draw(spriteBatch);
            }
            else if (Enemies.All(enemie => enemie.Life == 0))
            {
                BattleEvaluation.Draw(spriteBatch);
            }
            else if (!Enemies.All(enemie => enemie.Life == 0) && !fightCadre.All(member => member.Life == 0))
            {
                Background.Draw(spriteBatch);
                if (activeChar != null && activeTarget != null && activeSkill != null)
                {
                    if (activeTarget.GetType() == typeof(Enemy))
                    {
                        spriteBatch.DrawString(LoadContentHelper.AwesomeFont, activeChar.Name + " greift " + activeTarget.Name + " mit " + activeSkill.Name + " an!", new Vector2(200, 295), Color.White);
                    }
                    else if(activeTarget.GetType() == typeof(PartyMember))
                    {
                        spriteBatch.DrawString(LoadContentHelper.AwesomeFont, activeChar.Name + " wirkt " + activeSkill.Name + " auf " + activeTarget.Name + "!", new Vector2(200, 295), Color.White);
                    }
                }
                if(activeChar != null && activeSkill != null && activeTarget == null)
                {
                    if (GroupTargetEnemy)
                    {
                        spriteBatch.DrawString(LoadContentHelper.AwesomeFont, activeChar.Name + " greift die feindliche Gruppe mit " + activeSkill.Name + " an!", new Vector2(200, 295), Color.White);
                    }
                    if(GroupTargetParty)
                    {
                        spriteBatch.DrawString(LoadContentHelper.AwesomeFont, activeChar.Name + " wirkt " + activeSkill.Name + " auf die Gruppe!", new Vector2(200, 295), Color.White);
                    }
                }
                if (!this.skillClicked && !charAttackAnimation_1.active && !charAttackAnimation_2.active && !charAttackAnimation_3.active && !charAttackAnimation_4.active && !enemyAttackAnimation_1.active && !enemyAttackAnimation_2.active && !enemyAttackAnimation_3.active && !enemyAttackAnimation_4.active)
                {
                    skillBox.Draw(spriteBatch);
                    for (countFightCadre = 0; countFightCadre < this.fightCadre.Count - 1; countFightCadre++)
                    {
                        if (this.fightCadre.ElementAt(countFightCadre) == this.activeChar)
                        break;
                    }

                    foreach (Skill skill in activeChar.Skills)
                    {
                        if(restSkill.textRect.Contains(controls.CursorPos))
                        {
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + "Charakter regeneriert Mana", skillDescriptionPosition, Color.White);
                        }
                        if(attackSkill.textRect.Contains(controls.CursorPos))
                        {
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + "Ein Normaler Angriff", skillDescriptionPosition, Color.White);
                        }
                        if (Character1Name != null)
                        {
                            if (activeChar.Name == Character1Name.SkillName)
                            {
                                if (character1skill1.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(0).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character1skill2.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(1).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character1skill3.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(2).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character1skill4.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(3).Description, skillDescriptionPosition, Color.White);
                                }
                            }
                        }
                        if (Character2Name != null)
                        {
                            if (activeChar.Name == Character2Name.SkillName)
                            {
                                if (character2skill1.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(0).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character2skill2.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(1).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character2skill3.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(2).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character2skill4.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(3).Description, skillDescriptionPosition, Color.White);
                                }
                            }
                        }
                        if (Character3Name != null)
                        {
                            if (activeChar.Name == Character3Name.SkillName)
                            {
                                if (character3skill1.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(0).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character3skill2.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(1).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character3skill3.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(2).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character3skill4.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(3).Description, skillDescriptionPosition, Color.White);
                                }
                            }
                        }
                        if (Character4Name != null)
                        {
                            if (activeChar.Name == Character4Name.SkillName)
                            {
                                if (character4skill1.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(0).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character4skill2.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(1).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character4skill3.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(2).Description, skillDescriptionPosition, Color.White);
                                }
                                else if (character4skill4.textRect.Contains(controls.CursorPos))
                                {
                                    spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Skill beschreibung:\n" + activeChar.Skills.ElementAt(3).Description, skillDescriptionPosition, Color.White);
                                }
                            }
                        }
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
                            this.character4skill3.Draw(spriteBatch);
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
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, Character1Name.SkillName, new Vector2(135,110), Color.White);
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + fightCadre.ElementAt<PartyMember>(0).Life + " \\ " + fightCadre.ElementAt<PartyMember>(0).FightVitality, new Vector2(215, 110), Color.White);
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + fightCadre.ElementAt<PartyMember>(0).Mana + " \\ " + fightCadre.ElementAt<PartyMember>(0).FightManaPool, new Vector2(415, 110), Color.White);
                        }
                        if (this.Character2Name != null)
                        {
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, Character2Name.SkillName, new Vector2(135, 135), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + fightCadre.ElementAt<PartyMember>(1).Life + " \\ " + fightCadre.ElementAt<PartyMember>(1).FightVitality, new Vector2(215, 135), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + fightCadre.ElementAt<PartyMember>(1).Mana + " \\ " + fightCadre.ElementAt<PartyMember>(1).FightManaPool, new Vector2(415, 135), Color.White);
                        }
                        if (this.Character3Name != null)
                        {
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, Character3Name.SkillName, new Vector2(135, 160), Color.White);
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + fightCadre.ElementAt<PartyMember>(2).Life + " \\ " + fightCadre.ElementAt<PartyMember>(2).FightVitality, new Vector2(215, 160), Color.White);
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + fightCadre.ElementAt<PartyMember>(2).Mana + " \\ " + fightCadre.ElementAt<PartyMember>(2).FightManaPool, new Vector2(415, 160), Color.White);
                        }
                        if (this.Character4Name != null)
                        {
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, Character4Name.SkillName, new Vector2(135, 185), Color.White);
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + fightCadre.ElementAt<PartyMember>(3).Life + " \\ " + fightCadre.ElementAt<PartyMember>(3).FightVitality, new Vector2(215, 185), Color.White);
                            spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + fightCadre.ElementAt<PartyMember>(3).Mana + " \\ " + fightCadre.ElementAt<PartyMember>(3).FightManaPool, new Vector2(415, 185), Color.White);
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
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + fightCadre.ElementAt<PartyMember>(0).Life + " \\ " + fightCadre.ElementAt<PartyMember>(0).FightVitality, new Vector2((int)targetPosition_1.X + 80, (int)targetPosition_1.Y), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + fightCadre.ElementAt<PartyMember>(0).Mana + " \\ " + fightCadre.ElementAt<PartyMember>(0).FightManaPool, new Vector2((int)targetPosition_1.X + 270, (int)targetPosition_1.Y), Color.White);
                            }
                            if (this.Character2Name != null)
                            {
                                this.Character2Name.Draw(spriteBatch);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + fightCadre.ElementAt<PartyMember>(1).Life + " \\ " + fightCadre.ElementAt<PartyMember>(1).FightVitality, new Vector2((int)targetPosition_2.X + 80, (int)targetPosition_2.Y), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + fightCadre.ElementAt<PartyMember>(1).Mana + " \\ " + fightCadre.ElementAt<PartyMember>(1).FightManaPool, new Vector2((int)targetPosition_2.X + 270, (int)targetPosition_2.Y), Color.White);
                            }
                            if (this.Character3Name != null)
                            {
                                this.Character3Name.Draw(spriteBatch);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + fightCadre.ElementAt<PartyMember>(2).Life + " \\ " + fightCadre.ElementAt<PartyMember>(2).FightVitality, new Vector2((int)targetPosition_3.X + 80, (int)targetPosition_3.Y), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + fightCadre.ElementAt<PartyMember>(2).Mana + " \\ " + fightCadre.ElementAt<PartyMember>(2).FightManaPool, new Vector2((int)targetPosition_3.X + 270, (int)targetPosition_3.Y), Color.White);
                            }
                            if (this.Character4Name != null)
                            {
                                this.Character4Name.Draw(spriteBatch);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + fightCadre.ElementAt<PartyMember>(3).Life + " \\ " + fightCadre.ElementAt<PartyMember>(3).FightVitality, new Vector2((int)targetPosition_4.X + 80, (int)targetPosition_4.Y), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + fightCadre.ElementAt<PartyMember>(3).Mana + " \\ " + fightCadre.ElementAt<PartyMember>(3).FightManaPool, new Vector2((int)targetPosition_4.X + 270, (int)targetPosition_4.Y), Color.White);
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
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + Enemies.ElementAt<Enemy>(0).Life + " \\ " + Enemies.ElementAt<Enemy>(0).FightVitality, new Vector2((int)targetPosition_1.X + 80, (int)targetPosition_1.Y), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + Enemies.ElementAt<Enemy>(0).Mana + " \\ " + Enemies.ElementAt<Enemy>(0).FightManaPool, new Vector2((int)targetPosition_1.X + 270, (int)targetPosition_1.Y), Color.White);
                            }
                            if (this.enemy2Name != null)
                            {
                                this.enemy2Name.Draw(spriteBatch);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + Enemies.ElementAt<Enemy>(1).Life + " \\ " + Enemies.ElementAt<Enemy>(1).FightVitality, new Vector2((int)targetPosition_2.X + 80, (int)targetPosition_2.Y), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + Enemies.ElementAt<Enemy>(1).Mana + " \\ " + Enemies.ElementAt<Enemy>(1).FightManaPool, new Vector2((int)targetPosition_2.X + 270, (int)targetPosition_2.Y), Color.White);
                            }
                            if (this.enemy3Name != null)
                            {
                                this.enemy3Name.Draw(spriteBatch);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + Enemies.ElementAt<Enemy>(2).Life + " \\ " + Enemies.ElementAt<Enemy>(2).FightVitality, new Vector2((int)targetPosition_3.X + 80, (int)targetPosition_3.Y), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + Enemies.ElementAt<Enemy>(2).Mana + " \\ " + Enemies.ElementAt<Enemy>(2).FightManaPool, new Vector2((int)targetPosition_3.X + 270, (int)targetPosition_3.Y), Color.White);
                            }
                            if (this.enemy4Name != null)
                            {
                                this.enemy4Name.Draw(spriteBatch);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Leben: " + Enemies.ElementAt<Enemy>(3).Life + " \\ " + Enemies.ElementAt<Enemy>(3).FightVitality, new Vector2((int)targetPosition_4.X + 80, (int)targetPosition_4.Y), Color.White);
                                spriteBatch.DrawString(LoadContentHelper.AwesomeFont, "Mana: " + Enemies.ElementAt<Enemy>(3).Mana + " \\ " + Enemies.ElementAt<Enemy>(3).FightManaPool, new Vector2((int)targetPosition_4.X + 270, (int)targetPosition_4.Y), Color.White);
                            }
                        }
                    }
                
                }

                DrawIcons(spriteBatch);
                // Zeichnet die Charaktere auf dem Bildschirm
                foreach (Character chars in this.fightCadre)
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
            activeTarget = null;
            activeSkill = null;
            GroupTargetEnemy = false;
            GroupTargetParty = false;
            enemyHitDone = false;
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

