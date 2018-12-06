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

        /// <summary>
        /// Update Method that enables constant gravity on the Vendor GameObject, and updates base game logic
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            gravity = true;

            base.Update(gameTime);
        }

        /// <summary>
        /// Method that handles Vendor collision functionality with the other current GameObjects in the game
        /// </summary>
        /// <param name="otherObject">The GameObject that the Vendor object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            foreach(GameObject go in GameWorld.gameObjects)
            {
                otherObject = go;
                if (otherObject.IsColliding(this) && otherObject is Player)
                {
                    GameWorld.triggerVendor = true;                   
                }
                else if(!GameWorld.player.IsColliding(this))
                {
                    GameWorld.triggerVendor = false;                  
                }
            }
        }


    }
}