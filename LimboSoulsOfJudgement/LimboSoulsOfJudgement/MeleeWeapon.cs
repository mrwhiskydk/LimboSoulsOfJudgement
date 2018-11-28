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

        public MeleeWeapon() : base("sword")
        {

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
                    position = new Vector2(GameWorld.player.Position.X, GameWorld.player.Position.Y - 100);
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