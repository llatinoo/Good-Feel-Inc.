using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RPG.Events;


namespace RPG
{
    class Screen
    {
        PartyMember char1 = new PartyMember("Anna", Classes.Patron, 8, new List<int>(10), 20, "Animations\\Battlers\\Female\\Anna\\Anna_Standard_Animation", "Animations\\Battlers\\Female\\Anna\\Anna_Attack_Animation", "Animations\\Battlers\\Female\\Anna\\Anna_Death_Animation");
        Enemy enemy1 = new Enemy("Kaiser", Classes.Patron, 8, "Enemies\\Bosse\\Human\\Anna\\Anna_Standard_Animation", "Enemies\\Bosse\\Human\\Anna\\Anna_Attack_Animation", "Enemies\\Bosse\\Human\\Anna\\Anna_Death_Animation", true);

        PartyMember char2 = new PartyMember("Caspar", Classes.Harasser, 8, new List<int>(10), 20, "Animations\\Battlers\\Male\\Caspar\\Caspar_Standard_Animation", "Animations\\Battlers\\Male\\Caspar\\Caspar_Attack_Animation", "Animations\\Battlers\\Male\\Caspar\\Caspar_Death_Animation");
        PartyMember char3 = new PartyMember("Elena", Classes.Coloss, 8, new List<int>(10), 20, "Animations\\Battlers\\Female\\Elena\\Elena_Standard_Animation", "Animations\\Battlers\\Female\\Elena\\Elena_Attack_Animation", "Animations\\Battlers\\Female\\Elena\\Elena_Death_Animation");
        PartyMember char4 = new PartyMember("Genefe", Classes.Warrior, 8, new List<int>(10), 20, "Animations\\Battlers\\Female\\Genefe\\Genefe_Standard_Animation", "Animations\\Battlers\\Female\\Genefe\\Genefe_Attack_Animation", "Animations\\Battlers\\Female\\Genefe\\Genefe_Death_Animation");

        

        BattleEvent testevent;

        Movie Intro = new Movie("Intro\\Good Feel Inc Intro");

        //Musste die Parameter von 0,0 auf 0,1 ändern, da es zwar eine Szene 0 gibt, Parts (Genau wie Texteboxen) immer bei 1 anfangen
        //ConversationEvent conversation1 = new ConversationEvent(0, 1, 1);
        //ConversationEvent conversation2 = new ConversationEvent(0, 1, 1);

        StoryEvent Scene1;

        bool stateChanged = false;
        Song mainMenuTheme;
        Song storyScreenTheme;
        Song battleScreenTheme;
        

        Controls controls = new Controls();
        //Skill Animation wird erstellt
        private SkillAnimation testSkill = new SkillAnimation();
        private SkillAnimation testSkill2 = new SkillAnimation();
        private SkillAnimation testSkill3 = new SkillAnimation();
        private SkillAnimation testSkill4 = new SkillAnimation();
        private SkillAnimation testSkill5 = new SkillAnimation();
        private SkillAnimation testSkill6 = new SkillAnimation();
        private SkillAnimation testSkill7 = new SkillAnimation();
        private SkillAnimation testSkill8 = new SkillAnimation();
        private SkillAnimation testSkill9 = new SkillAnimation();

        //SpielStatus
        public enum GameState {intro, mainMenu, options, storyScreen, battleScreen}
        private GameState gameState;
        public GameState getGameState
        {
            get { return this.gameState; }
        }
        private GameState oldGameState;

        //Listen der GUI und Text Elemente
        private List<GUIElement> mainMenu = new List<GUIElement>();
        private List<GUIElement> options = new List<GUIElement>();
        private List<GUIElement> storyScreen = new List<GUIElement>();
        private List<GUIElement> battleScreen = new List<GUIElement>();
        private List<TextElement> battleScreenSkills = new List<TextElement>();
        private List<TextElement> storyText = new List<TextElement>();

        //Gibt an ob das Spiel geschlossen werden soll
        private bool exitGame = false;
        public bool ExitGame
        {
            get { return this.exitGame; }
        }

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

