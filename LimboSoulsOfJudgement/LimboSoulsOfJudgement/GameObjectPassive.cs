using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class GameObjectPassive
    {
        protected Texture2D sprite;

        protected float rotation;
        protected Vector2 position;

        /// <summary>
        /// Property for the position of current GameObject
        /// </summary>
        public Vector2 Position { get => position; set => position = value; }


        /// <summary>
        /// The default constructor for a GameObject
        /// </summary>
        /// <param name="content">Reference to a ContentManager for loading resources</param>
        /// <param name="spriteName">The name of the texture resource the should be used for the sprite</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObjectPassive(string spriteName) : this(Vector2.Zero, spriteName)
        {

        }

        /// <summary>
        /// Constructor that sets the starting position of the GameObject
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="spriteName">The name of the texture resource the should be used for the sprite</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObjectPassive(Vector2 startPosition, string spriteName)
        {
            position = startPosition;
            sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
            GameWorld.gameObjectsPassive.Add(this);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Destroy()
        {
            GameWorld.RemoveGameObjectPassive(this);
        }

        /// <summary>
        /// Enables the GameObject to be drawn. The std. functionality is to draw its sprite.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to use for drawing</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X, position.Y), null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.991f);
        }
    }
}
