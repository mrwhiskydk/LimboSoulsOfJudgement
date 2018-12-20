using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class KarmaBar : GameObjectPassive
    {
        /// <summary>
        /// The texture of the karmaBar
        /// </summary>
        public Texture2D karmaBarTexture;
        private Rectangle karmaBarSize;
        float size;

        /// <summary>
        /// KarmaBar constructor that sets the position and sprite
        /// </summary>
        /// <param name="startPosition">The initial position of the HealthBar</param>
        public KarmaBar(Vector2 startPosition) : base(startPosition, "karmaBar")
        {
            
        }

        /// <summary>
        /// Update method that updates the position of the karmabar and the size based on how much good karma in comparison to bad karma.
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
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

            position = new Vector2(GameWorld.camera.Position.X - karmaBarTexture.Width * 0.5f, GameWorld.ScreenSize.Y - GameWorld.camera.viewMatrix.Translation.Y + 50);
            karmaBarSize = new Rectangle((int)(position.X - karmaBarTexture.Width * 0.5), (int)(position.Y - karmaBarTexture.Height * 0.5), (int)size, karmaBarTexture.Height);
            
        }

        /// <summary>
        /// Draw method that draws the karmabar and the text in the karmabar
        /// </summary>
        /// <param name="spriteBatch">The spritebatch used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(karmaBarTexture, position, karmaBarSize, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.992f);
            spriteBatch.Draw(GameWorld.karmaBarOutline, new Vector2(position.X - 10, position.Y - 10), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(GameWorld.font, $"Angelic Karma:{GameWorld.goodKarmaButton.currentKarma}", new Vector2(GameWorld.karmaBar.position.X, GameWorld.karmaBar.position.Y), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.993f);
            if (GameWorld.badKarmaButton.currentKarma < 10)
            {
                spriteBatch.DrawString(GameWorld.font, $"Demonic Karma:{GameWorld.badKarmaButton.currentKarma}", new Vector2(GameWorld.karmaBar.position.X + GameWorld.karmaBar.sprite.Width - 127, GameWorld.karmaBar.position.Y), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.993f);
            }
            else if (GameWorld.badKarmaButton.currentKarma < 100)
            {
                spriteBatch.DrawString(GameWorld.font, $"Demonic Karma:{GameWorld.badKarmaButton.currentKarma}", new Vector2(GameWorld.karmaBar.position.X + GameWorld.karmaBar.sprite.Width - 137, GameWorld.karmaBar.position.Y), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.993f);
            }
        }
    }
}
