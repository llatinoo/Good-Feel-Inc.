using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Scene
    {
        public int ID { get; private set; }

        private int activeEvent;
        public List<PartyMember> SceneGroup { get; set; }
        public List<PartyMember> FightCadre { get; private set; }
        public List<Enemy> Enemies { get; private set; }

        public bool IsDone { get; private set; }

        public List<IEvent> Events { get; private set; }

        public Scene(int id, List<PartyMember> group, List<IEvent> events)
        {
            this.ID = id;
            this.SceneGroup = group;
            this.Events = events;
            this.IsDone = true;
            events.OrderBy(concreteEvent => concreteEvent.ID);
            activeEvent = events.ElementAt(0).ID;
        }

        public void LoadContent(ContentManager content)
        {
            if (!IsDone)
            {
                Events.ElementAt(activeEvent).LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!IsDone)
            {
                if (Events.ElementAt(activeEvent).GetType() == typeof(ChooseCadreEvent))
                {
                    ((ChooseCadreEvent)Events.ElementAt(activeEvent)).Group = SceneGroup;
                    if (Events.ElementAt(activeEvent).isOver)
                    {
                        this.FightCadre = ((ChooseCadreEvent)Events.ElementAt(activeEvent)).Fightcadre;
                        if (Events.ElementAt(activeEvent + 1).GetType() == typeof(BattleEvent))
                        {
                            ((BattleEvent)Events.ElementAt(activeEvent)).FightCadre = this.FightCadre;
                        }
                        activeEvent++;
                    }
                }
                if (Events.ElementAt(activeEvent).isOver && Events.ElementAt(activeEvent).GetType() != typeof(ChooseCadreEvent))
                {
                    activeEvent++;
                }
                if (activeEvent > Events.Count)
                {
                    this.IsDone = true;
                }
                Events.ElementAt(activeEvent).Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDone)
            {
                Events.ElementAt(activeEvent).Draw(spriteBatch);
            }
        }

        public void Play(List<PartyMember> Group)
        {
            this.SceneGroup = Group;
            IsDone = false;
        }
    }
}
