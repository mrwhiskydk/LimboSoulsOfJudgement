using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class Enemy : Character
    {
        public int enemyDamage;
        public bool aggro;
        protected bool goHorizontally;
        protected bool goVertically;

        /// <summary>
        /// Enemy constructor that sets animation values, position and sprite names of MinorEnemy and BossEnemy
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public Enemy(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {

        }

        /// <summary>
        /// Update method that enables movement of the Enemy GameObject
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (GameWorld.player.Position.X + 500 <= Position.X || GameWorld.player.Position.X - 500 >= Position.X )
            {
                goHorizontally = false;
            }
            else
            {
                goHorizontally = true;
            }
            if (GameWorld.player.Position.Y + 500 <= Position.Y || GameWorld.player.Position.Y - 500 >= Position.Y)
            {

                goVertically = true;
            }
            else
            {
                goVertically = false;
            }
            
           
        }

        /// <summary>
        /// Method that sets the default movement functionality of MinorEnemy and BossEnemy
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            if (goHorizontally == true && GameWorld.player.Position.X < position.X || aggro == true)
            {
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (goHorizontally == true && GameWorld.player.Position.X > position.X || aggro == true)
            {
                position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        /// <summary>
        /// Method that handles Enemies collision with other GameObjects
        /// </summary>
        /// <param name="otherObject">The GameObject that the player object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is Player)
            {

            }
        }

    }
}
