using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    class Damage : GameObjectPassive
    {
        private double timer;
        private int damage;
        public Damage(Vector2 startPosition, int damage) : base(startPosition, "damage")
        {
            this.damage = damage;
            position = startPosition;
        }

        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 0.7)
            {
                GameWorld.toBeRemovedPassive.Add(this);
            }
            position.Y -= 4;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GameWorld.damageFont, $"{damage}", position, Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
        }
    }
}
