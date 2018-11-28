using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    public class Player : Character
    {
        public int currentSouls;

        private const float jumpPower = 1150;
        private double jumpForce = jumpPower;

        //private float maxJumpTime = 2f;
        private double jumpTime;

        private bool canJump = false;   //Controls wether the Player can jump or not
        private bool isJumping = false;

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

            HandleJumping(gameTime);
            
        }

        /* Method that handles jump functionality of the Player
         * Value is added to jumpTime until it reaches the value of jumpForce
         * Reduces the value of jumpForce, to give position.Y a certain stop point in the air
         * Once jumpTime and jumpForce value are at the same, stop point is reached and the player falls down through use of gravity
        */
        private void HandleJumping(GameTime gameTime)
        {
            if (isJumping)
            {
                jumpTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (jumpTime <= jumpForce)
                {
                    position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
                    jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 1500;
                }

                if (jumpTime >= jumpForce)
                {
                    isJumping = false;
                }
            }
            else if (!isJumping)
            {
                gravity = true;
            }
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

            //Statement that checks if the Player is jumping
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && canJump) 
            {
                isJumping = true;
            }

        }

        /// <summary>
        /// Method that handles player collision with other GameObjects
        /// </summary>
        /// <param name="otherObject">The GameObject that the player object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if(otherObject is Platform)
            {
                jumpForce = jumpPower;
                canJump = true;
                isJumping = false;
            }
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
     
    

