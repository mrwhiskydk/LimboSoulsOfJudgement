using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Abstract Class that represents mutual fields, properties, methods and one abstract method, between the Player and Enemy GameObjects
    /// </summary>
    public abstract class Character : AnimatedGameObject
    {
        /// <summary>
        /// Sets the current health value of the Character
        /// </summary>
        public int health;

        /// <summary>
        /// Sets the maximum health value amount of the Character
        /// </summary>
        public int maxHealth;

        /// <summary>
        /// Sets the current value amount of Character movement speed
        /// </summary>
        public float movementSpeed;

        /// <summary>
        /// Sets the duration amount of a Character can remain immortal
        /// </summary>
        protected float immortalDuration = 1f;

        /// <summary>
        /// Sets the amount of time a Character remains immortal / immune to all sources of damage taken
        /// </summary>
        protected double immortalTime;

        /// <summary>
        /// Sets wether or not a Character is immortal
        /// </summary>
        public bool isImmortal;

        /// <summary>
        /// Sets wether the Character is able to jump or not. Set to false as default
        /// </summary>
        protected bool canJump = false;
        /// <summary>
        /// Checks if a character should be knocked back 
        /// </summary>
        protected bool knockback = false;
        /// <summary>
        /// 
        /// </summary>
        protected double knockbackTime;
        /// <summary>
        /// How long a character is knocked back 
        /// </summary>
        protected float knockbackDuration;
        /// <summary>
        /// The distance a character should be knocked back when hit
        /// </summary>
        public float knockbackDistance;

        protected double knockbackMovement;

        /// <summary>
        /// Property that sets the health value of the current GameObject.
        /// Sets the isImmortal true, should the value of health fall below its current amount & isImmortal is not set true already.
        /// Enables the Player functionality of gaining health value through the Lifesteal stat & shows the amount of health gain, through text, onto the screen.
        /// Enables the ability for the Player to have a chance of landing a critical strike on an Enemy GameObject & shows the crit damage amount on the screen, through text.
        /// If the new health value is not set through a critical strike, default DamageText is then shown onto the screen.
        /// Also checks if the current value of health has reach its maximum amount of health value (maxHealth) & sets their value equal to the same should it occur.
        /// C:\Users\sein\source\repos\LimboSoulsOfJudgement\LimboSoulsOfJudgement\LimboSoulsOfJudgement\Character.cs
        /// </summary>
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (!isImmortal && value < health)
                {
                    isImmortal = true;

                    if (this is Enemy)
                    {
                        // LifeSteal
                        if ((int)((health - value) * GameWorld.player.lifeSteal) >= 0.9f && GameWorld.player.health < GameWorld.player.maxHealth)
                        {
                            GameWorld.player.health += (int)((health - value) * GameWorld.player.lifeSteal);
                            if (GameWorld.player.health > GameWorld.player.maxHealth)
                            {
                                GameWorld.player.health = GameWorld.player.maxHealth;
                            }
                            new DamageText(new Vector2(GameWorld.player.Position.X, GameWorld.player.Position.Y - GameWorld.player.CollisionBox.Height * 0.5f), (int)((health - value) * GameWorld.player.lifeSteal), true);
                        }

                        if (GameWorld.rnd.Next(1, 101) <= 100 * GameWorld.player.critChance)
                        {
                            new DamageText(new Vector2(position.X, position.Y - sprite.Height * 0.5f), (int)((health - value) * GameWorld.player.critDmgModifier), 2, false);
                            new DamageText(new Vector2(position.X, position.Y - sprite.Height * 0.5f), (int)((health - value) * GameWorld.player.critDmgModifier), 2, true);
                            health -= Math.Abs((int)((float)(health - value) * GameWorld.player.critDmgModifier));

                        }
                        else
                        {
                            new DamageText(new Vector2(position.X, position.Y - sprite.Height * 0.5f), health - value, 1, false);
                            health = value;
                        }
                    }

                }
                else if (value > health)
                {
                    health = value;
                }

                if (health > maxHealth)
                {
                    health = maxHealth;
                }

            }
        }

        /// <summary>
        /// Property that sets the maximum health value of the current GameObject
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }

        /// <summary>
        /// Character Constructor that enables gravity as default
        /// </summary>
        public Character(int frameCount, float animationFPS, Vector2 startPostion, string spriteName) : base(frameCount, animationFPS, startPostion, spriteName)
        {
            gravity = true;
        }

        /// <summary>
        /// Method that updates game logic
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            gravity = true;
        }

        /// <summary>
        /// Abstract method used in Player and Enemy to secure individual movement functionality between each class
        /// </summary>
        protected abstract void HandleMovement(GameTime gameTime);

    }
}
