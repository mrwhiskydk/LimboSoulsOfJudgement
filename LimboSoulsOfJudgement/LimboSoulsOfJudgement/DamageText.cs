using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    class DamageText : GameObjectPassive
    {
        private double timer;
        private int damage;
        private float scale = 1;
        private bool crit;
        private bool heal;

        /// <summary>
        /// The constructor used for showing damage dealt
        /// </summary>
        /// <param name="startPosition">The start position of the damage</param>
        /// <param name="damage">The amount of damage</param>
        /// <param name="scale">The size of the text</param>
        /// <param name="crit">Is it a crit or not</param>
        public DamageText(Vector2 startPosition, int damage, float scale, bool crit) : base(startPosition, "damage")
        {
            this.damage = damage;
            position = startPosition;
            this.scale = scale;
            this.crit = crit;
        }

        /// <summary>
        /// The constructor used for healing 
        /// </summary>
        /// <param name="startPosition">The start position of the heal</param>
        /// <param name="damage">The amount of healing</param>
        /// <param name="heal">is it healing</param>
        public DamageText(Vector2 startPosition, int damage, bool heal) : base(startPosition, "damage")
        {
            this.damage = damage;
            position = startPosition;
            this.heal = heal;
        }

        /// <summary>
        /// Update method that removes the object after 0.7 seconds and moves it upwards
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 0.7)
            {
                GameWorld.toBeRemovedPassive.Add(this);
            }
            position.Y -= (float)(200 * gameTime.ElapsedGameTime.TotalSeconds);
        }

        /// <summary>
        /// Draw method that draws both damage text and healing text
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!heal)
            {
                if (!crit)
                {
                    spriteBatch.DrawString(GameWorld.damageFont, $"{damage}", position, Color.Gold, 0f, Vector2.Zero, scale, SpriteEffects.None, 0.996f);

                }
                else
                {
                    spriteBatch.DrawString(GameWorld.damageFont, $"{damage}", new Vector2(position.X - 2, position.Y - 6), Color.Red, 0f, Vector2.Zero, scale + 0.3f, SpriteEffects.None, 0.995f);
                }
            }
            else
            {
                spriteBatch.DrawString(GameWorld.damageFont, $"{damage}", position, Color.Green, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.996f);
            }
        }
    }
}
