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
        /// <summary>
        /// Constructor
        /// </summary>
        public LightningBoltAbility() : base("LightningBoltAbility")
        {
            cooldown = 10;
            cooldownTimer = cooldown;
            sound = new Sound("sound/lightningbolt");
        }

        /// <summary>
        /// Used to activate the ability
        /// </summary>
        public override void UseAbility()
        {
            base.UseAbility();
            Vector2 playerPosition = GameWorld.player.Position;
            Vector2 direction = new Vector2(GameWorld.mouse.Position.X, GameWorld.mouse.Position.Y) - playerPosition;

            new LightningBolt(playerPosition, direction);
        }

        /// <summary>
        /// Method gets run every game tick to update position to the ability bar
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position = UIAbilityBar.abilitySlot2;
        }

        /// <summary>
        /// Overridden Draw Method that draws out the sprite of Lightning Bolt Ability, if purchased through BuyLightningBoltButton Class.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.buyLightningBoltButton.abilityPurchased)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.992f);
            }
        }


        public class LightningBolt : AnimatedGameObject
        {
            private int speed = 1000;
            public static int damage = 15;
            private Vector2 dir;
            private double timeAlive = 0;

            /// <summary>
            /// Constructor 
            /// </summary>
            /// <param name="startPosition">Start position of the ability</param>
            /// <param name="dir">The direction to fly</param>
            public LightningBolt(Vector2 startPosition, Vector2 dir) : base(4, 20, startPosition, "LightningBolt")
            {
                this.dir = dir;

                if (this.dir != Vector2.Zero)
                {
                    this.dir.Normalize();
                }

                rotation = (float)Math.Atan2(dir.Y, dir.X);
            }

            /// <summary>
            /// Method gets run every game tick to propel forward the ability and checks how long the ability has been active for
            /// </summary>
            /// <param name="gameTime"></param>
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

            /// <summary>
            /// Check if we are colliding with an enemy
            /// </summary>
            /// <param name="otherObject">The object we are colliding with</param>
            public override void DoCollision(GameObject otherObject)
            {
                if (otherObject is Enemy)
                {
                    Enemy obj = (Enemy)otherObject;
                    obj.Health -= damage;
                    obj.aggro = true;
                }
            }

            /// <summary>
            /// Method that draws the ability
            /// </summary>
            /// <param name="spriteBatch"></param>
            public override void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.991f);
            }
        }
    }
}
