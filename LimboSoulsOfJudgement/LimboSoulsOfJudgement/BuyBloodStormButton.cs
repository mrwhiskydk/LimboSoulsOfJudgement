using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the BuyBloodStormButton
    /// </summary>
    public class BuyBloodStormButton : Button
    {

        /// <summary>
        /// BuyBloodStormButton's Constructor, that sets the default position and sprite name values.
        /// Also sets the abilityPurchased bool to false as default, since the ability have not yet been purchased
        /// </summary>
        public BuyBloodStormButton() : base(new Vector2(GameWorld.ui.Position.X + 245, GameWorld.ui.Position.Y - 218), "buttonUITest")
        {
            abilityPurchased = false;

            currentStatValue = 0;
            maxStatValue = 1;
            karmaRequirements = 75;
            statCost = 500;
            statIncrease = 1;
        }

        /// <summary>
        /// Updates the BuyBloodStormButton's game logic
        /// Also checks if current amount of bad karma has reached the required karma value in order to begin the purchasing process
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            if (GameWorld.badKarmaButton.currentKarma >= karmaRequirements)
            {
                base.Update(gameTime);
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
                if (GameWorld.player.currentSouls < statCost)    //Returns if the current amount of Player souls is less than the cost of the Stat
                {
                    return;
                }
                currentStatValue += statIncrease;   //Adds value to the current amount of Karma equal to its stat cost
                abilityPurchased = true;
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                mouseClicked = 0;
                GameWorld.player.ability1 = new BloodstormAbility(); //Add the purchased ability to ability 1
            }
        }
    }
}
