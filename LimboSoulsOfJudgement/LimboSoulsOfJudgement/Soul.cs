using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    public class Soul : AnimatedGameObject
    {
        /// <summary>
        /// Field that sets the amount of Souls contained in the current Soul GameObject
        /// </summary>
        public int souls;
        private bool hitTheGround = false;
        private float direction;
        private double jumpForce = 400;
        private bool soulsGiven = false;


        /// <summary>
        /// Soul Constructor that sets Soul animation values, position and sprite name
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public Soul(int frameCount, float animationFPS, Vector2 startPostion, string spriteName, int souls) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            direction = (float)(GameWorld.rnd.Next(0, 2) * 2 - 1) * GameWorld.rnd.Next(0, 180);
            this.souls = souls;
        }

        /// <summary>
        /// Method that updates Soul game logic
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            int distance = (int)Vector2.Distance(position, GameWorld.player.Position); // Gets the distance between the player and the soul
            // if the distance is under 200 and the soul has hit the ground the soul moves towards the player
            if (distance < 400 && hitTheGround is true)
            {
                SoulMovement();
            }

            // if the soul has not hit the ground, make it move like it has been thrown
            if (hitTheGround is false)
            {
                jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 1000;
                position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
                position.X += MathHelper.ToRadians(direction);
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

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Platform)
            {
                hitTheGround = true;
            }

            if (otherObject is Player)
            {
                if (soulsGiven is false)
                {
                    GameWorld.player.currentSouls += souls;
                    soulsGiven = true;
                }
                GameWorld.RemoveGameObject(this);
            }
        }

    }
}