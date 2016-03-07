using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Events
{
    class BattleEvaluationEvent
    {
        bool endBattle = false;

        TextElement Character_1_Name;
        TextElement Character_2_Name;
        TextElement Character_3_Name;
        TextElement Character_4_Name;

        private TextElement Character;
        public bool EndBattle
        {
            get { return endBattle; }
            set { endBattle = value; }
        }

        GUIElement EvaluationBox;
        GUIElement ContinueButton;
        TextElement CharacterXP1;
        
        public BattleEvaluationEvent(string evaluationBoxPath)
        {
            EvaluationBox = new GUIElement(evaluationBoxPath);
            ContinueButton = new GUIElement("Buttons\\Continue_Button");
        }

        public void LoadContent(ContentManager content)
        {
            EvaluationBox.LoadContent(content);
            ContinueButton.LoadContent(content);
            ContinueButton.CenterElement(576, 720);
            ContinueButton.moveElement(230, 220);
            ContinueButton.clickEvent += OnClick;
        }

        public void Update(GameTime gameTime)
        {
            ContinueButton.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            EvaluationBox.Draw(spriteBatch);
            ContinueButton.Draw(spriteBatch);
        }

        public void OnClick(string element)
        {
            if (element == "Buttons\\Continue_Button")
            {
                EndBattle = true;
            }
        }
    }
}
