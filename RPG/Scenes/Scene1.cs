using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Events;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Scenes
{
    class Scene1
    {
        bool BattleSet = false;
        ConversationEvent Conversation1;
        ConversationEvent Conversation2;
        ConversationEvent Conversation3;
        ConversationEvent Conversation4;
        ConversationEvent Conversation5;
        ConversationEvent Conversation6;
        ConversationEvent Conversation7;

        StoryEvent StoryPart1;
        String Storybackground1;

        ChooseCadreEvent ChooseCadre1;
        String ChooseCadreBackground1;

        BattleEvent Battle1;
        String BattleBackground1;

        List<PartyMember> Group;
        List<PartyMember> FightCadre;
        List<Enemy> Enemies;

        public Scene1(List <PartyMember> Group, List<PartyMember> FightCadre, List<Enemy> Enemies)
        {
            this.Group = Group;
            this.FightCadre = FightCadre;
            this.Enemies = Enemies;
            Conversation1 = new ConversationEvent(0, 1, 1);
            Conversation2 = new ConversationEvent(0, 1, 2);
            Conversation3 = new ConversationEvent(0, 1, 3);
            Conversation4 = new ConversationEvent(0, 1, 4);
            Conversation5 = new ConversationEvent(0, 1, 5);
            Conversation6 = new ConversationEvent(0, 1, 6);
            Conversation7 = new ConversationEvent(0, 1, 7);

            Storybackground1 = "Backgrounds\\Story\\Triumphfelder_Story_Background";
            BattleBackground1 = "Backgrounds\\Battle\\Triumphfelder_Battle_Background";
            ChooseCadreBackground1 = "Backgrounds\\Battle\\Triumphfelder_Battle_Background";
        }

        public void LoadContent(ContentManager content)
        {
            StoryPart1 = new StoryEvent(new List<ConversationEvent> { Conversation1, Conversation2, Conversation3, Conversation4, Conversation5, Conversation6, Conversation7 }, Storybackground1);
            StoryPart1.LoadContent(content);
            ChooseCadre1 = new ChooseCadreEvent(Group,FightCadre,ChooseCadreBackground1);
            ChooseCadre1.LoadContent(content);
            Battle1 = new BattleEvent(FightCadre, Enemies, BattleBackground1);
            //Battle1.LoadContent(content);
            
        }

        public void Update(GameTime gameTime,ContentManager content)
        {
            if(!StoryPart1.StoryPartIsOver)
            {
                StoryPart1.Update();
            }
            if(!ChooseCadre1.AuswahlBestätigt && StoryPart1.StoryPartIsOver)
            {
                ChooseCadre1.Update();
            }
            if (!Battle1.BattleEvaluation.EndBattle && StoryPart1.StoryPartIsOver && ChooseCadre1.AuswahlBestätigt)
            {
                if(!BattleSet)
                {
                    Battle1.FightCadre = ChooseCadre1.Fightcadre;
                    BattleSet = true;
                    Battle1.ReloadContent(content);
                }
                Battle1.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!StoryPart1.StoryPartIsOver)
            {
                StoryPart1.Draw(spriteBatch);
            }
            if (!ChooseCadre1.AuswahlBestätigt && StoryPart1.StoryPartIsOver)
            {
                ChooseCadre1.Draw(spriteBatch);
            }
            if (!Battle1.BattleEvaluation.EndBattle && StoryPart1.StoryPartIsOver && ChooseCadre1.AuswahlBestätigt && BattleSet)
            {
                Battle1.Draw(spriteBatch);
            }
        }
    }
}
