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

        /// <summary>
        /// Overridden Draw Method that draws out the sprite of (currently only Lightning Bolt) Ability if purchased through BuyLightningBoltButton Class.
        /// While not purchased, the sprite is still being drawn out, but it is 100% transparent.
        /// Should override this method in LightningBolt Class, once Evil Ability has been created, or this will apply to all abilities
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.buyLightningBoltButton.abilityPurchased)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.981f);
            }
            else
            {
                spriteBatch.Draw(sprite, position, null, Color.White * 0.0f, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.981f);
            }
            
        }
    }
}