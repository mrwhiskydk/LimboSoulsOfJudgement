using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeHealthBtn's Button
    /// </summary>
    public class UpgradeHealthBtn : Button
    {

        /// <summary>
        /// UpgradeHealthBtn Constructor, that sets the default position and sprite name values.
        /// Also sets this Class' default values of both: currentStatValue, maxStatValue, StatCost and statIncrease
        /// </summary>
        public UpgradeHealthBtn() : base(new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 10), "buttonUITest")
        {
            currentStatValue = GameWorld.player.maxHealth;
            maxStatValue = 100000;
            statCost = 5;
            statIncrease = 5;
        }

        /// <summary>
        /// Updates the UpgradeHealthBtn's game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


        }

        /// <summary>
        /// Overridden UpgradeStat Method that enables button click, purchase and upgrades of the Player Health stat.
        /// Adds a small time period between each click.
        /// Increases the player's max health equal to its statIncease value.
        /// Sets the player's current health equal to the increased max health upon purchase
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
                currentStatValue += statIncrease;   //Updates the vendor UI's stat increase 
                GameWorld.player.maxHealth += statIncrease; //Actual increase of player values
                GameWorld.player.Health = GameWorld.player.maxHealth;   //Sets current player health equal to increased player health
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                statCost += 10;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
