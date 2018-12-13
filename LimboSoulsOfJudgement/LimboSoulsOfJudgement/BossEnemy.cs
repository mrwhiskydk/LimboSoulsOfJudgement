using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class BossEnemy : Enemy
    {
        private bool battleMode = true;
        private bool charge;
        private bool deathRay;
        private double abilityTime;
        private float abilityDuration = 2f;
        private float battleModeDuration = 20f;
        private double battleModeTime;
       
        

        /// <summary>
        /// BossEnemy constructor that sets animation values, position and sprite names of current BossEnemy GameObject
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public BossEnemy(string spriteName) : base(5, 5, new Vector2(GameWorld.ScreenSize.Width * 0.5f, GameWorld.ScreenSize.Height * 0.5f), spriteName)
        {
            movementSpeed = 300;
            enemyHealth = (int)(200 * GameWorld.levelCount);
            enemyDamage = (int)(20 * GameWorld.levelCount);
            enemySouls = (int)(50 * GameWorld.levelCount);
            soulCount = 10;
            patrolDuration = 2f;
            knockbackDuration = 0.4f;
        }


        /// <summary>
        /// Method that updates game logic of the current BossEnemy GameObject
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);
            knockbackMovement = (float)(knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            if (knockback)
            {
                knockbackTime += gameTime.ElapsedGameTime.TotalSeconds;

                if (GameWorld.player.Position.X < position.X)
                {
                    position.X += (float)(0.7*knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (GameWorld.player.Position.X > position.X)
                {
                    position.X -= (float)(0.7*knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (knockbackTime > knockbackDuration)
                {
                    knockback = false;
                    knockbackTime = 0;
                }
            }


            
            battleModeTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (battleModeTime > battleModeDuration)
            {
                battleMode = false;
                battleModeTime = 0;
            }

            if (charge == true)
            {
                movementSpeed = 600;

            }
            else if (charge == false)
            {
                movementSpeed = 300;
            }

        }


        protected override void HandleMovement(GameTime gameTime)
        {

            Gravity = false;
            if (battleMode is true)
            {

                deathRay = false;
                if (GameWorld.player.Position.Y < position.Y)
                {
                    position.Y -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (GameWorld.player.Position.Y > position.Y)
                {
                    position.Y += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (GameWorld.player.Position.X < position.X)
                {
                    facingRight = true;
                    position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (GameWorld.player.Position.X > position.X)
                {
                    facingRight = false;
                    position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
                abilityTime = 0;

            }
            if (battleMode is false)
            {        
                if (GameWorld.rnd.Next(1, 3) == 1)
                {
                    Position = new Vector2(2 * 128, 2 * 128);
                }
                else
                {
                    Position = new Vector2(27 * 128, 2 * 128);
                }

                abilityTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (abilityTime > abilityDuration)
                {
                    //if (GameWorld.rnd.Next(1, 3) == 1)
                    //{
                    charge = true;
                    battleMode = true;
                    //}
                    //else
                    //{
                    //    deathRay = true;
                    //}

                }

                //if (charge == true)
                //{
                //    Vector2 direction;
                //    direction = GameWorld.player.Position - position;
                //    direction.Normalize();
                //    position += direction;
                //}
                //if (deathRay == true)
                //{
                //    charge = true;
                //}

            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is Weapon || otherObject is Projectile)
            {
                battleMode = true;
                charge = false;
            }
        }
    }
}
