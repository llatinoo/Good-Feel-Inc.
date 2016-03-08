using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RPG.Scenes
{
    public class GameManager
    {
        protected List<PartyMember> Group { get; set; }

        private List<Scene> Scenes  = new List<Scene>();
        private Scene ActiveScene;
        private int sceneCounter;

        public GameManager(List<PartyMember> group)
        {
            this.Group = group;

            this.sceneCounter = 0;
            this.ActiveScene = this.Scenes.ElementAt(this.sceneCounter);

            this.StartGame();
        }

        private void StartGame()
        {
            this.ActiveScene.Play(this.Group);
        }

        protected void NextScene()
        {
            if (!this.ActiveScene.IsDone)
            {
                return;
            }
            this.Group = this.ActiveScene.Group;

            this.sceneCounter++;
            this.ActiveScene = this.Scenes.ElementAt(this.sceneCounter);

            this.ActiveScene.Play(this.Group);
        }
    }
}
