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

            //Weapon setup
            weapon = ranged;
            weapon.equipped = true;
        }

        /// <summary>
        /// Update method that enables Player movement
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            HandleMovement(gameTime);
            HandleWeapons(gameTime);
        }

        /// <summary>
        /// Method that sets the default movement functionality of the Player
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        protected override void HandleMovement(GameTime gameTime)
        {

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
     
    

