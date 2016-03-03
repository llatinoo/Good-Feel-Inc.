using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Events
{
    class GameOverEvent
    {
        GUIElement Background;
        public GameOverEvent(string background)
        {
            Background = new GUIElement(background);
        }

        public void LoadContent(ContentManager content)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
