using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    public class Player : Character
    {
        MeleeWeapon melee = new MeleeWeapon();
        RangedWeapon ranged = new RangedWeapon();
        Weapon weapon;
        private bool canSwitchWeapons = true;
        private double attackTimer = 0;
        public int currentSouls;
        private double collisionMovement;

        private const float jumpPower = 1150;
        private double jumpForce = jumpPower;

        //private float maxJumpTime = 2f;
        private double jumpTime;

        private bool canJump = false;   //Controls wether the Player can jump or not
        private bool isJumping = false;

        /// <summary>
        /// Player constructor that sets player animation values, position and sprite name
        /// </summary>
        public Player() : base(5, 5, new Vector2(GameWorld.ScreenSize.Width / 2, GameWorld.ScreenSize.Height/2), "PlayerIdle")
        {
            //Maximum amount of Player health
            maxHealth = 100;
            health = maxHealth;

            //Player movementspeed amount
            movementSpeed = 250;

            //Weapon setup
            weapon = ranged;
            weapon.equipped = true;
        }

        /// <summary>
        /// Update method that enables Player movement, jumping and attacking mechanism
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            collisionMovement = movementSpeed * gameTime.ElapsedGameTime.TotalSeconds;

            HandleMovement(gameTime);

            HandleJumping(gameTime);

            HandleWeapons(gameTime);
            
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
        /// Switch the equipped weapon
        /// </summary>
        private void HandleWeapons(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Tab) && canSwitchWeapons)
            {
                if (weapon is MeleeWeapon)
                {
                    weapon.equipped = false;
                    weapon = ranged;
                    weapon.equipped = true;
                    
                }
                else
                {
                    weapon.equipped = false;
                    weapon = melee;
                    weapon.equipped = true;
                    
                }
                canSwitchWeapons = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Tab))
            {
                canSwitchWeapons = true;
            }
            weapon.Position = position;

            attackTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (attackTimer >= Weapon.currentAttackRate)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    weapon.Attack();
                    attackTimer = 0;
                }
            }
        }

        /// <summary>
        /// Method that handles player collision with other GameObjects
        /// </summary>
        /// <param name="otherObject">The GameObject that the player object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            // Creates small collisionboxes around the player to be used for collision
            Rectangle topLine = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X + 15, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width - 30, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y + 8, 1, CollisionBox.Height - 16);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y + 8, 1, CollisionBox.Height - 16);

            // If the player stands on a platform, make him able to jump
            if (bottomLine.Intersects(otherObject.CollisionBox) && otherObject is Platform)
            {
                jumpForce = jumpPower;
                canJump = true;
                isJumping = false;
            }

            // If the small collsionboxes intesects with a platform move the player in the opposite direction. 
            if (otherObject is Platform)
            {
                if (rightLine.Intersects(otherObject.CollisionBox))
                {
                    position.X -= (float)collisionMovement;
                    Gravity = true;
                }

                if (leftLine.Intersects(otherObject.CollisionBox))
                {
                    position.X += (float)collisionMovement;
                    Gravity = true;
                }

                if (topLine.Intersects(otherObject.CollisionBox))
                {
                    jumpForce = 0;
                    canJump = false;
                    Gravity = true;
                }

                if (bottomLine.Intersects(otherObject.CollisionBox) && Gravity is true)
                {
                    position.Y -= + 7;
                    Gravity = false;
                }
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
     
    

