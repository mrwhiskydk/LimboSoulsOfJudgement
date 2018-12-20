using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    public class MeleeWeapon : Weapon
    {
        public bool isAttacking = false;
        private double attackTime = 0.2;
        private double attackTimer = 0;
        private Vector2 offsetIdle;
        private Vector2 offsetAttack;
        //upgradeable sprites
        public static Texture2D good1;
        public static Texture2D good2;
        public static Texture2D bad1;
        public static Texture2D bad2;

        /// <summary>
        /// Constructor that also loads the sword sprites it can be upgraded to
        /// </summary>
        public MeleeWeapon() : base("Sword")
        {
            damage = 10;
            sound = new Sound("sound/sword");

            //load upgradeable sprites
            good1 = GameWorld.ContentManager.Load<Texture2D>("HolySword");
            good2 = GameWorld.ContentManager.Load<Texture2D>("angelSword");
            bad1 = GameWorld.ContentManager.Load<Texture2D>("BaseballBat");
            bad2 = GameWorld.ContentManager.Load<Texture2D>("demonSword");
        }

        /// <summary>
        /// This method gets run everytime we attack
        /// </summary>
        public override void Attack()
        {
            base.Attack();
            isAttacking = true;
        }


        public override Rectangle CollisionBox
        {
            get
            {
                //Return a "rotated" collisionbox if we are attacking
                if (isAttacking)
                {
                    return new Rectangle((int)(position.X - sprite.Height * 0.5), (int)(position.Y - sprite.Width * 0.5), sprite.Height, sprite.Width);
                }
                else
                {
                    return new Rectangle();
                }
            }
        }

        /// <summary>
        /// This method gets run once ever game tick
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            offsetIdle = new Vector2(40, -sprite.Height * 0.5f - 40);
            offsetAttack = new Vector2(sprite.Height * 0.5f + 52, 0);

            if (equipped)
            {
                //Hold the sword above the player
                if (!isAttacking)
                {
                    if (GameWorld.player.facingRight is true)
                    {
                        position = Player.arm.Position + offsetIdle;
                        rotation = MathHelper.ToRadians(0);
                    }
                    else
                    {
                        position = Player.arm.Position +  new Vector2(offsetIdle.X - offsetIdle.X * 2, offsetIdle.Y);
                        rotation = MathHelper.ToRadians(0);
                    }
                    
                }
                //set the position to a "stabby" position
                else
                {
                    attackTimer += gameTime.ElapsedGameTime.TotalSeconds;
                    if (attackTimer >= attackTime)
                    {
                        isAttacking = false;
                        attackTimer = 0;
                    }

                    if (GameWorld.mouse.RightOfPlayer())
                    {
                        position = Player.arm.Position + offsetAttack;
                        rotation = MathHelper.ToRadians(90);
                        GameWorld.player.facingRight = true;
                    }
                    else
                    {
                        position = Player.arm.Position - offsetAttack;
                        rotation = MathHelper.ToRadians(270);
                        GameWorld.player.facingRight = false;
                    }
                }
            }
        }

        /// <summary>
        /// Upgrade the melee weapon
        /// </summary>
        /// <param name="side">"good" or "evil"</param>
        /// <param name="nr">which upgrade number we are at</param>
        public void Upgrade(string side, int nr)
        {
            if (side == "good")
            {
                if (nr == 1)
                {
                    sprite = good1;
                }
                else if (nr == 2)
                {
                    sprite = good2;
                }
            }
            else
            {
                if (nr == 1)
                {
                    sprite = bad1;
                }
                else if (nr == 2)
                {
                    sprite = bad2;
                }
            }
        }
    }
}