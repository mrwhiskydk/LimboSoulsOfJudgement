using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    class LightningBolt : Ability
    {
        private int speed = 1500;
        public int damage = 25;
        private Vector2 dir;

        public LightningBolt(Vector2 startPosition, Vector2 dir) : base(4, 100, startPosition, "Lightning")
        {
            this.dir = dir;

            if (this.dir != Vector2.Zero)
            {
                this.dir.Normalize();
            }

            rotation = (float)Math.Atan2(dir.Y, dir.X);
        }

        public override void Update(GameTime gameTime)
        {
            position += dir * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
