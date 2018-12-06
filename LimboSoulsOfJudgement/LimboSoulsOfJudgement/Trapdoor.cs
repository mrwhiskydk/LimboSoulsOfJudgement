using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class Trapdoor : GameObject
    {
        public Trapdoor(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
            if (otherObject is Player)
            {
                GameWorld.RemoveGameObject(this);
            }
        }
    }
}
