using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Screen
    {
        Controls controls = new Controls();
        //Skill Animation wird erstellt
        private SkillAnimation testSkill = new SkillAnimation();
        private SkillAnimation testSkill2 = new SkillAnimation();
        private SkillAnimation testSkill3 = new SkillAnimation();
        private SkillAnimation testSkill4 = new SkillAnimation();
        private SkillAnimation testSkill5 = new SkillAnimation();

        //SpielStatus
        private enum GameState {mainMenu, options, storyScreen, battleScreen}
        private GameState gameState;
        private GameState oldGameState;

        //Liste der GUI Elemente
        private List<GUIElement> mainMenu = new List<GUIElement>();
        private List<GUIElement> options = new List<GUIElement>();
        private List<GUIElement> storyScreen = new List<GUIElement>();
        private List<GUIElement> battleScreen = new List<GUIElement>();
        private List<TextElement> battleScreenSkills = new List<TextElement>();
        private List<TextElement> storyText = new List<TextElement>();

        
        private bool exitGame = false;
        public bool ExitGame
        {
            get { return exitGame; }
        }

        //Character in Pixeln
        private int characterSize = 64;

        //Spieler Character Position
        private Vector2 characterPosition_1 = new Vector2(630,415);
        private Vector2 characterPosition_2 = new Vector2(620, 350);
        private Vector2 characterPosition_3 = new Vector2(610, 285);
        private Vector2 characterPosition_4 = new Vector2(600, 220);

        //Position der Gegner
        Vector2 enemyPosition_1 = new Vector2(100,415);
        Vector2 enemyPosition_2 = new Vector2(90, 350);
        Vector2 enemyPosition_3 = new Vector2(80, 285);
        Vector2 enemyPosition_4 = new Vector2(70, 220);
        Vector2 normalBossPosition;
        Vector2 finalBossPosition;

        public Screen()
        {
            mainMenu.Insert(0, new GUIElement("Backgrounds\\Menus\\Title_Screen_Background"));
            mainMenu.Insert(1, new GUIElement("Buttons\\New_Game_Button"));
            mainMenu.Insert(2, new GUIElement("Buttons\\Load_Game_Button"));
            mainMenu.Insert(3, new GUIElement("Buttons\\Quit_Button"));
            

            options.Insert(0, new GUIElement("Backgrounds\\Menus\\Options_Screen_Background"));
            options.Insert(1, new GUIElement("Buttons\\Continue_Button"));
            options.Insert(2, new GUIElement("Buttons\\Save_Button"));
            options.Insert(3, new GUIElement("Buttons\\Quit_Button"));

            storyScreen.Insert(0, new GUIElement("Backgrounds\\Story\\Triumphfelder_Story_Background"));
            storyScreen.Insert(1, new GUIElement("Boxes\\TextBox_Heroic_RPG"));
            

            battleScreen.Insert(0, new GUIElement("Backgrounds\\Battle\\Forest_Battle_Background"));
            battleScreen.Insert(1, new GUIElement("Icons\\Mindblown_Icon"));

            battleScreenSkills.Insert(0,new TextElement("Skill1",50,50));
            battleScreenSkills.Insert(1, new TextElement("Skill2", 100, 50));

            storyText.Insert(0, new TextElement("hallo, ich bin Seitz! lol. Was geht ab ihr Niggarz", 150, 422));
            storyText.Insert(1, new TextElement("hallo, ich bin Seitz! lol. Was geht ab ihr Niggarz", 150, 447));
            storyText.Insert(2, new TextElement("hallo, ich bin Seitz! lol. Was geht ab ihr Niggarz", 150, 472));
            storyText.Insert(3, new TextElement("hallo, ich bin Seitz! lol. Was geht ab ihr Niggarz", 150, 497));

        }

        public void LoadContent(ContentManager content)
        {

            foreach (TextElement element in storyText)
            {
                element.LoadContent(content);
                element.tclickEvent += OnClick;
            }
            foreach (TextElement element in battleScreenSkills)
            {
                element.LoadContent(content);
                element.tclickEvent += OnClick;
            }
            foreach (GUIElement element in mainMenu)
            {
                element.LoadContent(content);
                element.clickEvent += OnClick;
            }

            foreach(GUIElement element in options)
            {
                element.LoadContent(content);
                element.clickEvent += OnClick;
            }
            
            foreach (GUIElement element in storyScreen)
            {
                element.LoadContent(content);
                element.clickEvent += OnClick;
            }
            
            foreach (GUIElement element in battleScreen)
            {
                element.LoadContent(content);
                element.clickEvent += OnClick;

                //neue Animation wird erstellt
                Animation testAnimation = new Animation();
                Animation testAnimation2 = new Animation();
                Animation testAnimation3 = new Animation();
                Animation testAnimation4 = new Animation();
                Animation testAnimation5 = new Animation();

                //Animation wird geladen und die Textur sowie die Breite und Höhe wird festeglegt
                testAnimation.LoadContent(content.Load<Texture2D>("Animations\\DarkHoleAnim30FPS"), Vector2.Zero, 223, 232, 50, Color.White, 1f, true, 1, 16, false);
                testSkill.LoadContent(testAnimation, new Vector2(150, 150));

                testAnimation2.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Caspar\\Caspar_Standard_Animation"), Vector2.Zero, characterSize, characterSize, 125, Color.White, 1f, true, 1, 6, false);
                testSkill2.LoadContent(testAnimation2, characterPosition_1);

                testAnimation3.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Kaiser\\Kaiser_Standard_Animation"), Vector2.Zero, characterSize, characterSize, 150, Color.White, 1f, true, 1, 6, false);
                testSkill3.LoadContent(testAnimation3, characterPosition_2);

                testAnimation4.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seitz\\Seitz_Standard_Animation"), Vector2.Zero, characterSize, characterSize, 150, Color.White, 1f, true, 1, 6, false);
                testSkill4.LoadContent(testAnimation4, characterPosition_3);

                testAnimation5.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seyfrid\\Seyfrid_Standard_Animation"), Vector2.Zero, characterSize, characterSize, 150, Color.White, 1f, true, 1, 6, false);
                testSkill5.LoadContent(testAnimation5, characterPosition_4);
            }

            //Die Position der GUIElemente wird verändert
            mainMenu.ElementAt<GUIElement>(1).CenterElement(576, 720);
            mainMenu.ElementAt<GUIElement>(1).moveElement(0, 0);
            mainMenu.ElementAt<GUIElement>(2).CenterElement(576, 720);
            mainMenu.ElementAt<GUIElement>(2).moveElement(0, 100);
            mainMenu.ElementAt<GUIElement>(3).CenterElement(576, 720);
            mainMenu.ElementAt<GUIElement>(3).moveElement(0, 200);

            options.ElementAt<GUIElement>(1).CenterElement(576, 720);
            options.ElementAt<GUIElement>(1).moveElement(0, -100);
            options.ElementAt<GUIElement>(2).CenterElement(576, 720);
            options.ElementAt<GUIElement>(2).moveElement(0, 0);
            options.ElementAt<GUIElement>(3).CenterElement(576, 720);
            options.ElementAt<GUIElement>(3).moveElement(0, 100);

            storyScreen.ElementAt<GUIElement>(1).CenterElement(576, 720);
            storyScreen.ElementAt<GUIElement>(1).moveElement(0, 180);

            battleScreen.ElementAt<GUIElement>(1).moveElement((int)characterPosition_1.X + 30, (int)characterPosition_1.Y - 30);

        }
        
        public void Update(GameTime gameTime)
        {
            controls.Update();

            if (controls.CurrentKeyboardState.IsKeyDown(Keys.Escape) && gameState != GameState.mainMenu && gameState != GameState.options)
            {
                oldGameState = gameState;
                gameState = GameState.options;
            }

            switch (gameState)
            {
                case GameState.mainMenu:
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
                    }
                    break;
                case GameState.options:
                    foreach (GUIElement element in options)
                    {
                        element.Update();
                        if (controls.CurrentKeyboardState.IsKeyDown(Keys.Up) && !controls.PreviousKeyboardState.IsKeyDown(Keys.Up))
                        {
                            if (options.ElementAt<GUIElement>(3).getGUIRect.Contains(controls.CursorPos))
                            {
                                Mouse.SetPosition(options.ElementAt<GUIElement>(2).getGUIRect.Center.X, options.ElementAt<GUIElement>(2).getGUIRect.Center.Y);
                            }
                            else if (options.ElementAt<GUIElement>(1).getGUIRect.Contains(controls.CursorPos))
                            {
                                Mouse.SetPosition(options.ElementAt<GUIElement>(3).getGUIRect.Center.X, options.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                            }
                            else if (options.ElementAt<GUIElement>(2).getGUIRect.Contains(controls.CursorPos))
                            {
                                Mouse.SetPosition(options.ElementAt<GUIElement>(1).getGUIRect.Center.X, options.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                            }
                            else
                            {
                                Mouse.SetPosition(options.ElementAt<GUIElement>(3).getGUIRect.Center.X, options.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                            }
                        }
                        if (controls.CurrentKeyboardState.IsKeyDown(Keys.Down) && !controls.PreviousKeyboardState.IsKeyDown(Keys.Down))
                        {
                            if (options.ElementAt<GUIElement>(2).getGUIRect.Contains(controls.CursorPos))
                            {
                                Mouse.SetPosition(options.ElementAt<GUIElement>(3).getGUIRect.Center.X, options.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                            }
                            else if (options.ElementAt<GUIElement>(3).getGUIRect.Contains(controls.CursorPos))
                            {
                                Mouse.SetPosition(options.ElementAt<GUIElement>(1).getGUIRect.Center.X, options.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                            }
                            else if (options.ElementAt<GUIElement>(1).getGUIRect.Contains(controls.CursorPos))
                            {
                                Mouse.SetPosition(options.ElementAt<GUIElement>(2).getGUIRect.Center.X, options.ElementAt<GUIElement>(2).getGUIRect.Center.Y);
                            }
                            else
                            {
                                Mouse.SetPosition(options.ElementAt<GUIElement>(3).getGUIRect.Center.X, options.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                            }
                        }
                    }
                    break;
                case GameState.storyScreen:
                    foreach (GUIElement element in storyScreen)
                    {
                        element.Update();
                    }
                    break;
                case GameState.battleScreen:
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
                    }
                    break;
                    }

                    
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gameState)
            {
                case GameState.mainMenu:
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
                    foreach (TextElement element in storyText)
                    {
                        element.Draw(spriteBatch);
                    }
                    break;
                case GameState.battleScreen:
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
                    }
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
                gameState = oldGameState;
            }
            if (element == "Buttons\\Load_Game_Button")
            {
                gameState = GameState.storyScreen;
            }
            if (element == "Buttons\\New_Game_Button")
            {
                gameState = GameState.battleScreen;
            }
            if (element == "Buttons\\Quit_Button")
            {
                exitGame = true;
            }
            if (element == "Buttons\\Save_Button")
            {
                //Save
            }
            if (element == "Skill1")
            {
                gameState = GameState.storyScreen;
            }
            if (element == "Skill2")
            {
                gameState = GameState.mainMenu;
            }
        }
    }
}
