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
    public abstract class Character : AnimatedGameObject
    {
        public int health;
        public int maxHealth;
        public float movementSpeed;

        protected float immortalDuration = 1.0f;
        protected double immortalTime;
        /// <summary>
        /// Sets characters immunity on and off
        /// </summary>
        public bool isImmortal;

        protected bool canJump = false;   //Controls wether the Player can jump or not
        
        /// <summary>
        /// Property that sets the health value of the current GameObjectC:\Users\sein\source\repos\LimboSoulsOfJudgement\LimboSoulsOfJudgement\LimboSoulsOfJudgement\Character.cs
        /// </summary>
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value < health)
                {
                    if (!isImmortal)
                    {
                        isImmortal = true;

                        // LifeSteal
                        if ((int)((health - value) * GameWorld.player.lifeSteal) >= 0.9f)
                        {
                            GameWorld.player.Health += (int)((health - value) * GameWorld.player.lifeSteal);
                            new DamageText(new Vector2(GameWorld.player.Position.X, GameWorld.player.Position.Y - GameWorld.player.CollisionBox.Height * 0.5f), (int)((health - value) * GameWorld.player.lifeSteal), true);
                        }

                        if (GameWorld.rnd.Next(1, 101) <= 100 * GameWorld.player.critChance)
                        {
                            new DamageText(new Vector2(position.X, position.Y - sprite.Height * 0.5f), (int)((health - value) * GameWorld.player.critDmgModifier), 2, false);
                            new DamageText(new Vector2(position.X, position.Y - sprite.Height * 0.5f), (int)((health - value) * GameWorld.player.critDmgModifier), 2, true);
                            health = (int)(value * GameWorld.player.critDmgModifier);
                        }
                        else
                        { 
                            new DamageText(new Vector2(position.X, position.Y - sprite.Height * 0.5f), health - value, 1, false);
                            health = value;
                        }
                    }
                }
                else
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
        /// Property that sets the max health value of the current GameObject
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
