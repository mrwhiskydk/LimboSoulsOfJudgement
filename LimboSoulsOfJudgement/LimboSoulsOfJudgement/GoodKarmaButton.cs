using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the GoodKarmaButton
    /// </summary>
    public class GoodKarmaButton : Button
    {


        /// <summary>
        /// GoodKarmaButton Constructor, that sets the default position and sprite name values
        /// </summary>
        public GoodKarmaButton() : base(new Vector2(GameWorld.ui.Position.X - 75, GameWorld.ui.Position.Y - 162), "buttonUITest")
        {
            currentStatValue = 0;
            maxStatValue = 50;
            statCost = 5;
            statIncrease = 1;
            currentKarma = 0;
        }

        /// <summary>
        /// Updates the GoodKarmaButton's game logic
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
            currentKarma += currentStatValue;
        }
    }
}
