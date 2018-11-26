using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class Player : Character
    {
        MeleeWeapon melee;
        RangedWeapon ranged;

        public Player(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            melee = new MeleeWeapon();
            ranged = new RangedWeapon();
        }



        public override void Update(GameTime gameTime)
        {
            //OVERRIDE FROM CHARACTER
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                System.Console.Write(position);
            }
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
     
    

