using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    public class Vendor : AnimatedGameObject
    {
        

        /// <summary>
        /// Vendor Constructor, that sets vendor animation values, start position and sprite name 
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public Vendor(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {

        }

        public override void Update(GameTime gameTime)
        {
            gravity = true;

            base.Update(gameTime);
        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is Player)
            {
                GameWorld.triggerVendor = true;
            }
            else
            {
                GameWorld.triggerVendor = false;
            }
        }

    }
}