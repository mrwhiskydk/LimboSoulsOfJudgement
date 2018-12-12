using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    public abstract class Ability : GameObjectPassive
    {
        protected double cooldown;
        protected double cooldownTimer;

        public Ability(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (cooldownTimer < cooldown)
            {
                cooldownTimer += gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public virtual void Use()
        {
            if (cooldownTimer >= cooldown)
            {
                UseAbility();
                cooldownTimer = 0;
            }
        }

        public abstract void UseAbility();

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.87f);
        }
    }
}