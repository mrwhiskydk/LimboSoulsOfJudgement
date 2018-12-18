using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the BuyGodModeAbility
    /// </summary>
    public class BuyGodModeAbility : Button
    {

        public BuyGodModeAbility() : base(new Vector2(GameWorld.ui.Position.X + 215, GameWorld.ui.Position.Y + 25), "buttonUITest")
        {
            abilityPurchased = false;

            statCost = 150;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (GameWorld.goodKarmaButton.currentKarma >= 45 || GameWorld.badKarmaButton.currentKarma >= 45)
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
                if (GameWorld.player.currentSouls < statCost)    //Returns if the current amount of Player souls is less than the cost of the Stat
                {
                    return;
                }
                currentStatValue += statIncrease;   //Updates the vendor UI's stat increase 
                abilityPurchased = true;
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
