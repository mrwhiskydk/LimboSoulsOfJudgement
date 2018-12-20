﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class GameObject
    {
        /// <summary>
        /// The sprite texture of the GameObject
        /// </summary>
        protected Texture2D sprite;
        /// <summary>
        /// The rotation of the GameObject
        /// </summary>
        protected float rotation;
        /// <summary>
        /// The position of the GameObject
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Sets the default gravity for the current GameObject
        /// </summary>
        protected bool gravity = false;

        /// <summary>
        /// Property for the position of current GameObject
        /// </summary>
        public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// Property that sets gravity value of the current GameObject
        /// </summary>
        public bool Gravity { get => gravity; set => gravity = value; }

        /// <summary>
        /// The Collision Box of the GameObject. The default box is based upon the GameObject position and sprite size
        /// </summary>
        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - sprite.Width * 0.5), (int)(position.Y - sprite.Height * 0.5), sprite.Width, sprite.Height);
            }
        }



        /// <summary>
        /// Checks if the current object collides with another object
        /// </summary>
        /// <param name="otherObject">The other GameObject that should be tested against</param>
        /// <returns>Returns true if current object collides with otherObject otherwise false</returns>
        public virtual bool IsColliding(GameObject otherObject)
        {
            return CollisionBox.Intersects(otherObject.CollisionBox);
        }

        /// <summary>
        /// Enabled the GameObject to handle collisions in a custom way
        /// </summary>
        /// <param name="otherObject">The GameObject that the current GameObject collides with</param>
        public virtual void DoCollision(GameObject otherObject)
        {
            if(otherObject is Platform)
            {
                Gravity = false;
            }
        }

        /// <summary>
        /// Specialized constructor for something like the Crosshair class where we need to update manually to ensure correct order
        /// </summary>
        public GameObject()
        {

        }

        /// <summary>
        /// The default constructor for a GameObject
        /// </summary>
        /// <param name="spriteName">The name of the texture resource the should be used for the sprite</param>
        public GameObject(string spriteName) : this(Vector2.Zero, spriteName)
        {

        }

        /// <summary>
        /// Constructor that sets the starting position of the GameObject
        /// </summary>
        /// <param name="startPosition">The start position</param>
        /// <param name="content">Reference to a ContentManager for loading resources</param>
        /// <param name="spriteName">The name of the texture resource the should be used for the sprite</param>
        /// <exception cref="Microsoft.Xna.Framework.Content.ContentLoadException">Thrown if a matching texture cant be found for spriteName</exception>
        public GameObject(Vector2 startPosition, string spriteName)
        {
            position = startPosition;
            sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
            GameWorld.AddGameObject(this);
        }

        /// <summary>
        /// Destoys this object
        /// </summary>
        public virtual void Destroy()
        {
            GameWorld.RemoveGameObject(this);
        }

        /// <summary>
        /// Enabled the GameObject to have game logic defined
        /// </summary>
        /// <param name="gameTime">The elasped time since last update call</param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Enables the GameObject to be drawn. The std. functionality is to draw its sprite.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to use for drawing</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.5f);
        }
    }
}
