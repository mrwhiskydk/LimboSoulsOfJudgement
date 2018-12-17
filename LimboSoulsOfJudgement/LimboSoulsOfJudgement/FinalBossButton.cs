using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the FinalBossButton
    /// </summary>
    public class FinalBossButton : Button
    {

        /// <summary>
        /// 
        /// </summary>
        public FinalBossButton() : base(new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 225), "buttonUITest")
        {


        }

        /// <summary>
        /// Updates the FinalBossButton's game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            if(GameWorld.goodKarmaButton.currentKarma >= GameWorld.goodKarmaButton.maxStatValue)
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
                GameWorld.stage = 10;
                GameWorld.teleport = true;
                GameWorld.triggerFinalBoss = true;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
