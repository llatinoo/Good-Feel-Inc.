using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Scenes
{
        public class GameManager
        {
            protected List<PartyMember> Group { get; set; }
            private List<Scene> Scenes = new List<Scene>();
            private Scene ActiveScene;
            private int sceneCounter;

            public GameManager(List<PartyMember> group, int sceneId)
            {
                this.Group = group;

                this.sceneCounter = sceneId;
                this.ActiveScene = this.Scenes.ElementAt(this.sceneCounter);

                this.StartGame();
            }

            public int GetSceneCounter()
            {
                return sceneCounter;
            }

            public List<PartyMember> GetPartyMember()
            {
                return Group;
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
                this.Group = this.ActiveScene.SceneGroup;
                
                this.sceneCounter++;
                this.ActiveScene = this.Scenes.ElementAt(this.sceneCounter);
                
                this.ActiveScene.Play(this.Group);
            }
        }
}
