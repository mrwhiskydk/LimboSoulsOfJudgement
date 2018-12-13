using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    public class RangedWeapon : Weapon
    {
        private int speed = 1000;
        private int amountToFire = 1;
        public string arrowSprite = "arrow";
        private int offset = 50;

        public RangedWeapon() : base("bow")
        {
            damage = 5;
        }

        public override void Attack()
        {
            //How many projectiles to fire. Can be used in the future if a bow shoots more than 1 arrow at a time. Would need to add some spread then so they dont all stack on each other
            Vector2 dir = new Vector2(GameWorld.mouse.Position.X, GameWorld.mouse.Position.Y) - position;

            for (int i = 0; i < amountToFire; i++)
            {
                new Projectile(position, arrowSprite, speed, damage, dir, "player");
            }
        }

        public override void Update(GameTime gameTime)
        {
            /*Matrix swordMatrix = Matrix.CreateRotationZ(1) * Matrix.CreateTranslation(new Vector3(GameWorld.player.Position, 0f));
            position = Vector2.Transform(offset, swordMatrix);*/

            if (equipped)
            {
                float angle;
                // If the mouse is within 110 distance of the player, makes so the bow do not freak out.
                if (Vector2.Distance(GameWorld.mouse.Position, Player.arm.Position) < 110)
                {
                    angle = (float)Math.Atan2(GameWorld.mouse.Position.X - Player.arm.Position.X, GameWorld.mouse.Position.Y - Player.arm.Position.Y);
                    rotation = MathHelper.ToRadians(MathHelper.ToDegrees(Player.arm.rotation) + 90);
                    position = Player.arm.Position + new Vector2(offset * (float)Math.Sin(angle), offset * (float)Math.Cos(angle));
                }
                else
                {
                    //Orbit bow around player according to mouse
                    angle = (float)Math.Atan2(GameWorld.mouse.Position.X - position.X, GameWorld.mouse.Position.Y - position.Y);
                    position = Player.arm.Position + new Vector2(offset * (float)Math.Sin(angle), offset * (float)Math.Cos(angle));
                    //Rotate bow according to mouse
                    Vector2 dir = new Vector2(GameWorld.mouse.Position.X, GameWorld.mouse.Position.Y) - position;
                    if (dir != Vector2.Zero)
                    {
                        dir.Normalize();
                    }
                    rotation = (float)System.Math.Atan2(dir.Y, dir.X);
                }
            }
        }
    }
}