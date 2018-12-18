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


        public UpgradeAbilityDamageBtn() : base(new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 165), "buttonUITest")
        {
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void UpgradeStat(GameTime gameTime)
        {
            
        }
    }
}
