using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the Portal GameObject
    /// </summary>
    public class Portal : AnimatedGameObject
    {
        /// <summary>
        /// Portal's Constructor, that sets the default frame count, animation FPS(Frames Per Second) start position and sprite name
        /// </summary>
        /// <param name="startPostion">default position of the Portal GameObject</param>
        public Portal(Vector2 startPostion) : base(8, 8, startPostion, "Portal")
        {
        }
    }
}
