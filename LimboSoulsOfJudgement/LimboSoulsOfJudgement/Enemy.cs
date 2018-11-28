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

        /// <summary>
        /// If true, the enemy will follow the player until it dies
        /// </summary>
        public bool aggro = false;
        /// <summary>
        /// Checks if an enemy should go after the player horizontally
        /// </summary>
        protected bool goHorizontally;
        /// <summary>
        /// Checks if an enemy should go after the player vertically
        /// </summary>
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
                goVertically = false;
            }
            else
            {
                goHorizontally = true;
            }
            if (goHorizontally == true && health > 0)
            {
                aggro = true;
            }

            if (GameWorld.player.Position.Y + 500 <= Position.Y || GameWorld.player.Position.Y - 500 >= Position.Y)
            {

                goVertically = false;
                goHorizontally = false;
            }
            else
            {
                goVertically = true;
            }
            
           
        }

        /// <summary>
        /// Method that sets the default movement functionality of MinorEnemy and BossEnemy
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            if (aggro == true && GameWorld.player.Position.X < position.X)
            {
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (aggro == true && GameWorld.player.Position.X > position.X)
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
