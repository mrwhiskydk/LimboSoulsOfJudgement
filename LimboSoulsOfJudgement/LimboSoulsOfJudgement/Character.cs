using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class Character : AnimatedGameObject
    {
        protected int health;
        protected int maxHealth;
        protected float movementSpeed;

        protected int Health { get; set; }

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
    }
}
