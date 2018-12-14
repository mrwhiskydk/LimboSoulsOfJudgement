using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{

    public class LightningBoltAbility : Ability
    {
        

        public LightningBoltAbility() : base("LightningBoltAbility")
        {
            cooldown = 10;
            cooldownTimer = cooldown;
        }

        public override void UseAbility()
        {
            Vector2 playerPosition = GameWorld.player.Position;
            Vector2 direction = new Vector2(GameWorld.mouse.Position.X, GameWorld.mouse.Position.Y) - playerPosition;

            new LightningBolt(playerPosition, direction);
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

        class LightningBolt : AnimatedGameObject
        {
            private int speed = 1000;
            public int damage = 25;
            private Vector2 dir;
            private double timeAlive = 0;

            public LightningBolt(Vector2 startPosition, Vector2 dir) : base(4, 20, startPosition, "LightningBolt")
            {
                this.dir = dir;

                if (this.dir != Vector2.Zero)
                {
                    this.dir.Normalize();
                }

                rotation = (float)Math.Atan2(dir.Y, dir.X);
            }

            public override void Update(GameTime gameTime)
            {
                position += dir * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                base.Update(gameTime);

                timeAlive += gameTime.ElapsedGameTime.TotalSeconds;
                if (timeAlive >= 3)
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
                    obj.aggro = true;
                }
            }

            public override void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.991f);
            }
        }
    }
}
