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

        /// <summary>
        /// ResetButton Constructor, that sets the default position and sprite name values
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="spriteName"></param>
        public ResetButton() : base(new Vector2(GameWorld.ui.Position.X - 20, GameWorld.ui.Position.Y + 150), "buttonUITest")
        {

        }

        /// <summary>
        /// Updates the ResetButton's game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            UpgradeStat(gameTime);
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
            if (GameWorld.mouse.Click(this) && GameWorld.triggerVendor && mouseClicked > nextClick)
            {
                GameWorld.levelReset = true;
                GameWorld.addLevel = true;
                GameWorld.levelCount += 0.1f;
                mouseClicked = 0;
            }
        }

    }
}
