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
        /// <summary>
        /// The rectangle being used when animating sprites
        /// </summary>
        protected Rectangle[] animationRectangles;

        /// <summary>
        /// the speed of the animation
        /// </summary>
        protected float animationFPS = 10;
        /// <summary>
        /// the specific frame of the sprite
        /// </summary>
        protected int currentAnimationIndex = 0;
        private double timeElapsed = 0;
        /// <summary>
        /// Bool that checks for the current direction of the GameObject, on the X axis
        /// </summary>
        public bool facingRight;

        /// <summary>
        /// Get-Property that returns a CollisionBox based on the current frame and not the entire sprite
        /// </summary>
        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - animationRectangles[0].Width * 0.5), (int)(position.Y - animationRectangles[0].Height * 0.5), animationRectangles[0].Width, animationRectangles[0].Height);
            }
        }

        /// <summary>
        /// Constructor that creates the amount of frames
        /// </summary>
        /// <param name="frameCount">How many frames in the spritesheet</param>
        /// <param name="animationFPS">The speed the frames change</param>
        /// <param name="startPostion">The start position</param>
        /// <param name="spriteName">Name of the sprite</param>
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

        /// <summary>
        /// Method to change the sprite of an animated gameobject
        /// </summary>
        /// <param name="frameCount">How many frames in the spritesheet</param>
        /// <param name="spriteName">Name of the sprite</param>
        public void State(int frameCount, string spriteName)
        {
            if (sprite.Name != spriteName) //Make sure its not the same sprite so we dont keep "resetting" the sprite to frame 1 never having any animation
            {
                sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
                animationRectangles = new Rectangle[frameCount];
                for (int i = 0; i < frameCount; i++)
                {
                    animationRectangles[i] = new Rectangle(i * (sprite.Width / frameCount), 0, (sprite.Width / frameCount), sprite.Height);
                }
                currentAnimationIndex = 0;
            }
        }

        /// <summary>
        /// Draws the current animation index
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
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
