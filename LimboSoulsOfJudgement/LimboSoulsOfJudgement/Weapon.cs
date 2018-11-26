using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LimboSoulsOfJudgement
{
    public abstract class Weapon : GameObject
    {
        protected float attackRate = 1;
        protected float currentAttackRate = 1;
        protected int damage = 1;
        protected double lastAttack = 0;
        protected bool equipped = false;

        public Weapon(string spriteName) : base(spriteName)
        {

        }
    }
}