        public Screen()
        {
            

            this.mainMenu.Insert(0, new GUIElement("Backgrounds\\Menus\\Title_Screen_Background"));
            this.mainMenu.Insert(1, new GUIElement("Buttons\\New_Game_Button"));
            this.mainMenu.Insert(2, new GUIElement("Buttons\\Load_Game_Button"));
            this.mainMenu.Insert(3, new GUIElement("Buttons\\Quit_Button"));


            this.options.Insert(0, new GUIElement("Backgrounds\\Menus\\Options_Screen_Background"));
            this.options.Insert(1, new GUIElement("Buttons\\Continue_Button"));
            this.options.Insert(2, new GUIElement("Buttons\\Save_Button"));
            this.options.Insert(3, new GUIElement("Buttons\\Quit_Button"));

            this.storyScreen.Insert(0, new GUIElement("Backgrounds\\Story\\Triumphfelder_Story_Background"));
            this.storyScreen.Insert(1, new GUIElement("Boxes\\TextBox_Heroic"));

            this.battleScreen.Insert(0, new GUIElement("Backgrounds\\Battle\\Forest_Battle_Background"));
            this.battleScreen.Insert(1, new GUIElement("Icons\\Mindblown_Icon"));

            this.battleScreenSkills.Insert(0,new TextElement("Skill1", 400, 450, false));
            this.battleScreenSkills.Insert(1, new TextElement("Skill2", 400, 480, false));
            
        }

        public void Initialize()
        {
            LoadSkillHelperClass.AddAllClassSkills(this.char1);
            LoadSkillHelperClass.AddAllClassSkills(this.char2);
            LoadSkillHelperClass.AddAllClassSkills(this.char3);
            LoadSkillHelperClass.AddAllClassSkills(this.char4);
            this.Intro.Initialize();
            this.testevent = new BattleEvent(new List<PartyMember> {this.char1, this.char2, this.char3, this.char4 }, new List<Enemy> {this.enemy1 }, "Backgrounds\\Battle\\Forest_Battle_Background");

            //Scene1 = new StoryEvent(new List<ConversationEvent> { conversation1, conversation2 }, "Backgrounds\\Story\\Anlegestelle_Triumphfelder_Story_Background.png");

        }
        public void LoadContent(ContentManager content)
        {
            this.testevent.LoadContent(content);
            //this.test.LoadContent(content);
            //this.test1.LoadContent(content);
            //Scene1.LoadContent(content);
            this.mainMenuTheme = content.Load<Song>("Sounds\\Umineko_Life");
            this.battleScreenTheme = content.Load<Song>("Sounds\\Hitman_Reborn");
            this.storyScreenTheme = content.Load<Song>("Sounds\\Hitman_Reborn");
            
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.8f;
            this.Intro.LoadContent(content);

            foreach (TextElement element in this.battleScreenSkills)
            {
                element.LoadContent(content);
                element.tclickEvent += this.OnClick;
            }
            foreach (GUIElement element in this.mainMenu)
            {
                element.LoadContent(content);
                element.clickEvent += this.OnClick;
            }

            foreach(GUIElement element in this.options)
            {
                element.LoadContent(content);
                element.clickEvent += this.OnClick;
            }
            
            foreach (GUIElement element in this.storyScreen)
            {
                element.LoadContent(content);
                element.clickEvent += this.OnClick;
            }
            
            foreach (GUIElement element in this.battleScreen)
            {
                element.LoadContent(content);
                element.clickEvent += this.OnClick;

                //neue Animation wird erstellt
                Animation testAnimation = new Animation();
                Animation testAnimation2 = new Animation();
                Animation testAnimation3 = new Animation();
                Animation testAnimation4 = new Animation();
                Animation testAnimation5 = new Animation();
                Animation testAnimation6 = new Animation();
                Animation testAnimation7 = new Animation();
                Animation testAnimation8 = new Animation();
                Animation testAnimation9 = new Animation();

                //Animation wird geladen und die Textur sowie die Breite und Höhe wird festeglegt

                //Spieler Charactere
                testAnimation.LoadContent(content.Load<Texture2D>("Animations\\Skills\\Dark_Hole_Animation"), Vector2.Zero, 468, 468, 80, Color.White, 1f, true, 32, 1, false, false);
                this.testSkill.LoadContent(testAnimation, new Vector2(400, 200));

                testAnimation2.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Caspar\\Caspar_Standard_Animation"), Vector2.Zero, this.characterSize, this.characterSize, 300, Color.White, 1f, true, 1, 3, false, false);
                this.testSkill2.LoadContent(testAnimation2, this.characterPosition_1);

                testAnimation3.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Kaiser\\Kaiser_Standard_Animation"), Vector2.Zero, this.characterSize, this.characterSize, 300, Color.White, 1f, true, 1, 3, false, false);
                this.testSkill3.LoadContent(testAnimation3, this.characterPosition_2);

                testAnimation4.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seitz\\Seitz_Standard_Animation"), Vector2.Zero, this.characterSize, this.characterSize, 300, Color.White, 1f, true, 1, 3, false, false);
                this.testSkill4.LoadContent(testAnimation4, this.characterPosition_3);

                testAnimation5.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seyfrid\\Seyfrid_Standard_Animation"), Vector2.Zero, this.characterSize, this.characterSize, 300, Color.White, 1f, true, 1, 3, false, false);
                this.testSkill5.LoadContent(testAnimation5, this.characterPosition_4);


                //Gegner
                testAnimation6.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Anna\\Anna_Standard_Animation"), Vector2.Zero, this.characterSize, this.characterSize, 300, Color.White, 1f, true, 0, 2, true, false);
                this.testSkill6.LoadContent(testAnimation6, this.enemyPosition_1);

                testAnimation7.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Elena\\Elena_Standard_Animation"), Vector2.Zero, this.characterSize, this.characterSize, 300, Color.White, 1f, true, 0, 2, true, false);
                this.testSkill7.LoadContent(testAnimation7, this.enemyPosition_2);

                testAnimation8.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Ells\\Ells_Standard_Animation"), Vector2.Zero, this.characterSize, this.characterSize, 300, Color.White, 1f, true, 0, 2, true, false);
                this.testSkill8.LoadContent(testAnimation8, this.enemyPosition_3);

                testAnimation9.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Marlein\\Marlein_Standard_Animation"), Vector2.Zero, this.characterSize, this.characterSize, 300, Color.White, 1f, true, 0, 2, true, false);
                this.testSkill9.LoadContent(testAnimation9, this.enemyPosition_4);

            }

            //Die Position der GUIElemente wird verändert
            this.mainMenu.ElementAt<GUIElement>(1).CenterElement(576, 720);
            this.mainMenu.ElementAt<GUIElement>(1).moveElement(0, 0);
            this.mainMenu.ElementAt<GUIElement>(2).CenterElement(576, 720);
            this.mainMenu.ElementAt<GUIElement>(2).moveElement(0, 100);
            this.mainMenu.ElementAt<GUIElement>(3).CenterElement(576, 720);
            this.mainMenu.ElementAt<GUIElement>(3).moveElement(0, 200);

            this.options.ElementAt<GUIElement>(1).CenterElement(576, 720);
            this.options.ElementAt<GUIElement>(1).moveElement(0, -100);
            this.options.ElementAt<GUIElement>(2).CenterElement(576, 720);
            this.options.ElementAt<GUIElement>(2).moveElement(0, 0);
            this.options.ElementAt<GUIElement>(3).CenterElement(576, 720);
            this.options.ElementAt<GUIElement>(3).moveElement(0, 100);

            this.storyScreen.ElementAt<GUIElement>(1).CenterElement(576, 720);
            this.storyScreen.ElementAt<GUIElement>(1).moveElement(0, 180);

            this.battleScreen.ElementAt<GUIElement>(1).moveElement((int) this.characterPosition_1.X + 30, (int) this.characterPosition_1.Y - 30);

        }
        
