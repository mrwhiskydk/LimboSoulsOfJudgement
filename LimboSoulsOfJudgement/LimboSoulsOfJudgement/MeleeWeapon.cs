using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LimboSoulsOfJudgement
{
    public class MeleeWeapon : Weapon
    {
        private bool isAttacking = false;
        private float rotSpeed;

        public MeleeWeapon() : base("sword")
        {
            rotation += MathHelper.ToRadians(180);
        }

        public override void Attack()
        {
            isAttacking = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (equipped)
            {
                if (!isAttacking)
                {
                    //position = GameWorld.player.Position;
                }
                else
                {
                    rotation += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    rotSpeed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Vector2 localSword = new Vector2(0, 200);
                    Matrix swordMatrix = Matrix.CreateRotationZ(rotSpeed) * Matrix.CreateTranslation(new Vector3(GameWorld.player.Position, 0f));
                    position = Vector2.Transform(localSword, swordMatrix);
                }
            }
        }

        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Enemy)
            {
                
            }

            base.DoCollision(otherObject);
        }
    }
}