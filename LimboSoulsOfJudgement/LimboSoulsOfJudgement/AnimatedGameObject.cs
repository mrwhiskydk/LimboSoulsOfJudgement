using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class AnimatedGameObject : GameObject
    {
        protected Rectangle[] animationRectangles;

        protected float animationFPS = 10;
        protected int currentAnimationIndex = 0;
        double timeElapsed = 0;
        /// <summary>
        /// Bool that checks for the current direction of the GameObject, on the X axis
        /// </summary>
        public bool facingRight;

        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - animationRectangles[0].Width * 0.5), (int)(position.Y - animationRectangles[0].Height * 0.5), animationRectangles[0].Width, animationRectangles[0].Height);
            }
        }

        public AnimatedGameObject(int frameCount, float animationFPS, string spriteName) : this(frameCount, animationFPS, Vector2.Zero, spriteName)
        {
                        
        }

        public AnimatedGameObject(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(startPostion, spriteName)
        {
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                animationRectangles[i] = new Rectangle(i * (sprite.Width / frameCount), 0, (sprite.Width / frameCount), sprite.Height);
            }
            currentAnimationIndex = 0;
        }

        /// <summary>
        /// Updates the GameObject's logic and progresses the animation cycle
        /// </summary>
        /// <param name="gameTime">Takes a GameTime the provides the timespan since last call to update </param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndex > animationRectangles.Count() - 1)
            {
                currentAnimationIndex = 0;
                timeElapsed = 0;
            }

        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            if (facingRight == true)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.9f);
            }
            else if (facingRight == false)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.FlipHorizontally, 0.9f);
            }
        }

    }
}
