using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Abstract Class that represents the functionality and game logic of the current Enemy GameObject.
    /// This Class contains most of the default fields and methods used within each of its Sub-Classes.
    /// </summary>
    public abstract class Enemy : Character
    {
        /// <summary>
        /// The damage an enemy does to the players health
        /// </summary>
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
        /// Used in collision so that you dont need a gameTime in DoCollision
        /// </summary>
        protected double collisionMovement;

        /// <summary>
        /// Sets the default value amount of the current Enemy GameObject's jumping mechanic.
        /// </summary>
        protected const float jumpPower = 1600;

        /// <summary>
        /// Sets the value amount, that the current Enemy GameObject should be able to jump, equal to the same current amount of the jumpPower value
        /// </summary>
        protected double jumpForce = jumpPower;

        /// <summary>
        /// Used for setting the amount of time that the current Enemy GameObject should moving up the Y-axis (-Y)(jumping)
        /// </summary>
        protected double jumpTime;

        /// <summary>
        /// Sets the value of wether the current Enemy GameObject is currently jumping (in the air / - on the Y-axis), or not.
        /// Default value is set false, meaning the Enemy is not jumping.
        /// If set true, meaning the current Enemy GameObject is jumping
        /// </summary>
        protected bool isJumping = false;




        /// <summary>
        /// Enemy constructor that sets animation values, position and sprite names of MinorEnemy and BossEnemy.
        /// Also sets the immortality duration amount, that the current Enemy GameObject should remain (immune to all sources of damage value taken)
        /// </summary>
        /// <param name="frameCount">How many frames in the spritesheet</param>
        /// <param name="animationFPS">The speed the frames change</param>
        /// <param name="startPostion">The start position</param>
        /// <param name="spriteName">Name of the sprite</param>
        public Enemy(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            immortalDuration = 0.5f;
        }

        /// <summary>
        /// Update method that enables movement of the Enemy GameObject.
        /// Checks wether or not the value of isImmortal is set true, to begin processing the functionality of the current Enemy GameObject's duration of remaining immortal (immune to all sources of damage value taken).
        /// Also Checks if the value of current Enemy GameObject's Health is at or below zero, 
        /// in order to start the processing of adding Soul GameObjects to the game, towards a random direction with a start position of the current Enemy GameObject.
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
           

            if (Health <= 0)
            {

                for (int i = 0; i < soulCount; i++)
                {
                    GameWorld.AddGameObject(new Soul(3, 6, new Vector2(position.X, position.Y), "Soul", enemySouls));                    
                }
                Destroy();
               
            }

            collisionMovement = movementSpeed * gameTime.ElapsedGameTime.TotalSeconds;

        }

        /// <summary>
        /// Method that sets the default movement functionality of MinorEnemy and BossEnemy
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected override void HandleMovement(GameTime gameTime)
        {
                    
            if (aggro == true && GameWorld.player.Position.X < position.X)
            {
                facingRight = false;
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (aggro == true && GameWorld.player.Position.X > position.X)
            {
                facingRight = true;
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
                Health -= weapon.damage;
                aggro = true;
                knockback = true;
                knockbackDistance = 2f;
            }

            if (otherObject is Projectile)
            {
                Projectile arrow = (Projectile)otherObject;
                Health -= arrow.damage;

                arrow.Destroy();
                knockback = true;
                knockbackDistance = 1f;
                aggro = true;
            }
        }
    }
}
