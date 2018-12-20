using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class the represents the functionality and game logic of the ResetButton's Button
    /// </summary>
    public class ResetButton : Button
    {
        /// <summary>
        /// Checks if the button has been pressed
        /// </summary>
        private bool btnPressed = false;
        /// <summary>
        /// Makes it so the button cant be pressed multiple times in a row
        /// </summary>
        private double btnPressDuration;

        /// <summary>
        /// ResetButton Constructor, that sets the default position and sprite name values
        /// </summary>
        public ResetButton() : base(new Vector2(GameWorld.ui.Position.X + 245, GameWorld.ui.Position.Y + 165), "buttonUITest")
        {

        }

        /// <summary>
        /// Updates the ResetButton's game logic.
        /// Checks if the ResetButton has been pressed, in order to set a small time period between reach click, to prevent multiple clicks at once.
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            UpgradeStat(gameTime);
            if (btnPressed == true)
            {
                btnPressDuration += gameTime.ElapsedGameTime.TotalSeconds;
                if (btnPressDuration > 2)
                {
                    btnPressed = false;
                }
            }
        }

        /// <summary>
        /// Overridden UpgradeStat Method that sets the Player a new Level for other GameObjects to enter.
        /// Adds a small time period between eachs click.
        /// 
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void UpgradeStat(GameTime gameTime)
        {
            mouseClicked += gameTime.ElapsedGameTime.TotalSeconds;
            if (GameWorld.mouse.Click(this) && GameWorld.triggerVendor && mouseClicked > nextClick && btnPressed == false)
            {
                GameWorld.levelReset = true;
                GameWorld.addLevel = true;
                GameWorld.levelCount += 0.25f;
                mouseClicked = 0;
                GameWorld.levelCounter += 1;
                GameWorld.vendor.Position = new Vector2(600, -1550);
                
                if (GameWorld.levelCounter == 2)
                {
                    GameWorld.stage = 2;
                }
                else if (GameWorld.levelCounter == 3)
                {
                    GameWorld.stage = 3;
                }
                else
                {
                    if (GameWorld.lastLevel == 1)
                    {
                        if (GameWorld.rnd.Next(1, 3) == 1)
                        {
                            GameWorld.stage = 2;
                            btnPressed = true;
                        }
                        else 
                        {
                            GameWorld.stage = 3;
                            btnPressed = true;
                        }
                    }
                    else if (GameWorld.lastLevel == 2)
                    {
                        if (GameWorld.rnd.Next(1, 3) == 1)
                        {
                            GameWorld.stage = 1;
                            btnPressed = true;
                        }
                        else 
                        {
                            GameWorld.stage = 3;
                            btnPressed = true;
                        }
                    }
                    else 
                    {
                        if (GameWorld.rnd.Next(1, 3) == 1)
                        {
                            GameWorld.stage = 1;
                            btnPressed = true;
                        }
                        else 
                        {
                            GameWorld.stage = 2;
                            btnPressed = true;
                        }
                    }

                }

            }

        }

    }

}
