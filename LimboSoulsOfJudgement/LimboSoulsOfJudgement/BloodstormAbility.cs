using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    class BloodstormAbility : Ability
    {
        public BloodstormAbility() : base("BloodstormAbility")
        {
            cooldown = 1;
            cooldownTimer = cooldown;
        }

        public override void UseAbility()
        {
            new Bloodstorm();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position = UIAbilityBar.abilitySlot1;
        }

        /// <summary>
        /// Overridden Draw Method that draws out the sprite of Lightning Bolt Ability, if purchased through BuyLightningBoltButton Class.
        /// While not purchased, the sprite is still being drawn out, but it is 100% transparent.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.buyLightningBoltButton.abilityPurchased)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.992f);
            }
            else
            {
                spriteBatch.Draw(sprite, position, null, Color.White * 0.0f, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.992f);
            }

        }
        class Bloodstorm : AnimatedGameObject
        {
            private int damage = 15;

            public Bloodstorm() : base(23, 36, GameWorld.player.Position, "Bloodstorm")
            {
                
            }

            public override void Update(GameTime gameTime)
            {
                position = GameWorld.player.Position;
                 
                base.Update(gameTime);

                if (currentAnimationIndex == 22)
                {
                    Destroy();
                }
            }

            public override void DoCollision(GameObject otherObject)
            {
                if (otherObject is Enemy)
                {
                    Enemy obj = (Enemy)otherObject;
                    obj.Health -= damage;
                }
            }

            public override void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.991f);
            }
        }
    }
}
