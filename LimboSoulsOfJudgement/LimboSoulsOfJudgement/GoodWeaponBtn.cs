﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the GoodWeaponBtn's button
    /// </summary>
    public class GoodWeaponBtn : Button
    {
        public int weaponStatIncrease = 10;

        /// <summary>
        /// GoodWeaponBtn Constructor, that sets the default position and sprite name values.
        /// Sets this Class' default values of both: currentStatValue, maxStatValue, StatCost, karmaRequirements and statIncrease.
        /// Also sets the value of weaponActive to false as default until the weapon has been purchased.
        /// </summary>
        public GoodWeaponBtn() : base(new Vector2(GameWorld.ui.Position.X - 500, GameWorld.ui.Position.Y - 25), "buttonUITest")
        {
            weaponActive = false;

            currentStatValue = 0;
            maxStatValue = 2;
            karmaRequirements = 25;
            statCost = 400;
            statIncrease = 1;   //statIncrease in this class are for the UI 'stat' increase purpose only
        }

        /// <summary>
        /// Updates the GoodWeaponBtn's game logic.
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
                if (!GameWorld.evilWeaponBtn.weaponActive)
                {
                    GameWorld.player.melee.damage += weaponStatIncrease;
                }
                else
                {
                    GameWorld.player.melee.damage += 0;
                }

                GameWorld.player.melee.Upgrade("good", currentStatValue);

                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                weaponActive = true;    //Sets the value to true, since purchase is complete
                mouseClicked = 0;
                karmaRequirements += 25;
                statCost += 600;
            }
        }
    }
}
