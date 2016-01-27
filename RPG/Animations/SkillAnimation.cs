using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class SkillAnimation
    {
        
        // Animation
        public Animation skillAnimation;

        // Position Der Animation
        public Vector2 position;

        public void LoadContent(Animation animation, Vector2 position)

        {
            this.skillAnimation = animation;

            // setzt die Position der Animation
            this.position = position;
        }

        public void Update(GameTime gameTime)

        {
            this.skillAnimation.position = this.position;
            this.skillAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.skillAnimation.Draw(spriteBatch);
        }
        

    }
}
