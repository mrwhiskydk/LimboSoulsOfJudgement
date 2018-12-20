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
    /// <summary>
    /// Public Class that represents the default functionality and game logic of the Crosshair GameObject
    /// </summary>
    public class Crosshair : GameObject
    {
        /// <summary>
        /// Constructor for crosshair
        /// </summary>
        public Crosshair()
        {
            sprite = GameWorld.ContentManager.Load<Texture2D>("Crosshair");
        }

        /// <summary>
        /// Updates the position of the crosshair to the mouse position
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            position = new Vector2(Mouse.GetState().X - GameWorld.camera.viewMatrix.Translation.X, Mouse.GetState().Y - GameWorld.camera.viewMatrix.Translation.Y);
            Click(GameWorld.ui);
        }

        /// <summary>
        /// Method used to draw the crosshair
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 1f);          
        }

        /// <summary>
        /// Check if we have clicked on an object
        /// </summary>
        /// <param name="obj">The object to check if we have clicked on</param>
        /// <returns>Boolean: true or false</returns>
        public bool Click(GameObject obj)
        {
            if (this.CollisionBox.Intersects(obj.CollisionBox) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check which side of the player the mouse is on
        /// </summary>
        /// <returns>Boolean: true or false</returns>
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
