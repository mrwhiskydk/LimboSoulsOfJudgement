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
        protected AbilityCooldown abilityCooldown;
        protected Sound sound;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="spriteName">Name of the sprite</param>
        public Ability(string spriteName) : this(Vector2.Zero, spriteName)
        {
            
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="spriteName">Name of the sprite</param>
        public Ability(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
            abilityCooldown = new AbilityCooldown(this);
        }

        /// <summary>
        /// This method will be run every game tick
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (cooldownTimer < cooldown)
            {
                cooldownTimer += gameTime.ElapsedGameTime.TotalSeconds;
            }
        }


        /// <summary>
        /// Call to check if cooldown has passed and we can use the ability
        /// </summary>
        public virtual void Use()
        {
            if (cooldownTimer >= cooldown)
            {
                UseAbility();
                cooldownTimer = 0;
            }
        }

        /// <summary>
        /// Activate the ability
        /// </summary>
        public virtual void UseAbility()
        {
            sound.Play();
        }


        /// <summary>
        /// In case we want to switch abilities we can destroy this one. Also makes sure to destroy the abilitycooldown
        /// </summary>
        public override void Destroy()
        {
            base.Destroy();
            abilityCooldown.Destroy();
        }

        public class AbilityCooldown : GameObjectPassive
        {
            private Ability ability;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="ability">Takes an ability as a parameter to display a gray bar on top of it when on cooldown</param>
            public AbilityCooldown(Ability ability) : base("AbilityCooldown")
            {
                this.ability = ability;
                rotation = MathHelper.ToRadians(180);
            }

            /// <summary>
            /// Draw the cooldown bar taking into calculations the remaining cooldown time
            /// </summary>
            /// <param name="spriteBatch"></param>
            public override void Draw(SpriteBatch spriteBatch)
            {
                if (ability.cooldownTimer < ability.cooldown)
                {
                    double size = sprite.Height * (1 - ((ability.cooldownTimer / ability.cooldown)));
                    Rectangle rect = new Rectangle((int)position.X, (int)position.Y, sprite.Width, (int)size);
                    spriteBatch.Draw(sprite, ability.Position, rect, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.993f);
                }
            }
        }
        
    }
}