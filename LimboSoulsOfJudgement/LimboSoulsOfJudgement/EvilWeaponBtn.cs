using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents functionality and game logic of the 'EvilWeaponBtn' Button
    /// </summary>
    public class EvilWeaponBtn : Button
    {
        /// <summary>
        /// Actual value increase of player melee weapon damage
        /// </summary>
        public int weaponStatIncrease = 10;

        /// <summary>
        /// EvilWeaponBtn Constructor, that sets the default position and sprite name values.
        /// Sets this Class' default values of both: currentStatValue, maxStatValue, StatCost, karmaRequirements and statIncrease.
        /// Also sets the value of weaponActive to false as default until the weapon has been purchased.
        /// </summary>
        public EvilWeaponBtn() : base(new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 25), "buttonUITest")
        {
            weaponActive = false;

            currentStatValue = 0;
            maxStatValue = 2;
            karmaRequirements = 25;
            statCost = 400;
            statIncrease = 1;   //statIncrease in this class are for the UI 'stat' increase purpose only
        }

        /// <summary>
        /// Updates the EvilWeaponBtn's game logic.
        /// Also checks wether or not the bad karma requirements has been reached, in order to begin purchasing process
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            //Statement that checks if current amount of bad karma has reached the required karma value in order to begin purchasing process
            if (GameWorld.badKarmaButton.currentKarma >= karmaRequirements)
            {
                base.Update(gameTime);
            }              
        }

        /// <summary>
        /// Overridden method that enables Button click, purchase of a new Bad/Demonic Weapon.
        /// Adds a small time period between each click.
        /// Checks wether or not another Good/Angel weapon has aldready been purchased. if true, no additional damage will be added to the MeleeWeapon GameObject.
        /// Handles math calculations of soul currency, stat cost, stat increase and karma requirements
        /// Also sets the value of weaponActive to true, since the purchase of this current weapon has been purchased.
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
                if (!GameWorld.goodWeaponBtn.weaponActive) 
                {
                    GameWorld.player.melee.damage += weaponStatIncrease;
                }
                else
                {
                    GameWorld.player.melee.damage += 0;
                }

                GameWorld.player.melee.Upgrade("evil", currentStatValue);

                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                weaponActive = true;    //Sets the value to true, since purchase is complete
                mouseClicked = 0;
                if (karmaRequirements < 50)
                {
                    karmaRequirements += 25;
                }
                statCost += 600;
            }
        }
    }
}
