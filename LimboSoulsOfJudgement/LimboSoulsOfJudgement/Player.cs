using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    public class Player : Character
    {

        private const float jumpPower = 1000;


        /// <summary>
        /// Player constructor that sets player animation values, position and sprite name
        /// </summary>
        public Player() : base(3, 12, new Vector2(GameWorld.ScreenSize.Width / 2, GameWorld.ScreenSize.Height/2), "Melee2")
        {
            //Maximum amount of Player health
            maxHealth = 100;
            health = maxHealth;

            //Player movementspeed amount
            movementSpeed = 250;
        }

        /// <summary>
        /// Update method that enables Player movement
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            HandleMovement(gameTime);
        }

        /// <summary>
        /// Method that sets the default movement functionality of the Player
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            gravity = true;

            //Statement that checks if Player is moving to the left
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                facingRight = false;
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            //Statement that checks if Player is moving to the right
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                facingRight = true;
                position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            //Statement that checks if the Player is jumping, and handles Player jumpforce while in the air 
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {

            }
        }

        /// <summary>
        /// Method that handles player collision with other GameObjects
        /// </summary>
        /// <param name="otherObject">The GameObject that the player object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
        }

        /// <summary>
        /// Draws the Player sprite in a specific way.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch that is used for drawing</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
     
    

