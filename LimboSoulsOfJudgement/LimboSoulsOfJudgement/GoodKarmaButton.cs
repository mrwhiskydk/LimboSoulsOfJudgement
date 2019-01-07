using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the GoodKarmaButton's Button
    /// </summary>
    public class GoodKarmaButton : Button
    {


        /// <summary>
        /// GoodKarmaButton Constructor, that sets the default position and sprite name values.
        /// Also sets this Class' default values of both: currentStatValue, maxStatValue, StatCost, statIncrease and currentKarma.
        /// </summary>
        public GoodKarmaButton() : base(new Vector2(GameWorld.ui.Position.X - 500, GameWorld.ui.Position.Y - 218), "buttonUITest")
        {
            currentStatValue = 0;
            maxStatValue = 100;
            statCost = 20;
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
        /// Overridden method that enables Button click, purchase and upgrades of Good/Angel Player Karma.
        /// Adds a small time period between each click.
        /// Increases the Good/Angel Karma amount, equal to its value.
        /// Handles math calculations of soul currency, stat cost and stat increase
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
                statCost += 2;
                mouseClicked = 0;
            }
        }
    }
}
