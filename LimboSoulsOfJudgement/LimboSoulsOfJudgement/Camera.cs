using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimboSoulsOfJudgement
{
    class Camera
    {
        public Matrix viewMatrix;
        private Vector2 halfScreenSize;
        private Vector2 position;

        /// <summary>
        /// Property for the position
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
                UpdateViewMatrix();
            }
        }

        /// <summary>
        /// Camera constructor that sets the camera to the center of the screen
        /// </summary>
        public Camera()
        {
            halfScreenSize = new Vector2(GameWorld.ScreenSize.Width / 2, GameWorld.ScreenSize.Height / 2);
            UpdateViewMatrix();
        }

        /// <summary>
        /// Method that updates the camera position to the player position
        /// </summary>
        private void UpdateViewMatrix()
        {
            viewMatrix = Matrix.CreateTranslation(halfScreenSize.X - position.X, halfScreenSize.Y - position.Y, 0f);
        }
    }
}
