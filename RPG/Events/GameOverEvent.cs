using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG;

namespace RPG.Events
{
    class GameOverEvent
    {
        GUIElement Background;
        GUIElement LoadGameButton;
        GUIElement QuitButton;
        public GameOverEvent(string background)
        {
            Background = new GUIElement(background);
            LoadGameButton = new GUIElement("Buttons\\Load_Game_Button");
            QuitButton = new GUIElement("Buttons\\Quit_Button");
        }

        public void LoadContent(ContentManager content)
        {
            Background.LoadContent(content);
            LoadGameButton.LoadContent(content);
            QuitButton.LoadContent(content);

            LoadGameButton.clickEvent += OnClick;
            QuitButton.clickEvent += OnClick;

            LoadGameButton.CenterElement(576,720);
            LoadGameButton.moveElement(0, -100);
            QuitButton.CenterElement(576, 720);
            QuitButton.moveElement(0, 100);
        }

        public void Update()
        {
            LoadGameButton.Update();
            QuitButton.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            LoadGameButton.Draw(spriteBatch);
            QuitButton.Draw(spriteBatch);
        }

        public void OnClick(String element)
        {
            if(element == "Buttons\\Load_Game_Button")
            {
                //Lade Spiel
            }
            if (element == "Buttons\\Quit_Button")
            {
                //Spiel verlassen
            }
        }
    }
}
