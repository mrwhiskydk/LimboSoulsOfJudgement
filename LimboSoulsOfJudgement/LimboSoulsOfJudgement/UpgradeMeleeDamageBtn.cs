using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeDamageBtn's Button
    /// </summary>
    public class UpgradeMeleeDamageBtn : Button
    {

        /// <summary>
        /// UpgradeMeleeDamageBtn Constructor, that sets the default position and sprite name values.
        /// Also sets this Class' default values of both: currentStatValue, maxStatValue, StatCost and statIncrease
        /// </summary>
        public UpgradeMeleeDamageBtn() : base(new Vector2(GameWorld.ui.Position.X + 85, GameWorld.ui.Position.Y + 135), "buttonUITest")
        {
            currentStatValue = GameWorld.player.melee.damage;
            maxStatValue = 100000;
            statCost = 50;
            statIncrease = 1;
        }

        /// <summary>
        /// Updates the UpgradeMeleeDamageBtn's game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the Update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        /// <summary>
        /// Overridden method that enables Button click, purchase and upgrades of Player Melee Damage.
        /// Adds a small time period between each click.
        /// Increases the Damage amount, equal to its value.
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
                currentStatValue += statIncrease;   //Updates the vendor UI's stat increase 
                GameWorld.player.melee.damage += statIncrease; //Actual increase of player values
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                statCost += 10;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
