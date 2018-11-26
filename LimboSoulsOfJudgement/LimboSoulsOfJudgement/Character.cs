using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    public class Character
    {
        protected int health;
        protected int maxHealth;
        protected float movementSpeed;

        protected int Health { get; set; }

        protected int MaxHealth { get; set; }

        /// <summary>
        /// Default Character Constructor
        /// </summary>
        public Character()
        {

        }

    }
}
