using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    public class HealthBar : GameObject
    {
        public Texture2D healthBarTexture;
        private Rectangle healthBarSize;

        public HealthBar(Vector2 startPosition) : base(startPosition, "healthBar")
        {
            position = startPosition;

        }

        /// <summary>
        /// Update method that handles updating the position of the healthbar and the size based on how much health the player has left.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            float size = (((float)GameWorld.player.Health / (float)GameWorld.player.MaxHealth) * 100f) * (float)healthBarTexture.Width / 100f;
            position = new Vector2(GameWorld.camera.Position.X - healthBarTexture.Width * 0.5f, GameWorld.ScreenSize.Y - GameWorld.camera.viewMatrix.Translation.Y + 50);
            healthBarSize = new Rectangle((int)(position.X - healthBarTexture.Width * 0.5), (int)(position.Y - healthBarTexture.Height * 0.5), (int)size, healthBarTexture.Height);
        }

        /// <summary>
        /// Draw method that handles the draw of the healthbar
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(healthBarTexture, position, healthBarSize, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.992f);
            spriteBatch.Draw(GameWorld.healthBarOutline, new Vector2(position.X - 10, position.Y - 10), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
        }
    }
}
