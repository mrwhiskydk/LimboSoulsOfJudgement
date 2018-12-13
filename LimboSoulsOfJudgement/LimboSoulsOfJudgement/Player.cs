using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    public class Player : Character
    {
        public MeleeWeapon melee;
        public RangedWeapon ranged;
        public Weapon weapon;
        public static Arm arm;
        public Ability ability1;
        private bool canSwitchWeapons = true;
        private double attackTimer = 0;
        public int currentSouls = 100;
        private double collisionMovement; // Used for collision so you dont need gameTime in DoCollision
        private bool hittingRoof = false; 

        public bool climb = false;
        //public bool svim = false;
        private bool goToBoss = false;
        private const float jumpPower = 1600;
        private double jumpForce = jumpPower;
        /// <summary>
        /// Det antal gange man kan dø før spillet starter helt forfra
        /// </summary>
        public int playerLives = 3;
        //private float maxJumpTime = 2f;
        private double jumpTime;
        public bool isJumping = false;

        public bool isRunning = false;

        // Special-stats
        /// <summary>
        /// Percentage of maxHealth added every 3 seconds, needs to be +0.01 of the desired percentage. dunno why
        /// </summary>
        public float healthRegen = 0.02f;
        private double healthRegenTimer;
        /// <summary>
        /// Percentage of damage added to player health
        /// </summary>
        public float lifeSteal = 0.1f;
        /// <summary>
        /// Percentage chance of dealing critDmgModifier damage
        /// </summary>
        public float critChance = 0.01f;
        /// <summary>
        /// Percentage of original damage the player crits
        /// </summary>
        public float critDmgModifier = 1.5f;


        public bool editMode = false;

        /// <summary>
        /// Player constructor that sets player animation values, position and sprite name
        /// </summary>
        public Player() : base(5, 5,new Vector2(200, 500), "PlayerIdle")
        {
            arm = new Arm();
            melee = new MeleeWeapon();
            ranged = new RangedWeapon();
            ability1 = new LightningBolt();

            //Maximum amount of Player health
            maxHealth = 100;
            health = maxHealth;

            
            //Player movementspeed amount
            movementSpeed = 500;

            //Weapon setup
            weapon = melee;
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

            // If the player is under maxHealth activate healthRegen
            if (Health < maxHealth)
            {
                healthRegenTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (healthRegenTimer > 3)
                {
                    Health += (int)(healthRegen * maxHealth);
                    healthRegenTimer = 0;
                }
            }

            if (isJumping == true)
            {
                State(3, "PlayerJump");
            }
            else if (isRunning == true)
            {
                State(4, "PlayerRun");
            }
            
            else
            {
                State(5, "PlayerIdle");
            }


            HandleMovement(gameTime);
            climb = false;
            canJump = false;

            HandleJumping(gameTime);

            HandleWeapons(gameTime);

            HandleAbilities(gameTime);

            if (isImmortal)
            {
                immortalTime += gameTime.ElapsedGameTime.TotalSeconds;  //Adding +1 second to immortalTime, until it reaches 3 seconds
                if (immortalTime > immortalDuration)
                {
                    isImmortal = false;
                    immortalTime = 0;   //Upon reaching 3 seconds, immortalTime is reset to 0
                }
            }

            if (editMode == true)
            {
                movementSpeed = 1500;
                maxHealth = 10000;
            }
            if (editMode == false)
            {
                movementSpeed = 500;
                maxHealth = 100;                
            }

            if (goToBoss == true)
            {
                GameWorld.stage = 10;
                GameWorld.teleport = true;
                goToBoss = false;
            }
        }

        /* Method that handles jump functionality of the Player
         * Value is added to jumpTime until it reaches the value of jumpForce
         * Reduces the value of jumpForce, to give position.Y a certain stop point in the air
         * Once jumpTime and jumpForce value are at the same, stop point is reached and the player falls down through use of gravity
        */
        private void HandleJumping(GameTime gameTime)
        {
            if (editMode == false)
            {
if (isJumping)
            {
                jumpTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (jumpTime <= jumpForce)
                {
                    if (hittingRoof is false )
                    {
                        position.Y -= (float)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds);
                    }
                    else
                    {
                        gravity = false;
                        jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 6000;
                    }
                    jumpForce -= gameTime.ElapsedGameTime.TotalSeconds * 1500;
                }

                if (jumpTime >= jumpForce && climb == false)
                {
                    isJumping = false;
                    Gravity = true;
                    hittingRoof = false;
                }
            }
            else if (!isJumping)
            {
                gravity = true;
                hittingRoof = false;
                jumpTime = 0;
            }
            }
            
        }

        /// <summary>
        /// Method that sets the default movement functionality of the Player
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected override void HandleMovement(GameTime gameTime)
        {
            if (editMode == false)
            {
            gravity = true;
            }
            if (editMode == true)
            {
                gravity = false;
            }

            isRunning = false;

            //Statement that checks if Player is moving to the left
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                isRunning = true;
                facingRight = false;
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                isRunning = false;
            }

            //Statement that checks if Player is moving to the right
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                isRunning = true;
                facingRight = true;
                position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                isRunning = false;
            }
            //Statement that checks if the Player is jumping
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && canJump) 
            {
                isJumping = true;
            }

            if (climb == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    position.Y -= (float)(0.7 * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    position.Y += (float)(0.7 * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
            if (editMode == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    position.Y -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    position.Y += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
            //if (svim == true)
            //{
            //    movementSpeed -= 250;
            //}
            //else
            //{
            //    movementSpeed = 500;
            //}

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

            attackTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (attackTimer >= Weapon.currentAttackRate)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && !GameWorld.triggerVendor)
                {
                    weapon.Attack();
                    attackTimer = 0;
                }
            }
        }

        public void HandleAbilities(GameTime gameTime)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                ability1.Use();
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
            Rectangle topLine = new Rectangle(CollisionBox.X + 8, CollisionBox.Y, CollisionBox.Width - 16, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X + 10, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width - 20, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y + 15, 1, CollisionBox.Height - 30);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y + 15, 1, CollisionBox.Height - 30);

            // If the player stands on a platform, make him able to jump
            if (bottomLine.Intersects(otherObject.CollisionBox) && otherObject is Platform)
            {
                jumpForce = jumpPower;
                canJump = true;
                isJumping = false;
            }

            if (otherObject is Chain)
            {
                climb = true;
                Gravity = false;
                jumpForce = 0; // makes so the player cant jump on the chain
            }

            // If the small collisionboxes intersects with a platform move the player in the opposite direction. 
            if (otherObject is Platform)
            {
                if (editMode == false)
                {
                    if (rightLine.Intersects(otherObject.CollisionBox))
                    {
                    Gravity = true;
                    position.X -= (float)collisionMovement;
                   
                }
                else if (leftLine.Intersects(otherObject.CollisionBox))
                {
                    Gravity = true;
                    position.X += (float)collisionMovement;
                }

                if (topLine.Intersects(otherObject.CollisionBox))
                {
                    // Used to prevent the player from going into a platform on the top of a chain
                    if (Gravity is false)
                    {
                        position.Y += (float)(0.7f * collisionMovement);
                    }

                    // Makes so the player does not stay stuck to the roof
                    if (hittingRoof is false && climb is false)
                    {
                        Gravity = true;
                    }
                    canJump = false;
                    hittingRoof = true;

                    // Makes so the player does not get "sucked" to the roof with small jumps
                    if (jumpTime < 0.15f)
                    {
                        isJumping = false;
                    }
                    }

                   
                }



                // Maybe not used anymore
                //if (bottomLine.Intersects(otherObject.CollisionBox) && Gravity is true)
                //{
                //    position.Y -= GameWorld.gravityStrength; 
                //    Gravity = false;
                //}
                if (editMode == false)
                {
                if (bottomLine.Intersects(otherObject.CollisionBox) && (leftLine.Intersects(otherObject.CollisionBox) is false || (rightLine.Intersects(otherObject.CollisionBox) is false)))
                {
                    // Makes the player get ontop of the platform and not halfway indside like in the begining, this also fixed collsion bug
                    while (CollisionBox.Intersects(otherObject.CollisionBox))
                    {
                        position.Y -= 1;
                    }
                    position.Y += 1;

                }
                }

            }

            if (otherObject is Enemy && isImmortal == false)
            {
                Enemy enemy = (Enemy)otherObject;
                health -= enemy.enemyDamage;
                isImmortal = true;
            }

            if (otherObject is Lava && isImmortal == false)
            {
                health -= 10;
                isImmortal = true;
                //svim = true;
            }

            if (otherObject is Portal && Keyboard.GetState().IsKeyDown(Keys.E) && GameWorld.teleport == false)
            {
                goToBoss = true;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (isImmortal == true && facingRight == false)
            {

                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.Red, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.FlipHorizontally, 0.97f);

            }

            if (isImmortal == true && facingRight == true)
            {

                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.Red, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0.97f);

            }
        }
    }
}
     
    

