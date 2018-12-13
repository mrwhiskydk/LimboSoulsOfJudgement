﻿using System;
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
        public UpgradeLifetealBtn() : base(new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 162), "buttonUITest")
        {
            currentStatValue = (int)GameWorld.player.lifeSteal;
            maxStatValue = (int)1f;
            statCost = 5;
            statIncrease = (int)0.02f;
        }

        /// <summary>
        /// Updates the UpgradeLifestealBtn game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// 
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
                GameWorld.player.lifeSteal += statIncrease; //Actual increase of player values
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
