using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class Player : Character
    {
        public Player(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
        }

        /// <summary>
        /// Method that sets the default movement functionality of the Player
        /// </summary>
        protected override void HandleMovement(GameTime gameTime)
        {
            
        }
    }
}
     
    

