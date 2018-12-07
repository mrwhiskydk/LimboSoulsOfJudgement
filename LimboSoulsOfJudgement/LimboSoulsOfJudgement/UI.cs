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
    /// <summary>
    /// Public Class that represents the UI Menu of the Vendor
    /// </summary>
    public class UI : AnimatedGameObject
    {

        /// <summary>
        /// Default Constructor that sets the values of current UI GameObject
        /// </summary>
        public UI() : base(1, 1, new Vector2(GameWorld.vendor.Position.X - 300, GameWorld.vendor.Position.Y - 10), "VendorUITest")
        {

        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
           
            if (GameWorld.triggerVendor)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, new SpriteEffects(), 0.02f);
            }

        }

    }
}
