using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeHealthRegenBtn
    /// </summary>
    public class UpgradeHealthRegenBtn : Button
    {
        

        /// <summary>
        /// UpgradeHealthRegenBtn Constructor, that sets the default position and sprite name values
        /// </summary>
        public UpgradeHealthRegenBtn() : base(new Vector2(GameWorld.ui.Position.X - 475, GameWorld.ui.Position.Y + 162), "buttonUITest")
        {
            currentFloatStatValue = GameWorld.player.healthRegen;   //Sets the current regen stat value of the vendor, equal to the value of player health regen
            maxFloatStatValue = 1.00f;  //Sets the max regen stat amount, equal to 1
            statCost = 5;
            regenStatIncrease = 0.02f;  //Sets the increase of the player health regen stat itself to 0.02 upon purchase

        }

        /// <summary>
        /// Updates the UpgradeHealthBtn UpgradeStat method, 
        /// as long as the current value amount of health regen haven't reach maximum
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            if (currentFloatStatValue < maxFloatStatValue - regenStatIncrease)
            {
                UpgradeStat(gameTime);
            }
        }

        /// <summary>
        /// Overridden method that enables Button click, purchase and upgrades of Player Health Regen.
        /// Adds a small time period between each click.
        /// Increases the health regen amount, equal to its regenStatIncrease value.
        /// Handles math calculations of soul currency, stat cost and stat increase
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void UpgradeStat(GameTime gameTime)
        {
            mouseClicked += gameTime.ElapsedGameTime.TotalSeconds;
            if (GameWorld.mouse.Click(this) && GameWorld.triggerVendor && mouseClicked > nextClick)
            {
                if (GameWorld.player.currentSouls < statCost)    //Returns if the current amount of Player souls is less than the cost of the Stat
                {
                    return;
                }
                currentFloatStatValue += regenStatIncrease;   //Updates the vendor UI's stat increase 
                GameWorld.player.healthRegen += regenStatIncrease; //Actual increase of player values
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
