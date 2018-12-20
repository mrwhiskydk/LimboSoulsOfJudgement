using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class Chain : GameObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPosition">the start position</param>
        /// <param name="spriteName">The name of the sprite</param>
        public Chain(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
        }

    }
}
