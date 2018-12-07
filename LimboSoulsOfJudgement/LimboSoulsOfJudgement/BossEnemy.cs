using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class BossEnemy : Enemy
    {

        /// <summary>
        /// BossEnemy constructor that sets animation values, position and sprite names of current BossEnemy GameObject
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public BossEnemy() : base(5, 5, new Vector2(5750, 3328), "Boss")
        {
            movementSpeed = 300;
            enemyHealth = 200;
            enemyDamage = 20;
            enemySouls = 50;
            soulCount = 10;
            patrolDuration = 2f;
        }


        /// <summary>
        /// Method that updates game logic of the current BossEnemy GameObject
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);

        }


        protected override void HandleMovement(GameTime gameTime)
        {
            base.HandleMovement(gameTime);
            Gravity = false;
            if (aggro == true && GameWorld.player.Position.Y < position.Y)
            {
                position.Y -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (goVertically == true && GameWorld.player.Position.Y > position.Y)
            {
                position.Y += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

        }

    }
}
