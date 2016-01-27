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
            get { return this.exitGame; }
        }
        public Screen()
        {
            this.mainMenu.Insert(0, new GUIElement("Backgrounds\\Menus\\Title_Screen_Background"));
            this.mainMenu.Insert(1, new GUIElement("Buttons\\New_Game_Button"));
            this.mainMenu.Insert(2, new GUIElement("Buttons\\Continue_Button"));
            this.mainMenu.Insert(3, new GUIElement("Buttons\\Quit_Button"));

            this.options.Insert(0, new GUIElement("Backgrounds\\Menus\\Options_Screen_Background"));
            this.options.Insert(1, new GUIElement("Buttons\\Continue_Button"));
            this.options.Insert(2, new GUIElement("Buttons\\Save_Button"));
            this.options.Insert(3, new GUIElement("Buttons\\Quit_Button"));

            this.storyScreen.Insert(0, new GUIElement("Backgrounds\\Story\\Triumphfelder_Story_Background"));

            this.battleScreen.Insert(0, new GUIElement("Backgrounds\\Battle\\Forest_Battle_Background"));

            this.battleScreenSkills.Insert(0,new TextElement("Skill1",50,50));
            this.battleScreenSkills.Insert(1, new TextElement("Skill2", 100, 50));

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
            foreach(TextElement element in this.battleScreenSkills)
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
                //Animation wird geladen und die Textur sowie die Breite und Höhe wird festeglegt
                testAnimation.LoadContent(content.Load<Texture2D>("Animations\\DarkHoleAnim30FPS"), Vector2.Zero, 223, 232, 50, Color.White, 1f, true, 1, 16);
                this.testSkill.LoadContent(testAnimation, new Vector2(150, 150));

                testAnimation2.LoadContent(content.Load<Texture2D>("Animations\\BattlerAnim"), Vector2.Zero, 64, 64, 50, Color.White, 1f, true, 6, 9);
                this.testSkill2.LoadContent(testAnimation2, new Vector2(400, 400));
            }
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

        }
        
        public void Update(GameTime gameTime)
        {
            this.controls.Update();

            if (this.controls.CurrentKeyboardState.IsKeyDown(Keys.Escape) && this.gameState != GameState.mainMenu && this.gameState != GameState.options)
            {
                this.gameState = GameState.options;
            }

            switch (this.gameState)
            {
                case GameState.mainMenu:
                    foreach (GUIElement element in this.mainMenu)
                    {
                        element.Update();
                    }
                    if (this.controls.CurrentKeyboardState.IsKeyDown(Keys.Up) && !this.controls.PreviousKeyboardState.IsKeyDown(Keys.Up))
                    {
                        if (this.mainMenu.ElementAt<GUIElement>(3).getGUIRect.Contains(this.controls.CursorPos))
                        {
                            Mouse.SetPosition(this.mainMenu.ElementAt<GUIElement>(2).getGUIRect.Center.X, this.mainMenu.ElementAt<GUIElement>(2).getGUIRect.Center.Y);
                        }
                        else if (this.mainMenu.ElementAt<GUIElement>(1).getGUIRect.Contains(this.controls.CursorPos))
                        {
                            Mouse.SetPosition(this.mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.X, this.mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                        }
                        else if (this.mainMenu.ElementAt<GUIElement>(2).getGUIRect.Contains(this.controls.CursorPos))
                        {
                            Mouse.SetPosition(this.mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.X, this.mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                        }
                        else
                        {
                            Mouse.SetPosition(this.mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.X, this.mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                        }
                    }
                    if (this.controls.CurrentKeyboardState.IsKeyDown(Keys.Down) && !this.controls.PreviousKeyboardState.IsKeyDown(Keys.Down))
                    {
                        if (this.mainMenu.ElementAt<GUIElement>(2).getGUIRect.Contains(this.controls.CursorPos))
                        {
                            Mouse.SetPosition(this.mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.X, this.mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                        }
                        else if (this.mainMenu.ElementAt<GUIElement>(3).getGUIRect.Contains(this.controls.CursorPos))
                        {
                            Mouse.SetPosition(this.mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.X, this.mainMenu.ElementAt<GUIElement>(1).getGUIRect.Center.Y);
                        }
                        else if (this.mainMenu.ElementAt<GUIElement>(1).getGUIRect.Contains(this.controls.CursorPos))
                        {
                            Mouse.SetPosition(this.mainMenu.ElementAt<GUIElement>(2).getGUIRect.Center.X, this.mainMenu.ElementAt<GUIElement>(2).getGUIRect.Center.Y);
                        }
                        else
                        {
                            Mouse.SetPosition(this.mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.X, this.mainMenu.ElementAt<GUIElement>(3).getGUIRect.Center.Y);
                        }
                    }
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
                    foreach (GUIElement element in this.battleScreen)
                    {
                        element.Update();
                        foreach (TextElement telement in this.battleScreenSkills)
                        {
                            telement.Update();
                        }
                        this.testSkill.Update(gameTime);
                        this.testSkill2.Update(gameTime);
                    }
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (this.gameState)
            {
                case GameState.mainMenu:
                    foreach (GUIElement element in this.mainMenu)
                    {
                        element.Draw(spriteBatch);
                    }
                    break;
                case GameState.options:
                    foreach (GUIElement element in this.options)
                    {
                        element.Draw(spriteBatch);
                    }
                    break;
                case GameState.storyScreen:
                    foreach (GUIElement element in this.storyScreen)
                    {
                        element.Draw(spriteBatch);
                    }
                    break;
                case GameState.battleScreen:
                    foreach (GUIElement element in this.battleScreen)
                    {
                        element.Draw(spriteBatch);
                        foreach (TextElement telement in this.battleScreenSkills)
                        {
                            telement.Draw(spriteBatch);
                        }

                        this.testSkill.Draw(spriteBatch);
                        this.testSkill2.Draw(spriteBatch);
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
                this.gameState = GameState.storyScreen;
            }
            if (element == "Buttons\\Load_Game_Button")
            {
                this.gameState = GameState.battleScreen;
            }
            if (element == "Buttons\\New_Game_Button")
            {
                this.gameState = GameState.battleScreen;
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
            }
            if (element == "Skill2")
            {
                this.gameState = GameState.mainMenu;
            }
        }
    }
}
