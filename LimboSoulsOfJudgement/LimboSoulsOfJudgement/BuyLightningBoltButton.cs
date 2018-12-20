﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the BuyLightningBoltButton's Button
    /// </summary>
    public class BuyLightningBoltButton : Button
    {

        /// <summary>
        /// BuyLightningBoltButton's Constructor, that sets the default position and sprite name values.
        /// Sets this Class' default values of both: currentStatValue, maxStatValue, karmaRequirements, StatCost and statIncrease.
        /// Also sets the abilityPurchased bool to false as default, since the ability have not yet been purchased
        /// </summary>
        public BuyLightningBoltButton() : base(new Vector2(GameWorld.ui.Position.X - 250, GameWorld.ui.Position.Y - 218), "buttonUITest")
        {
            abilityPurchased = false;

            currentStatValue = 0;
            maxStatValue = 1;
            karmaRequirements = 25;
            statCost = 500;
            statIncrease = 1;

        }

        /// <summary>
        /// Updates the BuyLightningBoltButton's game logic.
        /// Also checks if current amount of good karma has reached the required karma value in order to begin the purchasing process
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {

            if (GameWorld.goodKarmaButton.currentKarma >= karmaRequirements)
            {
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// Overridden method that enables Button click and purchase of the Lightning Bolt Ability.
        /// Adds a small time period between each click.
        /// Sets the value of abilityPurchased to true, making it possible for the Player GameObject to use the Ability.
        /// Handles math calculations of soul currency, stat cost and stat increase
        /// Sets the LightningBolt Ability onto the UI Ability Bar.
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
                GameWorld.player.ability2 = new LightningBoltAbility(); //Add the purchased ability to ability 1
            }
        }
    }
}
