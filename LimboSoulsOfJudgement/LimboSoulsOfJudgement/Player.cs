using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class Player : Character
    {



        /// <summary>
        /// Player Constructor
        /// </summary>
        public Player()
        {
        }

        public void Update(GameTime gameTime)
        {
            //OVERRIDE FROM CHARACTER
        }

        /// <summary>
        /// Method that sets the default movement functionality of the Player
        /// </summary>
        protected override void HandleMovement(GameTime gameTime)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherObject"></param>
        public void DoCollision(GameObject otherObject)
        {
            //OVERRIDE FROM CHARACTER
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            //OVERRIDE FROM CHARACTER
        }


    }
}
