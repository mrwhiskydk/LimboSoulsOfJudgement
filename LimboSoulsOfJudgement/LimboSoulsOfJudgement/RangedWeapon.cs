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

        public RangedWeapon() : base("bow")
        {
            
        }

        public override void Attack()
        {
            Vector2 dir = new Vector2(Mouse.GetState().Position.X - GameWorld.camera.viewMatrix.Translation.X, Mouse.GetState().Position.Y - GameWorld.camera.viewMatrix.Translation.Y) - position;

            for (int i = 0; i < amountToFire; i++)
            {
                new Projectile(position, arrowSprite, speed, damage, dir, "player");
            }
        }
    }
}