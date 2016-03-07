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

        TextElement Character_1_GainedXP;
        TextElement Character_2_GainedXP;
        TextElement Character_3_GainedXP;
        TextElement Character_4_GainedXP;

        private TextElement Character;
        public bool EndBattle
        {
            get { return endBattle; }
            set { endBattle = value; }
        }

        GUIElement EvaluationBox;
        GUIElement ContinueButton;
        
        public BattleEvaluationEvent()
        {
            ContinueButton = new GUIElement("Buttons\\Continue_Button");
            EvaluationBox = new GUIElement("Backgrounds\\Menus\\BattleEvaluationBackground");
        }

        public void LoadContent(ContentManager content)
        {
            EvaluationBox.LoadContent(content);
            ContinueButton.LoadContent(content);
            ContinueButton.CenterElement(576, 720);
            ContinueButton.moveElement(160, 160);
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
