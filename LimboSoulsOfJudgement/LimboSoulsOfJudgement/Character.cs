using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public abstract class Character
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
        public Character()
        {

        }

        /// <summary>
        /// Method that updates general logic of the game
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            //OVERRIDE FROM ANIMATED GAME OBJECT
        }

        /// <summary>
        /// Abstract method used in Player and Enemy to secure individual movement functionality between each class
        /// </summary>
        protected abstract void HandleMovement(GameTime gameTime);
    }
}
