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
        public int currentStatValue;
        public int maxStatValue;

        public int statCost;
        public int statIncrease;

        protected float nextClick = 0.3f;
        protected double mouseClicked;

        /// <summary>
        /// Default Constructor that sets the start position and sprite name values of the current Button GameObject
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="spriteName"></param>
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
        /// Handles  math calculations of soul currency, stat cost and stat increase
        /// Adds a small time period between each click
        /// Enables purchase of current stat if player soul currency is equal to the stat cost as a minimum
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public virtual void UpgradeStat(GameTime gameTime)
        {
            mouseClicked += gameTime.ElapsedGameTime.TotalSeconds;
            if (GameWorld.mouse.Click(this) && GameWorld.triggerVendor && mouseClicked > nextClick)
            {
                if (GameWorld.player.currentSouls < statCost)    //Returns if the current amount of Player souls is less than the cost of the Stat
                {
                    return;
                }
                currentStatValue += statIncrease;   //Adds value to the current amount of Karma equal to its stat cost               
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                mouseClicked = 0;
            }
        }

        /// <summary>
        /// overridden Draw method that draws the button half transparent if pressed
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.triggerVendor && GameWorld.mouse.Click(this))
            {
                spriteBatch.Draw(sprite, position, null, Color.White * 0.5f, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, new SpriteEffects(), 0f);
            }
            else if (GameWorld.triggerVendor)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, new SpriteEffects(), 0f);
            }
        }
    }
}
