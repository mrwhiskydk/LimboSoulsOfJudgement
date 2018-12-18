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
        protected float attackRate = 1;
        public static float currentAttackRate = 1;
        public int damage;
        public bool equipped = false;
        protected Sound sound;

        

        public Weapon(string spriteName) : base(spriteName)
        {

        }

        public virtual void Attack()
        {
            sound.Play();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (equipped)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.902f);
            }
        }
    }
}