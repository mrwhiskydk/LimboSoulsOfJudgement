using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Abstract Class that represents the default functionality and game logic for the current VendorUI Button GameObject
    /// </summary>
    public abstract class Button : GameObject
    {
        /// <summary>
        /// Sets the current Stat value, of the current button.
        /// Has no impact and/or changes to the player stat itself
        /// </summary>
        public int currentStatValue;

        /// <summary>
        /// Sets the current Stat value, of the current button.
        /// Used instead of currentStatValue, if current stat is to have decimal numbers
        /// </summary>
        public float currentFloatStatValue;

        /// <summary>
        /// Sets the maximum amount of stat value, that currentStatValue is able to reach
        /// </summary>
        public int maxStatValue;

        /// <summary>
        /// Sets the maximum amount of stat value, that currentFloatStatValue is able to reach.
        /// Used instead of maxStatValue, if current stat is to have decimal numbers
        /// </summary>
        public float maxFloatStatValue;

        /// <summary>
        /// Sets the actual increase amount of value to the player stat values.
        /// Used instead of statIncrease, if current stat is to have decimal numbers
        /// </summary>
        public float floatStatIncrease;

        /// <summary>
        /// Sets the maximum aomunt of karma value required in order to buy specific weapons and stat upgrades. Used in both Good and Evil button classes 
        /// </summary>
        public int karmaRequirements;

        /// <summary>
        /// Sets the current amount of karma value gained through both Good and Evil button classes
        /// </summary>
        public int currentKarma;

        /// <summary>
        /// Sets Soul Cost value, of the current Stat. Substracts value of current player souls equal to its cost amount.
        /// </summary>
        public int statCost;

        /// <summary>
        /// Sets the actual increase amount of value to the player stat values
        /// </summary>
        public int statIncrease;

        /// <summary>
        /// Checks wether or not the current Weapon has been purchased and is equipped by the player
        /// </summary>
        public bool weaponActive;

        protected float nextClick = 0.2f;
        protected double mouseClicked;

        /// <summary>
        /// Default Constructor that sets the start position and sprite name values of the current Button GameObject
        /// </summary>
        /// <param name="startPosition">Sets the default start position of the current Button GameObject</param>
        /// <param name="spriteName">Sets the default sprite name of the current Button GameObject</param>
        public Button(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
            
        }

        /// <summary>
        /// Updates the current Button's game logic and checks if current amount of stat value is less than its max value. If true, the UpgradeStat Method is called
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            if (currentStatValue < maxStatValue)
            {
                UpgradeStat(gameTime);
            }

            base.Update(gameTime);
        }


        /// <summary>
        /// Virtual Method that enables Button click, purchase and upgrades of Player stats
        /// Handles math calculations of soul currency, stat cost and stat increase
        /// Adds a small time period between each click
        /// Enables purchase of current stat if player soul currency is equal to the stat cost as a minimum
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public abstract void UpgradeStat(GameTime gameTime);
        

        /// <summary>
        /// overridden Draw method that draws the button half transparent if pressed
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.triggerVendor && GameWorld.mouse.Click(this))
            {
                spriteBatch.Draw(sprite, position, null, Color.White * 0.5f, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, new SpriteEffects(), 0.995f);
            }
            else if (GameWorld.triggerVendor)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, new SpriteEffects(), 0.995f);
            }
        }

        
    }
}
