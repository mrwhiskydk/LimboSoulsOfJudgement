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
            currentStatValue = (int)GameWorld.player.critDmgModifier;
            maxStatValue = (int)5.0f;
            statCost = 10;
            statIncrease = (int)0.1f;
        }

        /// <summary>
        /// Updates the UpgradeCritDamage game logic
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// 
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
                currentStatValue += statIncrease;   //Updates the vendor UI's stat increase 
                GameWorld.player.critDmgModifier += statIncrease; //Actual increase of player values
                GameWorld.player.currentSouls -= statCost;  //Substracts player soul value equal to current buttons stat cost
                mouseClicked = 0;   //Resets the mouseClicked value once value calculations has finished
            }
        }
    }
}
