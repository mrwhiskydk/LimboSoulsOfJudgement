using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    public abstract class Enemy : Character
    {
        public int enemyDamage;

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
        /// <summary>
        /// Checks if an enemy should be knocked back by the players weapon
        /// </summary>
        protected bool knockback = false;
        /// <summary>
        /// 
        /// </summary>
        protected double knockbackTime;
        /// <summary>
        /// How long an enemy is knocked back 
        /// </summary>
        protected float knockbackDuration;
        /// <summary>
        /// The distance an enemy should be knocked back when hit
        /// </summary>
        public float knockbackDistance;
        public int damageToDeal;

        /// <summary>
        /// Checks if the code for (aggro if enemy is aggro'ed nearby) should be run
        /// </summary>
        private bool aggroCheck = true;

        protected double knockbackMovement;
        protected double patrolTime;
        protected float patrolDuration;
        protected double collisionMovement;
        protected const float jumpPower = 1600;
        protected double jumpForce = jumpPower;
        protected double jumpTime;
        protected bool isJumping = false;
        



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
            if (isImmortal)
            {
                immortalTime += gameTime.ElapsedGameTime.TotalSeconds;  //Adding +1 second to immortalTime, until it reaches 3 seconds
                if (immortalTime > immortalDuration)
                {
                    isImmortal = false;
                    immortalTime = 0;   //Upon reaching 3 seconds, immortalTime is reset to 0
                }
            }

            if (Vector2.Distance(position, GameWorld.player.Position) < 500 && aggro is false)
            {
                aggro = true;
            }

            if (aggroCheck is true && aggro is true)
            {
                List<Enemy> tempEnemyList = new List<Enemy>();

                foreach (GameObject item in GameWorld.gameObjects)
                {
                    if (item is Enemy)
                    {
                        tempEnemyList.Add((Enemy)item);
                    }
                }
                foreach (Enemy item in tempEnemyList)
                {
                    if (Vector2.Distance(position, item.position) < 500)
                    {
                        item.aggro = true;
                    }
                }
                aggroCheck = false;
            }
           

            if (Health <= 0)
            {

                for (int i = 0; i < soulCount; i++)
                {
                    GameWorld.AddGameObject(new Soul(3, 6, new Vector2(position.X, position.Y), "Soul", enemySouls));                    
                }
                GameWorld.RemoveGameObject(this);
               
            }

            collisionMovement = movementSpeed * gameTime.ElapsedGameTime.TotalSeconds;

        }

        /// <summary>
        /// Method that sets the default movement functionality of MinorEnemy and BossEnemy
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            //patrolTime += gameTime.ElapsedGameTime.TotalSeconds;

            //if (aggro == false)
            //{
            //    if (patrolTime < patrolDuration)
            //    {
            //        facingRight = false;
            //        position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            //    }
            //    if (patrolTime > patrolDuration)
            //    {
            //        facingRight = true;
            //        position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            //    }
            //    if (patrolTime > patrolDuration * 2)
            //    {
            //        patrolTime = 0;
            //    }
            //}
                    
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

            if (otherObject is MeleeWeapon && isImmortal == false)
            {
                MeleeWeapon weapon = (MeleeWeapon)otherObject;

                if (GameWorld.rnd.Next(1, 101) <= 100 * GameWorld.player.critChance)
                {
                    damageToDeal = (int)(weapon.damage * GameWorld.player.critDmgModifier);
                    Health -= damageToDeal;
                }
                else
                {
                    damageToDeal = weapon.damage;
                    Health -= damageToDeal;
                }
                GameWorld.player.Health += (int)(weapon.damage * GameWorld.player.lifeSteal); // lifeSteal
                new Damage(new Vector2(position.X, CollisionBox.Top), damageToDeal);

                knockback = true;
                knockbackDistance = 2f;
            }

            if (otherObject is Projectile)
            {
                Projectile arrow = (Projectile)otherObject;

                if (GameWorld.rnd.Next(1, 101) <= 100 * GameWorld.player.critChance)
                {
                    damageToDeal = (int)(arrow.damage * GameWorld.player.critDmgModifier);
                    Health -= damageToDeal;
                }
                else
                {
                    damageToDeal = arrow.damage;
                    Health -= damageToDeal;
                }
                GameWorld.player.Health += (int)(arrow.damage * GameWorld.player.lifeSteal); // lifeSteal
                new Damage(new Vector2(position.X, position.Y - sprite.Height * 0.5f), damageToDeal);
                arrow.Destroy();
                knockback = true;
                knockbackDistance = 1.5f;
                aggro = true;
            }
        }
    }
}
