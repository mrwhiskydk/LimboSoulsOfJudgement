using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeMovementSpeedBtn's Button
    /// </summary>
    public class UpgradeMovementSpeedBtn : Button
    {

        /// <summary>
        /// UpgradeMovementSpeedBtn, that sets the default position and sprite name values.
        /// Also sets this Class' default values of both: currentFloatStatValue, maxFloatStatValue, StatCost and floatStatIncrease
        /// </summary>
        public UpgradeMovementSpeedBtn() : base(new Vector2(GameWorld.ui.Position.X - 250, GameWorld.ui.Position.Y + 165), "buttonUITest")
        {
            currentFloatStatValue = GameWorld.player.movementSpeed;
            maxFloatStatValue = 700f;
            statCost = 5;
            floatStatIncrease = 5f;
        }

        /// <summary>
        /// Updates the UpgradeCritChance game logic,
        /// as long as the current value amount of Movement Speed haven't reach its maximum
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the Update</param>
        public override void Update(GameTime gameTime)
        {

            if (currentFloatStatValue < maxFloatStatValue)
            {
                UpgradeStat(gameTime);
            }
        }

        /// <summary>
        /// Overridden method that enables Button click, purchase and upgrades of Player Movement Speed.
        /// Adds a small time period between each click.
        /// Increases the Movement Speed amount, equal to its value.
        /// Handles math calculations of soul currency, stat cost and stat increase
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the Update</param>
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
                GameWorld.player.movementSpeed += floatStatIncrease; //Actual increase of player values
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                statCost += 5;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
