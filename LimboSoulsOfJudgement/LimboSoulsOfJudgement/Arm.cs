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
    class Arm : GameObject
    {
        public Arm() : base("PlayerArm")
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            //arm stuff
            position = GameWorld.player.Position;
            Vector2 dir = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y) - position;
            if (dir != Vector2.Zero)
            {
                dir.Normalize();
            }
            rotation = (float)System.Math.Atan2(dir.Y, dir.X) + MathHelper.ToRadians(-90);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2((sprite.Width - sprite.Width) + 0.1f, sprite.Height * 0.5f), 1f, new SpriteEffects(), 0f);
        }
    }
}
