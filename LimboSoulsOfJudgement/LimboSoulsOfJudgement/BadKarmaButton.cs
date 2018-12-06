using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the BadKarmaButton
    /// </summary>
    public class BadKarmaButton : Button
    {
        
        /// <summary>
        /// BadKarmaButton Constructor, that sets the default position and sprite name values
        /// </summary>
        public BadKarmaButton() : base(new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 150), "buttonUITest")
        {
            currentStatValue = 0;
            maxStatValue = 50;
            statCost = 2;
            statIncrease = 2;
        }

        /// <summary>
        /// Updates the BadKarmaButton's game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Overridden UpgradeStat Method that sets its game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void UpgradeStat(GameTime gameTime)
        {
            base.UpgradeStat(gameTime);
        }


    }
}
