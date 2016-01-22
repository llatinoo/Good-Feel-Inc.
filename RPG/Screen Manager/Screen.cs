using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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

        //SpielStatus
        private enum GameState {mainMenu, options, storyScreen, battleScreen}
        private GameState gameState;

        //Liste der GUI Elemente
        private List<GUIElement> mainMenu = new List<GUIElement>();
        private List<GUIElement> options = new List<GUIElement>();
        private List<GUIElement> storyScreen = new List<GUIElement>();
        private List<GUIElement> battleScreen = new List<GUIElement>();
        private List<TextElement> battleScreenSkills = new List<TextElement>();

        private bool exitGame = false;
        public bool ExitGame
        {
            get { return exitGame; }
        }
        public Screen()
        {
            mainMenu.Insert(0, new GUIElement("Backgrounds\\Menus\\Title_Screen_Background"));
            mainMenu.Insert(1, new GUIElement("Buttons\\New_Game_Button"));
            mainMenu.Insert(2, new GUIElement("Buttons\\Continue_Button"));
            mainMenu.Insert(3, new GUIElement("Buttons\\Quit_Button"));
            mainMenu.Insert(4, new GUIElement("Buttons\\Quit_Button"));

            options.Insert(0, new GUIElement("Backgrounds\\Menus\\Options_Screen_Background"));
            options.Insert(1, new GUIElement("Buttons\\Continue_Button"));
            options.Insert(2, new GUIElement("Buttons\\Save_Button"));
            options.Insert(3, new GUIElement("Buttons\\Quit_Button"));

            storyScreen.Insert(0, new GUIElement("Backgrounds\\Story\\Triumphfelder_Story_Background"));

            battleScreen.Insert(0, new GUIElement("Backgrounds\\Battle\\Forest_Battle_Background"));

            battleScreenSkills.Insert(0,new TextElement("Skill1",50,50));
            battleScreenSkills.Insert(1, new TextElement("Skill2", 100, 50));

            /*
            storyScreen.Insert(0, new GUIElement("StoryScreenBackground", 0, 0));
            storyScreen.Insert(1, new GUIElement("StoryTextBackground",0,0));
            //CharacterPortrait
            storyScreen.Insert(2, new GUIElement("StandartCharacterPortrait", 0, 0));
            
            mainMenu.Insert(0, new GUIElement("MainMenuScreenBackground", 0, 0));
            mainMenu.Insert(1, new GUIElement("MainMenubackgroundButton", 0, 0));
            mainMenu.Insert(2, new GUIElement("MainMenuNewGameButton", 0, 0));
            mainMenu.Insert(3, new GUIElement("MainMenuLoadGameButton", 0, 0));
            mainMenu.Insert(4, new GUIElement("MainMenuQuitButton", 0, 0));

            options.Insert(0, new GUIElement("OptionsScreenBackground", 0, 0));
            options.Insert(1, new GUIElement("OptionsMenuBackground", 0, 0));
            options.Insert(2, new GUIElement("OptionsContinueButton", 0, 0));
            options.Insert(3, new GUIElement("OptionsSaveButton", 0, 0));
            options.Insert(4, new GUIElement("OptionsQuitButton", 0, 0));
            */

        }

        public void LoadContent(ContentManager content)
        {
            foreach(TextElement element in battleScreenSkills)
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
                //Animation wird geladen und die Textur sowie die Breite und Höhe wird festeglegt
                testAnimation.LoadContent(content.Load<Texture2D>("Animations\\DarkHoleAnim30FPS"), Vector2.Zero, 223, 232, 50, Color.White, 1f, true, 1, 16);
                testSkill.LoadContent(testAnimation, new Vector2(150, 150));

                testAnimation2.LoadContent(content.Load<Texture2D>("Animations\\BattlerAnim"), Vector2.Zero, 64, 64, 50, Color.White, 1f, true, 6, 9);
                testSkill2.LoadContent(testAnimation2, new Vector2(400, 400));
            }
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

        }
        
        public void Update(GameTime gameTime)
        {
            controls.Update();

            if (controls.CurrentKeyboardState.IsKeyDown(Keys.Escape) && gameState != GameState.mainMenu && gameState != GameState.options)
            {
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
                gameState = GameState.storyScreen;
            }
            if (element == "Buttons\\Load_Game_Button")
            {
                gameState = GameState.battleScreen;
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
