using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeAbilityDamageBtn's Button
    /// </summary>
    public class UpgradeAbilityDamageBtn : Button
    {
        /// <summary>
        /// Sets the current stat value of the second ability, in the UpgradeAbilityDamageBtn Class
        /// </summary>
        public int currentSecondaryStatValue;

        /// <summary>
        /// UpgradeAbilityDamageBtn Constructor, that sets the default position and sprite name values
        /// Also sets this Class' default values of both: currentStatValue, currentSecondaryStatValue, maxStatValue, karmaRequirements, 
        /// StatCost and statIncrease
        /// </summary>
        public UpgradeAbilityDamageBtn() : base(new Vector2(GameWorld.ui.Position.X - 250, GameWorld.ui.Position.Y - 25), "buttonUITest")
        {
            currentStatValue = LightningBoltAbility.LightningBolt.damage;
            currentSecondaryStatValue = BloodstormAbility.Bloodstorm.damage;
            maxStatValue = 100000;
            karmaRequirements = 35;
            statCost = 50;
            statIncrease = 1;
        }

        /// <summary>
        /// Updates the UpgradeAbilityDamageBtn's game logic.
        /// Checks if the values of both: current stat value, current karma amount (of either good or bad), has not yet been reached.
        /// Also checks if either of the good and bad abilities have been purchased, in order to begin the purchasing process
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the Update</param>
        public override void Update(GameTime gameTime)
        {
            if (currentStatValue < maxStatValue || currentSecondaryStatValue < maxStatValue)
            {
                if(GameWorld.goodKarmaButton.currentKarma >= karmaRequirements || GameWorld.badKarmaButton.currentKarma >= karmaRequirements)
                {
                    if (GameWorld.buyLightningBoltButton.abilityPurchased || GameWorld.buyBloodStormButton.abilityPurchased)
                    {
                        UpgradeStat(gameTime);
                    }
                }                               
            }
        }

        /// <summary>
        /// Overridden method that enables Button click, purchase and upgrades of Ability Damage.
        /// Adds a small time period between each click.
        /// Increases the Ability Damage amount, equal to both the LightningBolt's and Bloodstorm's damage value.
        /// Handles math calculations of soul currency, stat cost and stat increase
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the Update</param>
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
                currentSecondaryStatValue += statIncrease;
                LightningBoltAbility.LightningBolt.damage += statIncrease;
                BloodstormAbility.Bloodstorm.damage += statIncrease;
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                statCost += 10;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
