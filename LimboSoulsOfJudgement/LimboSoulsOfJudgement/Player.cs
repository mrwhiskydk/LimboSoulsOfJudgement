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
        public Player() : base(3, 12, new Vector2(GameWorld.ScreenSize.Width / 2, GameWorld.ScreenSize.Height/2), "Melee2")
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
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
        public override void DoCollision(GameObject otherObject)
        {
            //OVERRIDE FROM CHARACTER
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //OVERRIDE FROM CHARACTER
        }


    }
}
     
    

