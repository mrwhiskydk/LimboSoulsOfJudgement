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
        public Portal(Vector2 startPostion) : base(8, 8, startPostion, "Portal")
        {
        }
    }
}
