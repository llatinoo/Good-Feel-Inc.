using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RPG.Events;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class StoryEvent
    {
        bool storyPartIsOver;
        public bool StoryPartIsOver
        {
            get { return storyPartIsOver; }
        } 
        Controls controls = new Controls();

        int activeConversation;

        private List<ConversationEvent> Conversations;

        GUIElement Background;
        public StoryEvent(List<ConversationEvent> conversations, string backgroundPath)
        {
            this.Conversations = conversations;
            Background = new GUIElement(backgroundPath);
        }

        public void LoadContent(ContentManager content)
        {
            foreach(ConversationEvent conversation in Conversations)
            {
                conversation.LoadContent(content);
            }
            Background.LoadContent(content);
        }
        public void Update()
        {
            controls.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            if (controls.CurrentKeyboardState.IsKeyDown(Keys.Enter) && !controls.PreviousKeyboardState.IsKeyDown(Keys.Enter))
            {
                if (activeConversation < Conversations.Count - 1)
                {
                    activeConversation++;
                }
                else if (activeConversation == Conversations.Count - 1)
                {
                    storyPartIsOver = true;
                }
                
            }
            Conversations.ElementAt<ConversationEvent>(activeConversation).Draw(spriteBatch);

        }
    }
}
