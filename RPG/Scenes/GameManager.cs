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
        private IScene _activeAbstractScene;
        private int sceneCounter;

        public GameManager(List<PartyMember> group)
        {
            this.Group = group;

            this.sceneCounter = 0;
            this._activeAbstractScene = this.Scenes.ElementAt(this.sceneCounter);

            this.StartGame();
        }

        private void StartGame()
        {
            this._activeAbstractScene.Play(this.Group);
        }

        protected void NextScene()
        {
            if (!this._activeAbstractScene.IsDone)
            {
                return;
            }
            this.Group = this._activeAbstractScene.Group;

            this.sceneCounter++;
            this._activeAbstractScene = this.Scenes.ElementAt(this.sceneCounter);

            this._activeAbstractScene.Play(this.Group);
        }
    }
}
