using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SchulProjekt
{
    class Screens
    {
        //Tastatur Status
        KeyboardState previousKeyboardState;
        KeyboardState currentKeyboardState;
        //SpielStatus
        enum GameState {mainMenu, options, storyScreen, battleScreen}
        GameState gameState;

        //Liste der GUI Elemente
        List<GUIElement> mainMenu = new List<GUIElement>();
        List<GUIElement> options = new List<GUIElement>();
        List<GUIElement> storyScreen = new List<GUIElement>();
        List<GUIElement> battleScreen = new List<GUIElement>();

        public Screens()
        {
            mainMenu.Insert(0, new GUIElement("MainMenuScreenbackground",0,0));
            mainMenu.Insert(1, new GUIElement("MainMenuPlayButton", 150, 150));

            options.Insert(0, new GUIElement("OptionsScreenBackground", 0, 0));
            options.Insert(1, new GUIElement("OptionsExitButton", 150, 150));
            options.Insert(2, new GUIElement("OptionsContinueButton", 200, 100));

            storyScreen.Insert(0, new GUIElement("StoryScreenBackground", 0, 0));

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
            foreach(GUIElement element in mainMenu)
            {
                element.LoadContent(content);
                element.clickEvent += OnClick;
            }
            //verschiebt das GUI Element mit einem bestimmten Namen 
            //main.Find(x => x.AssetName == "Play").moveElement(0,-100);
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
            }
            
        }
        
        public void Update()
        {
            //Tastatur Status wird gespeichert
            previousKeyboardState = currentKeyboardState;
            //aktueller Tastatur Status wird gelesen
            currentKeyboardState = Keyboard.GetState();

            if(currentKeyboardState.IsKeyDown(Keys.Escape) && gameState != GameState.mainMenu)
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
                    break;
                case GameState.options:
                    foreach (GUIElement element in options)
                    {
                        element.Update();
                    }
                    break;
                case GameState.storyScreen:
                    foreach (GUIElement element in storyScreen)
                    {
                        element.Update();
                    }
                    break;
                case GameState.battleScreen:
                    foreach (GUIElement element in storyScreen)
                    {
                        element.Update();
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
                    foreach (GUIElement element in storyScreen)
                    {
                        element.Draw(spriteBatch);
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
            if(element == "MainMenuPlayButton")
            {
                gameState = GameState.storyScreen;
                
            }
            if(element == "OptionsContinueButton")
            {
                gameState = GameState.storyScreen;
            }
            if(element == "OptionsExitButton")
            {
                //Quit Game
            }
        }
    }
}
