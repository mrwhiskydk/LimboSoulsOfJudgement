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
        /// <summary>
        /// Constructor that sets the cooldown and sprite
        /// </summary>
        public BloodstormAbility() : base("BloodstormAbility")
        {
            cooldown = 10;
            cooldownTimer = cooldown;
            sound = new Sound("sound/bloodstorm");
        }

        /// <summary>
        /// Creates a new Bloodstorm ability
        /// </summary>
        public override void UseAbility()
        {
            base.UseAbility();
            new Bloodstorm();
        }

        /// <summary>
        /// Updates the position of the bloodstorm icon
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position = UIAbilityBar.abilitySlot1;
        }

        /// <summary>
        /// Overridden Draw Method that draws out the sprite of BloodStorm Ability, if purchased through BuyBloodStormButton Class.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.buyBloodStormButton.abilityPurchased)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.992f);
            }         
        }


        public class Bloodstorm : AnimatedGameObject
        {
            /// <summary>
            /// The damage of the ability
            /// </summary>
            public static int damage = 15;

            /// <summary>
            /// Constructor
            /// </summary>
            public Bloodstorm() : base(23, 48, GameWorld.player.Position, "Bloodstorm")
            {
                
            }

            /// <summary>
            /// Updates the position and if the animation is complete destroy the object
            /// </summary>
            /// <param name="gameTime">Time elapsed since last call in the update</param>
            public override void Update(GameTime gameTime)
            {
                position = GameWorld.player.Position;
                 
                base.Update(gameTime);

                if (currentAnimationIndex == 22)
                {
                    Destroy();
                }
            }

            /// <summary>
            /// If colliding with an enemy, deal damage
            /// </summary>
            /// <param name="otherObject">GameObject that the ability is colliding with</param>
            public override void DoCollision(GameObject otherObject)
            {
                if (otherObject is Enemy)
                {
                    Enemy obj = (Enemy)otherObject;
                    obj.Health -= damage;
                }
            }

            /// <summary>
            /// Draws the sprite
            /// </summary>
            /// <param name="spriteBatch">The spritebatch used for drawing</param>
            public override void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.White, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.991f);
            }
        }
    }
}
