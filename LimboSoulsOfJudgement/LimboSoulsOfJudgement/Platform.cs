using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the Platform GameObject
    /// </summary>
    public class Platform : GameObject
    {
        public Platform(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
        }

    }
}