using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the default functionality and game logic of the Lava GameObject
    /// </summary>
    public class Lava : GameObject
    {
        /// <summary>
        /// Lava Constructor that sets the default values of start position and sprite name
        /// </summary>
        /// <param name="startPosition">Sets the default start position of the current Lava GameObject</param>
        /// <param name="spriteName">Sets the default sprite name of the current Lava GameObject</param>
        public Lava(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {

        }

        /// <summary>
        /// Overridden Draw Method that draws out the Lava sprite image
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.4f);

        }
    }
}