        public void Update(GameTime gameTime)
        {
            this.controls.Update();

            //Wenn das options Menu geöffnet wird, wird der Gamestate gespeichert um nach dem pausieren fortzufahren
            if (this.controls.CurrentKeyboardState.IsKeyDown(Keys.Escape) && this.gameState != GameState.mainMenu && this.gameState != GameState.options)
            {
                this.oldGameState = this.gameState;
                this.gameState = GameState.options;
            }

            //Je nach gamestate startet ein anderes Lied
            if (this.stateChanged)
            {
                MediaPlayer.Stop();
                switch (this.gameState)
                {
                    case GameState.mainMenu:
                        MediaPlayer.Play(this.mainMenuTheme);
                        break;
                    case GameState.battleScreen:
                        MediaPlayer.Play(this.battleScreenTheme);
                        break;
                    case GameState.storyScreen:
                        MediaPlayer.Play(this.storyScreenTheme);
                        break;
                }
                this.stateChanged = false;
            }

            //nachdem Das Intro abgespielt wurde, startet die Backgroundmusic
            if (gameTime.TotalGameTime.Seconds == 6)
            {
                if (gameState == GameState.intro)
                {
                    this.gameState = GameState.mainMenu;
                    stateChanged = true;
                }
            }

            switch (this.gameState)
            {
                case GameState.intro:
                    this.Intro.Update();
                    if(controls.CurrentKeyboardState.IsKeyDown(Keys.Enter))
                    {
                        Intro.Player.Stop();
                        gameState = GameState.mainMenu;
                        stateChanged = true;
                    }
                    break;
                case GameState.mainMenu:
                    if (!testevent.BattleEvaluation.EndBattle)
                    {
                        this.testevent.Update(gameTime);
                    }
                    //Scene1.Update();
                    /*
                    foreach (GUIElement element in mainMenu)
                    {
                        element.Update();
                    }
                    if (controls.CurrentKeyboardState.IsKeyDown(Keys.Up) && !controls.PreviousKeyboardState.IsKeyDown(Keys.Up))
                    {
                        if (mainMenu.ElementAt<GUIElement>(3).getGUIRect.Contains(controls.CursorPos))
                        {
                            Mouse.SetPosition(mainMenu.ElementAt<GUIElement>(2).getGUIRect.Center.X, mainMenu.ElementAt<GUIElement>(2).getGUIRect.Center.Y);
                        }
                        else if (mainMenu.ElementAt<GUIElement>(1).getGUIRect.Contains(controls.CursorPos))
                        {
                            Mouse.SetPosition(mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.X, mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                        }
                        else if (mainMenu.ElementAt<GUIElement>(2).getGUIRect.Contains(controls.CursorPos))
                        {
                            Mouse.SetPosition(mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.X, mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                        }
                        else
                        {
                            Mouse.SetPosition(mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.X, mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                        }
                    }
                    if (controls.CurrentKeyboardState.IsKeyDown(Keys.Down) && !controls.PreviousKeyboardState.IsKeyDown(Keys.Down))
                    {
                        if (mainMenu.ElementAt<GUIElement>(2).getGUIRect.Contains(controls.CursorPos))
                        {
                            Mouse.SetPosition(mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.X, mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                        }
                        else if (mainMenu.ElementAt<GUIElement>(3).getGUIRect.Contains(controls.CursorPos))
                        {
                            Mouse.SetPosition(mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.X, mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                        }
                        else if (mainMenu.ElementAt<GUIElement>(1).getGUIRect.Contains(controls.CursorPos))
                        {
                            Mouse.SetPosition(mainMenu.ElementAt<GUIElement>(2).getGUIRect.Center.X, mainMenu.ElementAt<GUIElement>(2).getGUIRect.Center.Y);
                        }
                        else
                        {
                            Mouse.SetPosition(mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.X, mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                        }
                    }*/
                        break;
                case GameState.options:
                    foreach (GUIElement element in this.options)
                    {
                        element.Update();
                        if (this.controls.CurrentKeyboardState.IsKeyDown(Keys.Up) && !this.controls.PreviousKeyboardState.IsKeyDown(Keys.Up))
                        {
                            if (this.options.ElementAt<GUIElement>(3).getGUIRect.Contains(this.controls.CursorPos))
                            {
                                Mouse.SetPosition(this.options.ElementAt<GUIElement>(2).getGUIRect.Center.X, this.options.ElementAt<GUIElement>(2).getGUIRect.Center.Y);
                            }
                            else if (this.options.ElementAt<GUIElement>(1).getGUIRect.Contains(this.controls.CursorPos))
                            {
                                Mouse.SetPosition(this.options.ElementAt<GUIElement>(3).getGUIRect.Center.X, this.options.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                            }
                            else if (this.options.ElementAt<GUIElement>(2).getGUIRect.Contains(this.controls.CursorPos))
                            {
                                Mouse.SetPosition(this.options.ElementAt<GUIElement>(1).getGUIRect.Center.X, this.options.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                            }
                            else
                            {
                                Mouse.SetPosition(this.options.ElementAt<GUIElement>(3).getGUIRect.Center.X, this.options.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                            }
                        }
                        if (this.controls.CurrentKeyboardState.IsKeyDown(Keys.Down) && !this.controls.PreviousKeyboardState.IsKeyDown(Keys.Down))
                        {
                            if (this.options.ElementAt<GUIElement>(2).getGUIRect.Contains(this.controls.CursorPos))
                            {
                                Mouse.SetPosition(this.options.ElementAt<GUIElement>(3).getGUIRect.Center.X, this.options.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                            }
                            else if (this.options.ElementAt<GUIElement>(3).getGUIRect.Contains(this.controls.CursorPos))
                            {
                                Mouse.SetPosition(this.options.ElementAt<GUIElement>(1).getGUIRect.Center.X, this.options.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                            }
                            else if (this.options.ElementAt<GUIElement>(1).getGUIRect.Contains(this.controls.CursorPos))
                            {
                                Mouse.SetPosition(this.options.ElementAt<GUIElement>(2).getGUIRect.Center.X, this.options.ElementAt<GUIElement>(2).getGUIRect.Center.Y);
                            }
                            else
                            {
                                Mouse.SetPosition(this.options.ElementAt<GUIElement>(3).getGUIRect.Center.X, this.options.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                            }
                        }
                    }
                    break;
                case GameState.storyScreen:
                    foreach (GUIElement element in this.storyScreen)
                    {
                        element.Update();
                    }
                    break;
                case GameState.battleScreen:
                    
                    /*
                    foreach (GUIElement element in battleScreen)
                    {
                        element.Update();
                        foreach (TextElement telement in battleScreenSkills)
                        {
                            telement.Update();
                        }
                        testSkill.Update(gameTime);
                        testSkill2.Update(gameTime);
                        testSkill3.Update(gameTime);
                        testSkill4.Update(gameTime);
                        testSkill5.Update(gameTime);
                        testSkill6.Update(gameTime);
                        testSkill7.Update(gameTime);
                        testSkill8.Update(gameTime);
                        testSkill9.Update(gameTime);
                    }*/
                    break;
            }

                    
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (this.gameState)
            {
                case GameState.intro:
                    this.Intro.Draw(spriteBatch);
                    break;
                case GameState.mainMenu:
                    if (!testevent.BattleEvaluation.EndBattle)
                    {
                        this.testevent.Draw(spriteBatch);
                    }
                    //Scene1.Draw(spriteBatch);
                    /*
                    foreach (GUIElement element in mainMenu)
                    {
                        element.Draw(spriteBatch);
                    }
                    break;
                case GameState.options:
                    foreach (GUIElement element in options)
                    {
                        element.Draw(spriteBatch);
                    }
                    break;
                case GameState.storyScreen:
                    foreach (GUIElement element in storyScreen)
                    {
                        element.Draw(spriteBatch);
                    }
                    if (!controls.PreviousKeyboardState.IsKeyDown(Keys.Enter))
                    {
                        test.Draw(spriteBatch);
                    }
                    if(controls.CurrentKeyboardState.IsKeyDown(Keys.Enter))
                    {
                        test1.Draw(spriteBatch);
                    }*/
                    break;
                case GameState.battleScreen:

                    

                    /*
                    foreach (GUIElement element in battleScreen)
                    {
                        element.Draw(spriteBatch);
                        foreach (TextElement telement in battleScreenSkills)
                        {
                            telement.Draw(spriteBatch);
                        }

                        testSkill.Draw(spriteBatch);
                        testSkill2.Draw(spriteBatch);
                        testSkill3.Draw(spriteBatch);
                        testSkill4.Draw(spriteBatch);
                        testSkill5.Draw(spriteBatch);
                        testSkill6.Draw(spriteBatch);
                        testSkill7.Draw(spriteBatch);
                        testSkill8.Draw(spriteBatch);
                        testSkill9.Draw(spriteBatch);
                    }
                    */
                    break;
            }
        }

        //ändert ein beliebiges GUI Element 
        public void ChangeGUIElement(List<GUIElement> screen, int index, GUIElement newTexture)
        {
            screen.RemoveAt(index);
            screen.Insert(index,newTexture);
        }

        public void OnClick(string element)
        {
            if(element == "Buttons\\Continue_Button")
            {
                this.gameState = this.oldGameState;
            }
            if (element == "Buttons\\Load_Game_Button")
            {
                this.gameState = GameState.storyScreen;
                this.stateChanged = true;
            }
            if (element == "Buttons\\New_Game_Button")
            {
                this.gameState = GameState.battleScreen;
                this.stateChanged = true;
            }
            if (element == "Buttons\\Quit_Button")
            {
                this.exitGame = true;
            }
            if (element == "Buttons\\Save_Button")
            {
                //Save
            }
            if (element == "Skill1")
            {
                this.gameState = GameState.storyScreen;
                this.stateChanged = true;
            }
            if (element == "Skill2")
            {
                this.gameState = GameState.mainMenu;
                this.stateChanged = true;
            }
        }
    }
}
