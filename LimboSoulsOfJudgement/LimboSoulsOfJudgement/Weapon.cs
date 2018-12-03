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
        protected int damage = 1;
        public bool equipped = false;

        public Weapon(string spriteName) : base(spriteName)
        {

        }

        public virtual void Attack()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (equipped)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.81f);
            }
        }
    }
}