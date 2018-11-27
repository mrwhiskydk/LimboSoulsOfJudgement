using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class Soul : AnimatedGameObject
    {
        /// <summary>
        /// Field that sets the amount of Souls contained in the current Soul GameObject
        /// </summary>
        public int souls;
        double timer = 0; // a timer used so that the souls can still hit the ground before moving towards the player

        /// <summary>
        /// Soul Constructor that sets Soul animation values, position and sprite name
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public Soul(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {

        }

        /// <summary>
        /// Method that updates Soul game logic
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds; 
            int distance = (int)Vector2.Distance(position, GameWorld.player.Position); // Gets the distance between the player and the soul
            // if the distance is under 200 and 1.5 seconds have passed since the soul was dropped the soul moves towards the player
            if (distance < 200 && timer > 1.5)
            {
                SoulMovement();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Method that gets the direction towards the player and moves in that direction
        /// </summary>
        public void SoulMovement()
        {
            Vector2 direction;
            direction = GameWorld.player.Position - position;
            direction.Normalize();
            position += direction * 10;
        }
    }
}