using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class Platform : GameObject
    {
        /// <summary>
        /// Constructer for the gameobject Platform
        /// </summary>
        /// <param name="startPosition">The starting position of the platform</param>
        /// <param name="spriteName">The name of the sprite used for platforms</param>
        public Platform(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
        }

    }
}