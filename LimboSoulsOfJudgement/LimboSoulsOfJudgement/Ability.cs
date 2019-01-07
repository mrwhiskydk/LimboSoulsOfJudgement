using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Abstract Class that represents the functionality and game logic of the Ability GameObjectPassive.
    /// This Class contains most of the default fields and methods used within each of its Sub-Classes.
    /// </summary>
    public abstract class Ability : GameObjectPassive
    {
        /// <summary>
        /// The cooldown time on the ability
        /// </summary>
        protected double cooldown;
        /// <summary>
        /// Timer used with cooldown
        /// </summary>
        protected double cooldownTimer;
        /// <summary>
        /// Creates a new AbilityCooldown to show how much time is left on the cooldown
        /// </summary>
        protected AbilityCooldown abilityCooldown;
        /// <summary>
        /// Used to play sounds
        /// </summary>
        protected Sound sound;

        /// <summary>
        /// Default Ability's Constructor
        /// </summary>
        /// <param name="spriteName">Name of the sprite</param>
        public Ability(string spriteName) : this(Vector2.Zero, spriteName)
        {
            
        }


        /// <summary>
        /// Ability's Constructor that sets the default values of starting position and sprite name.
        /// Also sets a new AbilityCooldown GameObjectPassive, to the current Ability GameObjectPassive 
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
        /// <param name="gameTime">Time elapsed since last call in the update</param>
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
            /// <param name="spriteBatch">The spritebatch used for drawing</param>
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