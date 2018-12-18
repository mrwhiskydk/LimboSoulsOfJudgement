using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UpgradeAbilityDamageBtn
    /// </summary>
    public class UpgradeAbilityDamageBtn : Button
    {
        /// <summary>
        /// Sets the current stat value of the second ability, in the UpgradeAbilityDamageBtn Class
        /// </summary>
        public int currentSecondaryStatValue;

        public UpgradeAbilityDamageBtn() : base(new Vector2(GameWorld.ui.Position.X - 225, GameWorld.ui.Position.Y + 20), "buttonUITest")
        {
            currentStatValue = LightningBoltAbility.LightningBolt.damage;
            currentSecondaryStatValue = BloodstormAbility.Bloodstorm.damage;
            maxStatValue = 100;
            karmaRequirements = 35;
            statCost = 10;
            statIncrease = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (currentStatValue < maxStatValue || currentSecondaryStatValue < maxStatValue)
            {
                if(GameWorld.goodKarmaButton.currentKarma > karmaRequirements || GameWorld.badKarmaButton.currentKarma > karmaRequirements)
                {
                    if (GameWorld.buyLightningBoltButton.abilityPurchased || GameWorld.buyBloodStormButton.abilityPurchased)
                    {
                        UpgradeStat(gameTime);
                    }
                }                               
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
                currentSecondaryStatValue += statIncrease;
                LightningBoltAbility.LightningBolt.damage += statIncrease;
                BloodstormAbility.Bloodstorm.damage += statIncrease;
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                karmaRequirements += 1;
                statCost += 1;
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
