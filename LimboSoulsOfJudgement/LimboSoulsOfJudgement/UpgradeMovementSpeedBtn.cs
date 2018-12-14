using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeMovementSpeedBtn
    /// </summary>
    public class UpgradeMovementSpeedBtn : Button
    {

        /// <summary>
        /// UpgradeMovementSpeedBtn, that sets the default position and sprite name values
        /// </summary>
        public UpgradeMovementSpeedBtn() : base(new Vector2(GameWorld.ui.Position.X - 200, GameWorld.ui.Position.Y + 165), "buttonUITest")
        {
            currentFloatStatValue = GameWorld.player.movementSpeed;
            maxFloatStatValue = 850f;
            statCost = 5;
            floatStatIncrease = 5f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if(currentFloatStatValue < maxFloatStatValue)
            {
                UpgradeStat(gameTime);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
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
                statCost += 1;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
