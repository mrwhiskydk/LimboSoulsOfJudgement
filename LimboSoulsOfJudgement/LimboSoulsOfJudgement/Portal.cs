using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class Portal : AnimatedGameObject
    {
        /// <summary>
        /// Portal's Constructor, that sets the default start position and sprite name
        /// </summary>
        /// <param name="startPostion">default position of the Portal GameObject</param>
        public Portal(Vector2 startPostion) : base(8, 8, startPostion, "Portal")
        {
        }
    }
}
