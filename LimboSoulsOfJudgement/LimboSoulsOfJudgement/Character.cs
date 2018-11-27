using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public abstract class Character : AnimatedGameObject
    {
        protected int health;
        protected int maxHealth;
        protected float movementSpeed;

        /// <summary>
        /// Property that sets the health value of the current GameObject
        /// </summary>
        protected int Health { get; set; }

        /// <summary>
        /// Property that sets the max health value of the current GameObject
        /// </summary>
        protected int MaxHealth { get; set; }

        /// <summary>
        /// Character Constructor that enables gravity as default
        /// </summary>
        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            gravity = true;
        }

        /// <summary>
        /// Method that updates game logic
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Abstract method used in Player and Enemy to secure individual movement functionality between each class
        /// </summary>
        protected abstract void HandleMovement(GameTime gameTime);
    }
}
