using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class MinorEnemy : Enemy
    {
        public int karma;
        
        /// <summary>
        /// MinorEnemy constructor that sets animation values, position and sprite names of current MinorEnemy GameObject
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public MinorEnemy() : base(5, 5, new Vector2(1700, 700), "Boss")
        {
            movementSpeed = 100;
            health = 100;
        }

        /// <summary>
        /// Method that updates game logic of the current MinorEnemy GameObject
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

        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
        }

    }
}
