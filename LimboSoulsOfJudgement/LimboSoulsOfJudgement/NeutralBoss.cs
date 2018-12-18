using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class NeutralBoss : Enemy
    {

        public NeutralBoss() : base(5, 5, new Vector2(GameWorld.ScreenSize.Width, 2 * 64), "PlayerIdle")
        {
            movementSpeed = 300;
            health = (int)(200 * GameWorld.levelCount);
            maxHealth = health;
            enemyDamage = (int)(20 * GameWorld.levelCount);
            enemySouls = (int)(20 * GameWorld.levelCount);
            soulCount = 20;
            patrolDuration = 2f;
            knockbackDuration = 0.4f;
        }

        public override void Update(GameTime gameTime)
        {
            if (isJumping)
            {
                State(3, "PlayerJump");
            }
            if (aggro)
            {
                State(4, "PlayerRun");
            }
            else
            {
                State(5, "PlayerIdle");
            }

            if (health <= 0)
            {
                GameWorld.vendor.Position = new Vector2(30 * 64, 28 * 64);
                GameWorld.ui.Position = new Vector2(GameWorld.vendor.Position.X, GameWorld.vendor.Position.Y + 120);

                GameWorld.upgradeCritDamageBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y - 175);
                GameWorld.upgradeCritChanceBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y - 50);
                GameWorld.upgradeHealthBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 75);
                GameWorld.upgradeHealthRegenBtn.Position = new Vector2(GameWorld.ui.Position.X - 475, GameWorld.ui.Position.Y + 162);
                GameWorld.upgradeLifestealBtn.Position = new Vector2(GameWorld.ui.Position.X + 300, GameWorld.ui.Position.Y + 25);
                GameWorld.upgradeMovementSpeedBtn.Position = new Vector2(GameWorld.ui.Position.X - 200, GameWorld.ui.Position.Y + 165);
                GameWorld.upgradeMeleeDamageBtn.Position = new Vector2(GameWorld.ui.Position.X + 350, GameWorld.ui.Position.Y + 165);
                GameWorld.upgradeRangedDamageBtn.Position = new Vector2(GameWorld.ui.Position.X + 165, GameWorld.ui.Position.Y + 165);
                GameWorld.resetButton.Position = new Vector2(GameWorld.ui.Position.X - -515, GameWorld.ui.Position.Y + 150);
                GameWorld.goodWeaponBtn.Position = new Vector2(GameWorld.ui.Position.X - 525, GameWorld.ui.Position.Y - 100);
                GameWorld.goodKarmaButton.Position = new Vector2(GameWorld.ui.Position.X - 475, GameWorld.ui.Position.Y - 218);
                GameWorld.evilWeaponBtn.Position = new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 105);
                GameWorld.buyLightningBoltButton.Position = new Vector2(GameWorld.ui.Position.X - 225, GameWorld.ui.Position.Y - 100);
                GameWorld.buyBloodStormButton.Position = new Vector2(GameWorld.ui.Position.X + 245, GameWorld.ui.Position.Y - 150);
                GameWorld.badKarmaButton.Position = new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 218);
            }

            HandleMovement(gameTime);
            HandleJumping(gameTime);
            // if player is on a chain and the enemy is aggro'ed, jump after the player and set goVertically to true
            if (GameWorld.player.climb is true && aggro is true)
            {
                if (GameWorld.player.Position.Y < position.Y && Math.Abs(position.X - GameWorld.player.Position.X) < 80)
                {
                    isJumping = true;
                }
                goVertically = true;
            }
            else
            {
                goVertically = false;
            }

            collisionMovement = movementSpeed * gameTime.ElapsedGameTime.TotalSeconds;

            knockbackMovement = (float)(knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            if (knockback)
            {
                knockbackTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (GameWorld.player.Position.X < position.X)
                {
                    isJumping = true;
                    position.X += (float)(knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (GameWorld.player.Position.X > position.X)
                {
                    isJumping = true;
                    position.X -= (float)(knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (knockbackTime > knockbackDuration)
                {
                    knockback = false;
                    knockbackTime = 0;
                }

            }

            if (health <= 0)
            {
                GameWorld.vendor.Position = new Vector2(30 * 64, 28 * 64);
                GameWorld.ui.Position = new Vector2(GameWorld.vendor.Position.X, GameWorld.vendor.Position.Y + 120);

                GameWorld.upgradeCritDamageBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y - 175);
                GameWorld.upgradeCritChanceBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y - 50);
                GameWorld.upgradeHealthBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 75);
                GameWorld.upgradeHealthRegenBtn.Position = new Vector2(GameWorld.ui.Position.X - 475, GameWorld.ui.Position.Y + 162);
                GameWorld.upgradeLifestealBtn.Position = new Vector2(GameWorld.ui.Position.X + 300, GameWorld.ui.Position.Y + 25);
                GameWorld.upgradeMovementSpeedBtn.Position = new Vector2(GameWorld.ui.Position.X - 200, GameWorld.ui.Position.Y + 165);
                GameWorld.upgradeMeleeDamageBtn.Position = new Vector2(GameWorld.ui.Position.X + 350, GameWorld.ui.Position.Y + 165);
                GameWorld.upgradeRangedDamageBtn.Position = new Vector2(GameWorld.ui.Position.X + 165, GameWorld.ui.Position.Y + 165);
                GameWorld.resetButton.Position = new Vector2(GameWorld.ui.Position.X - -515, GameWorld.ui.Position.Y + 150);
                GameWorld.goodWeaponBtn.Position = new Vector2(GameWorld.ui.Position.X - 525, GameWorld.ui.Position.Y - 100);
                GameWorld.goodKarmaButton.Position = new Vector2(GameWorld.ui.Position.X - 475, GameWorld.ui.Position.Y - 218);
                GameWorld.evilWeaponBtn.Position = new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 105);
                GameWorld.buyLightningBoltButton.Position = new Vector2(GameWorld.ui.Position.X - 225, GameWorld.ui.Position.Y - 100);
                GameWorld.buyBloodStormButton.Position = new Vector2(GameWorld.ui.Position.X + 245, GameWorld.ui.Position.Y - 150);
                GameWorld.badKarmaButton.Position = new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 218);
            }
            base.Update(gameTime);
        }

        protected override void HandleMovement(GameTime gameTime)
        {
            aggro = true;
            base.HandleMovement(gameTime);
        }

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

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);
            Rectangle topLine = new Rectangle(CollisionBox.X + 8, CollisionBox.Y, CollisionBox.Width - 16, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X + 10, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width - 20, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y + 15, 1, CollisionBox.Height - 30);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y + 15, 1, CollisionBox.Height - 30);

            if (otherObject is Platform)
            {

                if (rightLine.Intersects(otherObject.CollisionBox))
                {
                    if (CollisionBox.Intersects(GameWorld.player.CollisionBox) is false)
                    {
                        isJumping = true;
                    }
                    position.X -= (float)collisionMovement;
                    Gravity = true;

                    if (knockback == true)
                    {
                        position.X -= (float)knockbackMovement;
                    }
                }

                if (leftLine.Intersects(otherObject.CollisionBox))
                {
                    if (CollisionBox.Intersects(GameWorld.player.CollisionBox) is false)
                    {
                        isJumping = true;
                    }
                    position.X += (float)collisionMovement;
                    Gravity = true;

                    if (knockback == true)
                    {
                        position.X += (float)knockbackMovement;
                    }
                }

                //if (bottomLine.Intersects(otherObject.CollisionBox) && Gravity is true)
                //{
                //    position.Y -= GameWorld.gravityStrength;
                //    gravity = false;

                //}

                if (bottomLine.Intersects(otherObject.CollisionBox))
                {
                    jumpForce = jumpPower;
                    canJump = true;
                }

                if (topLine.Intersects(otherObject.CollisionBox))
                {
                    jumpForce = 0;
                    Gravity = true;
                    goVertically = false;
                }

                if (bottomLine.Intersects(otherObject.CollisionBox) && (leftLine.Intersects(otherObject.CollisionBox) is false || (rightLine.Intersects(otherObject.CollisionBox) is false)))
                {
                    // Makes the enemy get ontop of the platform and not halfway inside like in the begining, this also fixed collsion bug
                    while (CollisionBox.Intersects(otherObject.CollisionBox))
                    {
                        position.Y -= 1;
                    }
                    position.Y += 1;

                }
            }

            //if the enemy is on a chain and goVertically is true, climb after the player
            if (otherObject is Chain && goVertically is true)
            {
                if (position.Y > GameWorld.player.Position.Y)
                {
                    position.Y -= (float)(0.5 * collisionMovement);
                }
                if (position.Y < GameWorld.player.Position.Y)
                {
                    position.Y += (float)(0.5 * collisionMovement);
                }
                Gravity = false;
                jumpForce = 0;
            }
        }
    }
}
