using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    public class Projectile : GameObject
    {
        int speed;
        public int damage;
        Vector2 dir;
        string team;
        private double timeToRemove;
        private bool remove = false;

        /// <summary>
        /// Projectile's Constructor, that sets the default position, sprite name, speed, damage, direction and team
        /// </summary>
        /// <param name="startPosition">Sets the start position of the Projectile GameObject</param>
        /// <param name="spriteName">Sets the sprite name of the Projectile GameObject</param>
        /// <param name="speed">Sets how fast that the Projectile GameObject travels</param>
        /// <param name="damage">Sets the default damage of the Projectile GameObject</param>
        /// <param name="dir">Sets the default direction of the Projectile GameObject</param>
        /// <param name="team">Sets the team of the Projectile GameObject; Player or Enemy team</param>
        public Projectile(Vector2 startPosition, string spriteName, int speed, int damage, Vector2 dir, string team) : base(startPosition, spriteName)
        {
            this.speed = speed;
            this.damage = damage;
            this.dir = dir;
            this.team = team;

            if (this.dir != Vector2.Zero)
            {
                this.dir.Normalize();
            }

            rotation = (float)Math.Atan2(dir.Y, dir.X);
        }

        /// <summary>
        /// Method that run every game tick. Propels the projectile forward and checks how long the arrow has been alive for
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position += dir * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (remove == true)
            {
                timeToRemove += gameTime.ElapsedGameTime.TotalSeconds;
                if (timeToRemove > 5)
                {
                    GameWorld.RemoveGameObject(this);
                }
            }

        }

        /// <summary>
        /// Method that draws the projectile
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.86f);
        }

        /// <summary>
        /// Check if we are colliding with an object.
        /// </summary>
        /// <param name="otherObject">The object we are colliding with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
            if (otherObject is Platform) //If object is platform then get stuck in it
            {
                speed = 0;
                damage = 0;
                remove = true;
            }
        }
    }
}