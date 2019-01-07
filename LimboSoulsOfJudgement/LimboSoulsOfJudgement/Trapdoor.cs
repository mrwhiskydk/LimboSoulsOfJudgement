using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the Trapdoor GameObject
    /// </summary>
    public class Trapdoor : GameObject
    {
        private Sound sound;

        /// <summary>
        /// Trapdoor's Constructor, that sets the default values of start position and sprite name
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="spriteName"></param>
        public Trapdoor(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
            sound = new Sound("sound/trapdoor");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherObject"></param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
            if (otherObject is Player)
            {
                sound.Play();
                GameWorld.RemoveGameObject(this);
            }
        }
    }
}
