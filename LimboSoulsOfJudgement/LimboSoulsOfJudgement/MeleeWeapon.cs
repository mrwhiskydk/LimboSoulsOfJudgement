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
        private Vector2 offsetIdle = new Vector2(0, -135);
        private Vector2 offsetAttack = new Vector2(135, 0);

        public MeleeWeapon() : base("sword")
        {
            damage = 10;
        }

        public override void Attack()
        {
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
                    return new Rectangle((int)(position.X - sprite.Width * 0.5), (int)(position.Y - sprite.Height * 0.5), sprite.Width, sprite.Height);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (equipped)
            {
                //Hold the sword above the player
                if (!isAttacking)
                {
                    position = GameWorld.player.Position + offsetIdle;
                    rotation = MathHelper.ToRadians(0);
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
                        position = GameWorld.player.Position + offsetAttack;
                        rotation = MathHelper.ToRadians(90);
                    }
                    else
                    {
                        position = GameWorld.player.Position - offsetAttack;
                        rotation = MathHelper.ToRadians(270);
                    }
                    
                    /*
                    rotation += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    rotSpeed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Matrix swordMatrix = Matrix.CreateRotationZ(rotSpeed) * Matrix.CreateTranslation(new Vector3(GameWorld.player.Position, 0f));
                    position = Vector2.Transform(offset, swordMatrix);
                    */
                }
            }
        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Enemy)
            {
                
            }

            base.DoCollision(otherObject);
        }
    }
}