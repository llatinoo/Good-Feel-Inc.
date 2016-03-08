using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class Skill
    {
        private Animation animation;
        private Vector2 position;

        public string Name { get; private set; }
        public int Manacosts { get; private set; }
        public string Target { get; private set; }
        public string AreaOfEffect { get; private set; }

        public string Description { get; private set; }

        public Animation Animation { get; private set; }

        //Liste von Effekten die der Skill verursacht
        public IEnumerable<IEffect> Effects { get; set; }

        public Skill(string skillName, int manacosts, string target, string areaOfEffect, string description, IEnumerable<IEffect> skilleffects)
        {
            this.Name = skillName;
            this.Manacosts = manacosts;
            this.Target = target;
            this.AreaOfEffect = areaOfEffect;
            this.Description = description;
            this.Effects = skilleffects;
        }

        //Ausführung des ClassSkills
        public void Execute(Character source, List<Character> targets)
        {
            //Führt alle Effekte des ClassSkills aus
            source.Mana -= this.Manacosts;
            foreach (IEffect effect in this.Effects)
            {
                effect.Execute(source, targets);
            }       
        }

        public void SetAnimation(Animation animation)
        {
            this.Animation = animation;
        }

        public void LoadContent(Animation animation, Vector2 position)
        {
            this.animation = animation;
            this.position = position;
        }
        public void Update(GameTime gameTime)
        {
            this.animation.position = this.position;
            this.animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.animation.Draw(spriteBatch);
        }
    }
}
