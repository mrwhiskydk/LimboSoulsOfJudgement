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
        public BadKarmaButton() : base(new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 218), "buttonUITest")
        {
            currentStatValue = 0;
            maxStatValue = 50;
            statCost = 5;
            statIncrease = 1;

            currentKarma = 0;
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
            mouseClicked += gameTime.ElapsedGameTime.TotalSeconds;
            if (GameWorld.mouse.Click(this) && GameWorld.triggerVendor && mouseClicked > nextClick)
            {
                if (GameWorld.player.currentSouls < statCost)    //Returns if the current amount of Player souls is less than the cost of the Stat
                {
                    return;
                }              
                currentStatValue += statIncrease;   //Adds value to the current amount of Karma equal to its stat cost   
                currentKarma += statIncrease;   //Adds value to current Karma amount, equal to the upgrade value amount of the current Stat
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                statCost += 1;
                mouseClicked = 0;
            }
        }


    }
}
