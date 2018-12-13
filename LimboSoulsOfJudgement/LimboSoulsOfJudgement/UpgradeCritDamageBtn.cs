using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Clas that represents the functionality and game logic of the UpgradeCritDamageBtn
    /// </summary>
    public class UpgradeCritDamageBtn : Button
    {

        /// <summary>
        /// UpgradeCritDamage Constructor, that sets the default position and sprite name values
        /// </summary>
        public UpgradeCritDamageBtn() : base(new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y - 175), "buttonUITest")
        {
            currentFloatStatValue = GameWorld.player.critDmgModifier;
            maxFloatStatValue = 5.0f;
            statCost = 50;
            floatStatIncrease = 0.1f;
        }

        /// <summary>
        /// Updates the UpgradeCritDamage game logic.
        /// as long as the current value amount of Crit Damage haven't reach maximum
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            //Substracts the floatStatIncrease value amount, to avoid overreach of maximum amount
            if (currentFloatStatValue < maxFloatStatValue - floatStatIncrease)
            {
                UpgradeStat(gameTime);
            }
        }

        /// <summary>
        /// Overridden method that enables Button click, purchase and upgrades of Player Crit Damage.
        /// Adds a small time period between each click.
        /// Increases the Crit Damage percentage amount, equal to its Crit Damage value.
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
                currentFloatStatValue += floatStatIncrease;   //Updates the vendor UI's stat increase 
                GameWorld.player.critDmgModifier += floatStatIncrease; //Actual increase of player values
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                statCost += 1;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
