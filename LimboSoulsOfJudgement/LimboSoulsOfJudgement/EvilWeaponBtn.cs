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
        //Actual value increase of player melee weapon damage
        public int weaponStatIncrease = 10;

        /// <summary>
        /// EvilWeaponBtn Constructor, that sets the default position and sprite name values
        /// </summary>
        public EvilWeaponBtn() : base(new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 70), "buttonUITest")
        {
            weaponActive = false;   //Set to false as default until the weapon has been purchased

            currentStatValue = 0;
            maxStatValue = 1;
            karmaRequirements = 3;
            statCost = 20;
            statIncrease = 1;   //statIncrease in this class are for the UI 'stat' increase purpose only
        }

        /// <summary>
        /// Updates the EvilWeaponBtn's game logic
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
                if (!GameWorld.goodWeaponBtn.weaponActive)
                {
                    GameWorld.player.melee.damage += weaponStatIncrease;
                }
                else
                {
                    GameWorld.player.melee.damage += 0;
                }
                
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                weaponActive = true;    //Sets the value to true, since purchase is complete
                mouseClicked = 0;
            }
        }
    }
}
