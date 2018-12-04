using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class Crosshair : GameObject
    {
        public Crosshair() : base("Crosshair")
        {

        }

        public override void Update(GameTime gameTime)
        {
            position = new Vector2(Mouse.GetState().X - GameWorld.camera.viewMatrix.Translation.X, Mouse.GetState().Y - GameWorld.camera.viewMatrix.Translation.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!GameWorld.triggerVendor)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 1f);
            }
            
            
        }

        public bool Click(GameObject obj)
        {
            if (this.CollisionBox.Intersects(obj.CollisionBox))
            {
                return true;
            }
            return false;
        }

        public bool RightOfPlayer()
        {
            if (GameWorld.player.Position.X - position.X >= 0)
            {
                return false;
            }
            return true;
        }
    }
}
