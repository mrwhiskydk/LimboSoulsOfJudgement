using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the Player GameObject
    /// </summary>
    public class Player : Character
    {
        /// <summary>
        /// Sets the current equipped melee weapon on the Player GameObject, of the Weapon/MeleeWeapon Class
        /// </summary>
        public MeleeWeapon melee;

        /// <summary>
        /// Sets the current equipped ranged weapon on the Player GameObject, of the Weapon/RangedWeapon Class
        /// </summary>
        public RangedWeapon ranged;

        /// <summary>
        /// Sets the current Weapon GameObject of the Player GameObject
        /// </summary>
        public Weapon weapon;

        /// <summary>
        /// Sets the Arm GameObject of the Player GameObject
        /// </summary>
        public static Arm arm;

        /// <summary>
        /// Sets the first Ability GameObject, of the AbilityBar, on the Player GameObject
        /// </summary>
        public Ability ability1;
        public Ability ability2;
        private bool canSwitchWeapons = true;
        private double attackTimer = 0;

        /// <summary>
        /// Sets the amount of souls the Player currently has. 
        /// Used as a currency, in order for the user to upgrade specific given stat values of the Player GameObject
        /// </summary>
        public int currentSouls = 10000;

        private double collisionMovement; // Used for collision so you dont need gameTime in DoCollision
        private bool hittingRoof = false;
        private bool inAir;
        private double newLevelTimer;
        private double chainJumpTimer;
        private double ultimateTimer;

        /// <summary>
        /// Sets the value for wether or not the Player GameObject is able to climb up specific GameObjects
        /// </summary>
        public bool climb = false;
        //public bool svim = false;
        private bool nextLevel = false;
        private const float jumpPower = 1600;
        private double jumpForce = jumpPower;

        /// <summary>
        /// The number of times you can die before the game starts over
        /// </summary>
        public int playerLives = 3;
        //private float maxJumpTime = 2f;
        private double jumpTime;

        /// <summary>
        /// Sets the value for wether or not the Player GameObject is jumping/in the air. Also sets the jumping animation of the Player if true
        /// </summary>
        public bool isJumping = false;

        /// <summary>
        /// Sets the running animation of the Player, if value is true. 
        /// </summary>
        public bool isRunning = false;

        public bool hit = false;
        // Special-stats
        /// <summary>
        /// Percentage of maxHealth added every 3 seconds, needs to be +0.01 of the desired percentage. dunno why
        /// </summary>
        public float healthRegen = 0.00f;
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

        private float coolDownTime = 2f;
        private double editCooldown;
        private bool editKeyPressed = false;
        public bool editMode = false;

        /// <summary>
        /// Player constructor that sets player animation values, position and sprite name. 
        /// Sets the current equipped Weapon, Arm and Ability GameObjects: MeleeWeapon, RangedWeapon, Arm, BloodstormAbility & LightningBoltAbility.
        /// MeleeWeapon is equipped as default.
        /// Sets the Player GameObject's Movement Speed to a default value of 400, 
        /// maximum amount of health value of 100 & sets the current amount of health, equal to the value of its maxumim health.
        /// </summary>
        public Player() : base(5, 5,new Vector2(200, 500), "PlayerIdle")
        {
            arm = new Arm();
            melee = new MeleeWeapon();
            ranged = new RangedWeapon();
            ability1 = new BloodstormAbility();
            ability2 = new UltimateAbility();

            //Maximum amount of Player health
            maxHealth = 100;
            health = maxHealth;

            
            //Player movementspeed amount
            movementSpeed = 400;

            //Weapon setup
            weapon = melee;
            weapon.equipped = true;

            knockbackDuration = 0.4f;
        }

        /// <summary>
        /// Update method that enables Player movement, jumping and attacking mechanisms.
        /// Handles the Health Regen stat functionality, the different Player animation sprites, duration amount of the Player's immortality, teleport & level changes
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            collisionMovement = movementSpeed * gameTime.ElapsedGameTime.TotalSeconds;
            newLevelTimer += gameTime.ElapsedGameTime.TotalSeconds;
            chainJumpTimer += gameTime.ElapsedGameTime.TotalSeconds;
            // If the player is under maxHealth activate healthRegen
            if (health < maxHealth)
            {
                healthRegenTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (healthRegenTimer > 3)
                {
                    health += (int)(healthRegen * maxHealth);
                    healthRegenTimer = 0;
                }
            }

            if (isJumping == true || climb == true || inAir)
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
            inAir = true;

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
                currentSouls = 10000;
            }
            if (editMode == false)
            {
                movementSpeed = 500;
                maxHealth = 100;
            }

            if (nextLevel == true)
            {
                GameWorld.stage = 10;
                GameWorld.teleport = true;
                nextLevel = false;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.T) && editMode == false && editKeyPressed == false)
            {
                editMode = true;
                editKeyPressed = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.T) && editMode == true && editKeyPressed == false)
            {
                editMode = false;
                editKeyPressed = true;
            }

            if (editKeyPressed == true)
            {
                editCooldown += gameTime.ElapsedGameTime.TotalSeconds;
                if (editCooldown > coolDownTime)
                {
                    editKeyPressed = false;
                    editCooldown = 0;
                }
            }

            if (knockback == true)
            {
                knockbackTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (hit)
                {
                    position.X -= (float)(knockbackDistance * (movementSpeed * 0.5) * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (!hit)
                {
                    position.X += (float)(knockbackDistance * (movementSpeed * 0.5) * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (knockbackTime > knockbackDuration)
                {
                    knockback = false;
                    knockbackTime = 0;
                }
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
                        if (hittingRoof is false)
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

            //isRunning = false;

            //Statement that checks if Player is moving to the left
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                isRunning = true;
                facingRight = false;
                position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            //Statement that checks if Player is moving to the right
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
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
                chainJumpTimer = 0;
            }

            //Statement that checks if the Player is climbing
            if (climb == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))  //Makes the Player climb up a Chain GameObject
                {
                    position.Y -= (float)(0.7 * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))  //Makes the Player climb down a Chain GameObject
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

        /// <summary>
        /// Method that checks if the current Ability has been purchased & 
        /// enables the Q button to be pressed, in order to shoot the Ability
        /// </summary>
        /// <param name="gameTime"></param>
        public void HandleAbilities(GameTime gameTime)
        {          
            if (Keyboard.GetState().IsKeyDown(Keys.Q) && ability1 != null)
            {
                ability1.Use();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.U))
            {
                ability2.Use();
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
                inAir = false;
            }

            if (otherObject is Chain && isJumping is false || (otherObject is Chain && Keyboard.GetState().IsKeyDown(Keys.W) && chainJumpTimer > 0.3f))
            {
                climb = true;
                Gravity = false;
                isJumping = false;
                jumpForce = jumpPower;
                if (chainJumpTimer > 0.7f)
                {
                    canJump = true;
                }
                else
                {
                    canJump = false;
                }
                
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
                        if (knockback)
                        {
                            position.X -= (float)collisionMovement;
                        }
                   
                    }
                    else if (leftLine.Intersects(otherObject.CollisionBox))
                    {
                        Gravity = true;
                        position.X += (float)collisionMovement;
                        if (knockback)
                        {
                            position.X += (float)collisionMovement;
                        }
                    }

                    if (topLine.Intersects(otherObject.CollisionBox))
                    {
                        // Used to prevent the player from going into a platform on the top of a chain
                        if (Gravity is false)
                        {
                            position.Y += (float)(0.7f * collisionMovement);
                        }

                    if (chainJumpTimer < 0.7f)
                    {
                        position.Y += (float)collisionMovement;
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
                    // Makes the player get ontop of the platform and not halfway inside like in the begining, this also fixed collsion bug
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
                knockback = true;
                knockbackDistance = 1.4f;
                if (otherObject.position.X > position.X)
                {
                    hit = true;
                }
                else
                {
                    hit = false;
                }
            }

            if (otherObject is Lava && isImmortal == false)
            {
                health -= 10;
                isImmortal = true;
            }

            if ((otherObject is Portal && Keyboard.GetState().IsKeyDown(Keys.E) && GameWorld.teleport == false) && newLevelTimer > 1)
            {
                nextLevel = true;
                newLevelTimer = 0;
            }

        }

        /// <summary>
        /// Overridden Draw Method that handles the current drawn out sprite of the Player GameObject.
        /// The color of the current sprite is drawn out in red, while the value of isImmortal is set to true, and is otherwise drawn out in default (Color.White).
        /// Also checks wether or not the Player sprite is facing to the right / rotated when drawn.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (isImmortal == true && facingRight == false)
            {

                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.Red, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.FlipHorizontally, 1f);

            }

            if (isImmortal == true && facingRight == true)
            {

                spriteBatch.Draw(sprite, position, animationRectangles[currentAnimationIndex], Color.Red, rotation, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 1f);

            }
        }

        /// <summary>
        /// Collisionbox override, the player needed a fixed collisionbox size else there were collision bugs
        /// </summary>
        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)(position.X - 75 * 0.5), (int)(position.Y - 230 * 0.5), 75, 230);
            }
        }
    }
}
     
    

