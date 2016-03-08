using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG.Events;

namespace RPG.Scenes
{
    class Scene1
    {
        ChooseCadreEvent ChooseCadre;
        BattleEvent Battle1;
        String BattleBackground1;

        List<PartyMember> Group = new List<PartyMember>();
        List<PartyMember> FightCadre = new List<PartyMember>();

        public Scene1()
        {
            BattleBackground1 = "Backgrounds\\Battle\\Bell_Battle_Background";
            ChooseCadre = new ChooseCadreEvent(Group, FightCadre, BattleBackground1);
        }

        public void LoadContent(ContentManager content)
        {
            ChooseCadre.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            if (!ChooseCadre.AuswahlBestätigt)
            {
                ChooseCadre.Update();
            }

            if(ChooseCadre.AuswahlBestätigt && !Battle1.BattleEvaluation.EndBattle)
            {
                Battle1.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!ChooseCadre.AuswahlBestätigt)
            {
                ChooseCadre.Draw(spriteBatch);
            }

            if (ChooseCadre.AuswahlBestätigt && !Battle1.BattleEvaluation.EndBattle)
            {
                Battle1.Draw(spriteBatch);
            }
        }
    }
}
