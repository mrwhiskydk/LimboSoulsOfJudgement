using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{

    public class LightningBolt : Ability
    {
        

        public LightningBolt() : base(new Vector2(300, 300), "LightningBolt")
        {
            cooldown = 10;
            cooldownTimer = cooldown;
        }

        public override void UseAbility()
        {
            Vector2 playerPosition = GameWorld.player.Position;
            Vector2 direction = new Vector2(GameWorld.mouse.Position.X, GameWorld.mouse.Position.Y) - playerPosition;

            new LightningBoltAbility(playerPosition, direction);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position = UIAbilityBar.abilitySlot1;
        }


        class LightningBoltAbility : AnimatedGameObject
        {
            private int speed = 1000;
            public int damage = 25;
            private Vector2 dir;
            private double timeAlive = 0;

            public LightningBoltAbility(Vector2 startPosition, Vector2 dir) : base(4, 20, startPosition, "Lightning")
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
                base.Update(gameTime);

                timeAlive += gameTime.ElapsedGameTime.TotalSeconds;
                if (timeAlive >= 3)
                {
                    Destroy();
                }
            }

            public override void DoCollision(GameObject otherObject)
            {
                if (otherObject is Enemy)
                {
                    Enemy obj = (Enemy)otherObject;

                    if (obj.isImmortal is false)
                    {
                        new Damage(new Vector2(position.X, position.Y - sprite.Height * 0.5f), damage);
                    }

                    obj.Health -= damage;
                    obj.aggro = true;
                    
                }
            }
        }
    }
}
