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

        private List<IScene> Scenes  = new List<IScene>();
        private IScene ActiveScene;
        private int sceneCounter;

        public GameManager()
        {
            this.sceneCounter = 0;
            this.ActiveScene = this.Scenes.ElementAt(this.sceneCounter);
        }

        protected void NextScene()
        {
            this.Group = this.ActiveScene.Group;

            this.sceneCounter++;
            this.ActiveScene = this.Scenes.ElementAt(this.sceneCounter);

            this.ActiveScene.Group = this.Group;
            //this.ActiveScene.Play();
        }
    }
}
