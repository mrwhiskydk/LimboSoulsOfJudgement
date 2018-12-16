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
        private double abilityTime;
        private float abilityDuration = 2f;
        private float battleModeDuration = 20f;
        private double battleModeTime;
        private bool bossTeleport = false;
       
        

        /// <summary>
        /// BossEnemy constructor that sets animation values, position and sprite names of current BossEnemy GameObject
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public BossEnemy(int animationFPS, float frameCount,string spriteName) : base(animationFPS, frameCount, new Vector2(GameWorld.ScreenSize.Width * 0.5f, GameWorld.ScreenSize.Height * 0.5f), spriteName)
        {
            movementSpeed = 300;
            health = (int)(200 * GameWorld.levelCount);
            maxHealth = health;
            enemyDamage = (int)(20 * GameWorld.levelCount);
            enemySouls = (int)(50 * GameWorld.levelCount);
            soulCount = 20;
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

                if (health <= 0)
                {
                    GameWorld.vendor.Position = new Vector2(30 * 64, 28 * 64);
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
                movementSpeed = 900;

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
                if (GameWorld.rnd.Next(1, 4) == 2 && bossTeleport == false)
                {
                    Position = new Vector2(2 * 128, 2 * 128);
                    bossTeleport = true;
                }
                else if (GameWorld.rnd.Next(1, 4) == 3 && bossTeleport == false)
                {
                    Position = new Vector2(27 * 128, 2 * 128);
                    bossTeleport = true;
                }

                abilityTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (abilityTime > abilityDuration)
                {
                    charge = true;
                    battleMode = true;
                }


            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is Weapon || otherObject is Projectile)
            {
                battleMode = true;
                charge = false;
                bossTeleport = false;
            }
        }
    }
}
