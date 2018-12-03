using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class Enemy : Character
    {
        public int enemyDamage;

        public int enemyHealth;
        /// <summary>
        /// The value of an enemies soul
        /// </summary>
        public int enemySouls;
        /// <summary>
        /// The number of souls an enemy drops
        /// </summary>
        protected int soulCount;

        /// <summary>
        /// If true, the enemy will follow the player until it dies
        /// </summary>
        public bool aggro = false;
        /// <summary>
        /// Checks if an enemy should go after the player horizontally
        /// </summary>
        protected bool goHorizontally;
        /// <summary>
        /// Checks if an enemy should go after the player vertically
        /// </summary>
        protected bool goVertically;

        private double patrolTime;
        private float patrolDuration = 6f;
        private double collisionMovement;
        private const float jumpPower = 1600;
        private double jumpForce = jumpPower;
        private double jumpTime;
        private bool isJumping = false;



        /// <summary>
        /// Enemy constructor that sets animation values, position and sprite names of MinorEnemy and BossEnemy
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public Enemy(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {

        }

        /// <summary>
        /// Update method that enables movement of the Enemy GameObject
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (GameWorld.player.Position.X + 500 <= Position.X || GameWorld.player.Position.X - 500 >= Position.X )
            {
                goHorizontally = false;
                goVertically = false;
            }
            else
            {
                goHorizontally = true;
            }
            if (goHorizontally == true && enemyHealth > 0)
            {
                aggro = true;
            }

            if (GameWorld.player.Position.Y + 500 <= Position.Y || GameWorld.player.Position.Y - 500 >= Position.Y)
            {

                goVertically = false;
                goHorizontally = false;
            }
            else
            {
                goVertically = true;
            }

            if (enemyHealth <= 0)
            {

                for (int i = 0; i < soulCount; i++)
                {
                    GameWorld.AddGameObject(new Soul(3, 6, new Vector2(position.X, position.Y), "Soul", enemySouls));                    
                }
                GameWorld.RemoveGameObject(this);
               
            }
            collisionMovement = movementSpeed * gameTime.ElapsedGameTime.TotalSeconds;
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

        /// <summary>
        /// Method that sets the default movement functionality of MinorEnemy and BossEnemy
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            patrolTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (aggro == false)
            {
                if (patrolTime < 3f)
                {
                    facingRight = false;
                    position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (patrolTime > 3f)
                {
                    facingRight = true;
                    position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (patrolTime > patrolDuration)
                {
                    patrolTime = 0;
                }
            }
                    
            if (aggro == true && GameWorld.player.Position.X < position.X)
            {
                facingRight = true;
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (aggro == true && GameWorld.player.Position.X > position.X)
            {
                facingRight = false;
                position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        /// <summary>
        /// Method that handles Enemies collision with other GameObjects
        /// </summary>
        /// <param name="otherObject">The GameObject that the player object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is Player)
            {

            }

            if (otherObject is Projectile)
            {
                Projectile arrow = (Projectile)otherObject;
                enemyHealth -= arrow.damage;
                GameWorld.RemoveGameObject(arrow);
            }

            Rectangle topLine = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y + 12, 1, CollisionBox.Height - 24);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y + 12, 1, CollisionBox.Height - 24);
            Rectangle bottomLine = new Rectangle(CollisionBox.X + 3, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width - 6, 1);

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
                }

                if (leftLine.Intersects(otherObject.CollisionBox))
                {
                    if (CollisionBox.Intersects(GameWorld.player.CollisionBox) is false)
                    {
                        isJumping = true;
                    }
                    position.X += (float)collisionMovement;
                    Gravity = true;
                }

                if (bottomLine.Intersects(otherObject.CollisionBox) && Gravity is true)
                {
                    position.Y -= GameWorld.gravityStrength;
                    gravity = false;
                    
                }

                if (bottomLine.Intersects(otherObject.CollisionBox))
                {
                    jumpForce = jumpPower;
                }

                if (topLine.Intersects(otherObject.CollisionBox))
                {
                    jumpForce = 0;
                    Gravity = true;
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
