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
        public Arm() : base("PlayerArm")
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            //arm stuff
            if (GameWorld.player.weapon is RangedWeapon)
            {
                Vector2 dir = new Vector2(GameWorld.mouse.Position.X, GameWorld.mouse.Position.Y) - position;
                if (dir != Vector2.Zero)
                {
                    dir.Normalize();
                }
                rotation = (float)System.Math.Atan2(dir.Y, dir.X) + MathHelper.ToRadians(-90);
            }
            

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
                    rotation = MathHelper.ToRadians(180);
                }
            }

            position = GameWorld.player.Position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.player.weapon is RangedWeapon)
            {
                if (GameWorld.mouse.RightOfPlayer())
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.None, 0.82f);
                }
                else
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.FlipHorizontally, 0.82f);
                }
            }
            else if (GameWorld.player.weapon is MeleeWeapon && GameWorld.player.melee.isAttacking)
            {
                if (GameWorld.mouse.RightOfPlayer())
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.None, 0.82f);
                }
                else
                {
                    spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.FlipHorizontally, 0.82f);
                }
            }
            else
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, -1), 1f, SpriteEffects.None, 0.82f);
            }
        }
    }
}
