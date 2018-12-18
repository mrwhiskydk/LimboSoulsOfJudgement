using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeLifestealBtn
    /// </summary>
    public class UpgradeLifetealBtn : Button
    {

        /// <summary>
        /// UpgradeLifestealBtn Constructor, that sets the default position and sprite name values
        /// </summary>
        public UpgradeLifetealBtn() : base(new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y + 25), "buttonUITest")
        {
            currentFloatStatValue = GameWorld.player.lifeSteal;
            maxFloatStatValue = 1f;
            karmaRequirements = 2;
            statCost = 10;
            floatStatIncrease = 0.1f;
        }

        /// <summary>
        /// Updates the UpgradeLifestealBtn game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {

            if (GameWorld.badKarmaButton.currentKarma >= karmaRequirements && currentFloatStatValue < maxFloatStatValue)
            {
                UpgradeStat(gameTime);
            }
        }

        /// <summary>
        /// Overridden method that enables Button click, purchase and upgrades of Player Lifesteal.
        /// Adds a small time period between each click.
        /// Increases the Lifesteal percentage amount, equal to its Lifesteal value.
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
                currentFloatStatValue += floatStatIncrease;   //Updates the vendor UI's stat increase 
                GameWorld.player.lifeSteal += floatStatIncrease; //Actual increase of player values
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                karmaRequirements += 2;
                statCost += 1;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
