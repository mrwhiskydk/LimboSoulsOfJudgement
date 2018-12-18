using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class the represents the functionality and game logic of the ResetButton
    /// </summary>
    public class ResetButton : Button
    {
        private bool btnPressed = false;
        private double btnPressDuration;

        /// <summary>
        /// ResetButton Constructor, that sets the default position and sprite name values
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="spriteName"></param>
        public ResetButton() : base(new Vector2(GameWorld.ui.Position.X - - 515, GameWorld.ui.Position.Y + 150), "buttonUITest")
        {

        }

        /// <summary>
        /// Updates the ResetButton's game logic
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
                    btnPressDuration = 0;
                }
            }
        }

        /// <summary>
        /// Overridden UpgradeStat Method that sets its game logic
        /// Increases the player's max health equal to its statIncease value
        /// Sets the player's current health equal to the increased max health upon purchase
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void UpgradeStat(GameTime gameTime)
        {
            mouseClicked += gameTime.ElapsedGameTime.TotalSeconds;
            if (GameWorld.mouse.Click(this) && GameWorld.triggerVendor && mouseClicked > nextClick && btnPressed == false)
            {
                GameWorld.levelReset = true;
                GameWorld.addLevel = true;
                GameWorld.levelCount += 0.15f;
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
                    if (GameWorld.level.lastLevel == 1)
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
                    else if (GameWorld.level.lastLevel == 2)
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
