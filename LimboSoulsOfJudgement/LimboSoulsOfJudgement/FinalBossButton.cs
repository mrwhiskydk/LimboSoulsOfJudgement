using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the FinalBossButton's Button
    /// </summary>
    public class FinalBossButton : Button
    {

        /// <summary>
        /// FinalBossButton's Constructor, that sets the default position and sprite name values.
        /// </summary>
        public FinalBossButton() : base(new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 225), "buttonUITest")
        {

        }

        /// <summary>
        /// Updates the FinalBossButton's game logic.
        /// Also checks if either the current good or bad karma value has reached its maximum, in order to begin purchasing process
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            if(GameWorld.goodKarmaButton.currentKarma >= GameWorld.goodKarmaButton.maxStatValue || GameWorld.badKarmaButton.currentKarma >= GameWorld.badKarmaButton.maxStatValue)
            {
                UpgradeStat(gameTime);
            }
        }

        /// <summary>
        /// Sets the current level state to 10, meaning the Player will be transfered to the final boss room of the game.
        /// Adds a small time period between eachs click
        /// Sets the value of triggerFinalBoss to true, which enables the sprite and game functionality of the final boss
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the Update</param>
        public override void UpgradeStat(GameTime gameTime)
        {
            mouseClicked += gameTime.ElapsedGameTime.TotalSeconds;
            if (GameWorld.mouse.Click(this) && GameWorld.triggerVendor && mouseClicked > nextClick)
            {
                GameWorld.stage = 10;
                GameWorld.teleport = true;
                GameWorld.triggerFinalBoss = true;
                GameWorld.vendor.Position = new Vector2(300, - 1500);
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
