using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    public abstract class Weapon : GameObject
    {
        protected float attackRate = 1; //base attack rate
        public static float currentAttackRate = 1; //use for buffing attack rate
        public int damage;
        public bool equipped = false; //is the weapon currently in our hands/ currently equipped
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
        /// <param name="spriteBatch"></param>
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