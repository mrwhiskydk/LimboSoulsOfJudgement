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
        /// Default Character Constructor
        /// </summary>

        public Character(int frameCount, float animationFPS, string spriteName) : base(frameCount, animationFPS, spriteName)
        {
        }

        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //OVERRIDE FROM ANIMATED GAME OBJECT
        }

        /// <summary>
        /// Abstract method used in Player and Enemy to secure individual movement functionality between each class
        /// </summary>
        protected abstract void HandleMovement(GameTime gameTime);
    }
}
