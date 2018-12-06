﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class MinorEnemy : Enemy
    {
        public int karma;

        /// <summary>
        /// MinorEnemy constructor that sets animation values, position and sprite names of current MinorEnemy GameObject
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public MinorEnemy(Vector2 position) : base(3, 6, position, "SmallDevil")
        {
            movementSpeed = 200;
            enemyHealth = 50;
            enemyDamage = 10;
            enemySouls = 20;
            soulCount = 3;
            patrolDuration = 2f;
            this.position = position;
        }

        /// <summary>
        /// Method that updates game logic of the current MinorEnemy GameObject
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);
            HandleJumping(gameTime);
            // if player is on a chain and the enemy is aggro'ed, jump after the player and set goVertically to true
            if (GameWorld.player.climb is true && aggro is true)
            {
                if (GameWorld.player.Position.Y < position.Y && Math.Abs(position.X - GameWorld.player.Position.X) < 50)
                {
                    isJumping = true;
                }
                goVertically = true;
            }
            else
            {
                goVertically = false;
            }

            collisionMovement = movementSpeed * gameTime.ElapsedGameTime.TotalSeconds;
        }


        protected override void HandleMovement(GameTime gameTime)
        {
            base.HandleMovement(gameTime);

        }

        private void HandleJumping(GameTime gameTime)
        {
            if (isJumping)
            {
                jumpTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (jumpTime <= jumpForce)
                {
                    position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
                    jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 1500;
                }

                if (jumpTime >= jumpForce)
                {
                    isJumping = false;
                }
            }
            else if (!isJumping)
            {
                gravity = true;
            }
        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
            Rectangle topLine = new Rectangle(CollisionBox.X + 8, CollisionBox.Y, CollisionBox.Width - 16, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X + 10, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width - 20, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y + 15, 1, CollisionBox.Height - 30);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y + 15, 1, CollisionBox.Height - 30);

            if (otherObject is Platform)
            {
                
                if (rightLine.Intersects(otherObject.CollisionBox))
                {
                    if (CollisionBox.Intersects(GameWorld.player.CollisionBox) is false)
                    {
                        isJumping = true;
                    }
                    position.X -= (float)collisionMovement;
                    Gravity = true;

                    if (knockback == true)
                    {
                        position.X -= (float)knockbackMovement;
                    }
                }

                if (leftLine.Intersects(otherObject.CollisionBox))
                {
                    if (CollisionBox.Intersects(GameWorld.player.CollisionBox) is false)
                    {
                        isJumping = true;
                    }
                    position.X += (float)collisionMovement;
                    Gravity = true;

                    if (knockback == true)
                    {
                        position.X += (float)knockbackMovement;
                    }
                }

                //if (bottomLine.Intersects(otherObject.CollisionBox) && Gravity is true)
                //{
                //    position.Y -= GameWorld.gravityStrength;
                //    gravity = false;

                //}

                if (bottomLine.Intersects(otherObject.CollisionBox))
                {
                    jumpForce = jumpPower;
                    canJump = true;
                }

                if (topLine.Intersects(otherObject.CollisionBox))
                {
                    jumpForce = 0;
                    Gravity = true;
                }

                if (bottomLine.Intersects(otherObject.CollisionBox) && (leftLine.Intersects(otherObject.CollisionBox) is false || (rightLine.Intersects(otherObject.CollisionBox) is false)))
                {
                    // Makes the player get ontop of the platform and not halfway inside like in the begining, this also fixed collsion bug
                    while (CollisionBox.Intersects(otherObject.CollisionBox))
                    {
                        position.Y -= 1;
                    }
                    position.Y += 1;

                }

            }

            //if the enemy is on a chain and goVertically is true, climb after the player
            if (otherObject is Chain && goVertically is true)
            {
                if (position.Y > GameWorld.player.Position.Y)
                {
                    position.Y -= (float)(0.7 * collisionMovement);
                }
                if (position.Y < GameWorld.player.Position.Y)
                {
                    position.Y += (float)(0.7 * collisionMovement);
                }
                gravity = false;
                jumpForce = 0;
            }
        }

        

    }
}
