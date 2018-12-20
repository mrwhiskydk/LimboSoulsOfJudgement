using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    public class Arm : GameObject
    {
        /// <summary>
        /// The rotation of the arm, hides the inherited rotation from GameObject
        /// </summary>
        public new float rotation;


        public Arm() : base("PlayerArm")
        {
            
        }
        
        /// <summary>
        /// Method gets run every game tick
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //if we are holding a ranged weapon rotate towards mouse
            if (GameWorld.player.weapon is RangedWeapon)
            {
                Vector2 dir = new Vector2(GameWorld.mouse.Position.X, GameWorld.mouse.Position.Y) - position;
                if (dir != Vector2.Zero)
                {
                    dir.Normalize();
                }
                rotation = (float)System.Math.Atan2(dir.Y, dir.X) + MathHelper.ToRadians(-90);
            }
            
            //if melee is equipped and we are attacking then rotate the weapon accordingly
            if (GameWorld.player.weapon is MeleeWeapon)
            {
                if (GameWorld.player.melee.isAttacking)
                {
                    if (GameWorld.mouse.RightOfPlayer())
                    {
                        rotation = MathHelper.ToRadians(270);
                    }
                    else
                    {
                        rotation = MathHelper.ToRadians(90);
                    }
                    
                }
                else
                {
                    if (GameWorld.player.facingRight is true)
                    {
                        rotation = MathHelper.ToRadians(210);
                    }
                    else
                    {
                        rotation = MathHelper.ToRadians(150);
                    }

                }
            }

            //rotate accordingly to the direction we are facing
            if (GameWorld.player.facingRight is true)
            {
                position = new Vector2(GameWorld.player.Position.X + 15, GameWorld.player.Position.Y - 30);
            }
            else
            {
                position = new Vector2(GameWorld.player.Position.X - 15, GameWorld.player.Position.Y - 30);
            }
        }

        /// <summary>
        /// Method to draw our sprite
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.player.weapon is RangedWeapon)
            {
                if (GameWorld.mouse.RightOfPlayer())
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.None, 0.89f);
                }
                else
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.FlipHorizontally, 0.89f);
                }
            }
            else if (GameWorld.player.weapon is MeleeWeapon && GameWorld.player.melee.isAttacking)
            {
                if (GameWorld.mouse.RightOfPlayer())
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.None, 0.89f);
                }
                else
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.FlipHorizontally, 0.89f);
                }
            }
            else
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.None, 0.89f);
            }
        }
    }
}
