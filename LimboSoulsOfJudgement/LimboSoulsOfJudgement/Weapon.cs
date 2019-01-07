using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the Weapon GameObject
    /// </summary>
    public abstract class Weapon : GameObject
    {
        /// <summary>
        /// The base attack rate of the weapon
        /// </summary>
        protected float attackRate = 1; //base attack rate
        /// <summary>
        /// Used to increase the attackrate
        /// </summary>
        public static float currentAttackRate = 1; //use for buffing attack rate
        /// <summary>
        /// The damage of the weapon
        /// </summary>
        public int damage;
        /// <summary>
        /// is the weapon currently in our hands/ currently equipped
        /// </summary>
        public bool equipped = false; //is the weapon currently in our hands/ currently equipped
        /// <summary>
        /// Used to play sounds
        /// </summary>
        protected Sound sound;

        
        /// <summary>
        /// Constructor for weapons
        /// </summary>
        /// <param name="spriteName">name of the sprite</param>
        public Weapon(string spriteName) : base(spriteName)
        {

        }

        /// <summary>
        /// This method runs if we attack 
        /// </summary>
        public virtual void Attack()
        {
            sound.Play();
        }

        /// <summary>
        /// This is used to draw our weapon
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //only draw if the weapon is equipped
            if (equipped)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.802f);
            }
        }
    }
}