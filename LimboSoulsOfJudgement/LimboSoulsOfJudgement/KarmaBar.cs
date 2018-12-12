using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class KarmaBar : GameObject
    {
        public Texture2D karmaBarTexture;
        private Rectangle karmaBarSize;
        float size;

        /// <summary>
        /// KarmaBar constructor that sets the position and sprite
        /// </summary>
        /// <param name="startPosition">The initial position of the HealthBar</param>
        public KarmaBar(Vector2 startPosition) : base(startPosition, "karmaBar")
        {
            position = startPosition;
        }

        /// <summary>
        /// Update method that updates the position of the karmabar and the size based on how much good karma in comparison to bad karma.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
            if (GameWorld.goodKarmaButton.currentKarma == GameWorld.badKarmaButton.currentKarma)
            {
                 size = karmaBarTexture.Width * 0.5f;
            }
            else if (GameWorld.goodKarmaButton.currentKarma > 0 && GameWorld.badKarmaButton.currentKarma == 0)
            {
                size = karmaBarTexture.Width;
            }
            else if (GameWorld.badKarmaButton.currentKarma > 0 && GameWorld.goodKarmaButton.currentKarma == 0)
            {
                size = 0;
            }
            else
            {
                size = ((float)GameWorld.goodKarmaButton.currentKarma / ((float)GameWorld.goodKarmaButton.currentKarma + (float)GameWorld.badKarmaButton.currentKarma) * 100f) * (float)karmaBarTexture.Width / 100f;
            }

            position = new Vector2(GameWorld.camera.Position.X - karmaBarTexture.Width * 0.5f, GameWorld.ScreenSize.Y - GameWorld.camera.viewMatrix.Translation.Y + 100);
            karmaBarSize = new Rectangle((int)(position.X - karmaBarTexture.Width * 0.5), (int)(position.Y - karmaBarTexture.Height * 0.5), (int)size, karmaBarTexture.Height);
            
        }

        /// <summary>
        /// Draw method that draws the karmabar
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(karmaBarTexture, position, karmaBarSize, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.992f);
            spriteBatch.Draw(GameWorld.karmaBarOutline, new Vector2(position.X - 10, position.Y - 10), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(GameWorld.font, $"Karma: {(float)GameWorld.goodKarmaButton.currentKarma / ((float)GameWorld.goodKarmaButton.currentKarma + (float)GameWorld.badKarmaButton.currentKarma) * 100f}%", new Vector2(GameWorld.karmaBar.Position.X, GameWorld.karmaBar.Position.Y), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.993f);
        }
    }
}
