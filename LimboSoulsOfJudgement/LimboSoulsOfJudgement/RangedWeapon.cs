using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LimboSoulsOfJudgement
{
    public class RangedWeapon : Weapon
    {
        private int speed = 1000;
        private int amountToFire = 1;

        public RangedWeapon() : base("bow")
        {

        }
    }
}