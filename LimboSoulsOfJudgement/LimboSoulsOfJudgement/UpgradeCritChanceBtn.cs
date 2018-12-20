using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeCritChanceBtn
    /// </summary>
    public class UpgradeCritChanceBtn : Button
    {

        /// <summary>
        /// UpgradeCritChance Constructor, that sets the default position and sprite name values.
        /// Also sets this Class' default values of both: currentFloatStatValue, maxFloatStatValue, StatCost and floatStatIncrease
        /// </summary>
        public UpgradeCritChanceBtn() : base(new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y - 100), "buttonUITest")
        {
            currentFloatStatValue = GameWorld.player.critChance;
            maxFloatStatValue = 1.00f;
            statCost = 25;
            floatStatIncrease = 0.01f;
        }

        /// <summary>
        /// Updates the UpgradeCritChance game logic,
        /// as long as the current value amount of Crit Chance haven't reach maximum
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {

            //Substracts the floatStatIncrease value amount, to avoid overreach of maximum amount
            if (currentFloatStatValue < maxFloatStatValue - floatStatIncrease)
            {
                UpgradeStat(gameTime);
            }
        }


        /// <summary>
        /// Overridden method that enables Button click, purchase and upgrades of Player Crit Chance.
        /// Adds a small time period between each click.
        /// Increases the Crit Chance percentage amount, equal to its Crit Chance value.
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
                GameWorld.player.critChance += floatStatIncrease; //Actual increase of player values
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                statCost += 5;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
