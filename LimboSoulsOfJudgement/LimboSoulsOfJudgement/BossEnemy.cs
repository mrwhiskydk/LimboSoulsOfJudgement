using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class BossEnemy : Enemy
    {
        private bool battleMode = true;
        private bool charge;
        private double abilityTime;
        private float abilityDuration = 2f;
        private double battleModeTime;
        private bool bossTeleport = false;
        private float bossSlow = 0.5f;

        /// <summary>
        /// BossEnemy constructor that sets animation values, position and sprite names of current BossEnemy GameObject
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public BossEnemy(int animationFPS, float frameCount,string spriteName) : base(animationFPS, frameCount, new Vector2(300, 1000), spriteName)
        {
            movementSpeed = 300;
            health = (int)(125 * (GameWorld.levelCount + 0.5));
            maxHealth = health;
            enemyDamage = (int)(20 * (GameWorld.levelCount));
            enemySouls = (int)(20 * GameWorld.levelCount);
            soulCount = 20;
            knockbackDuration = 0.4f;
        }


        /// <summary>
        /// Method that updates game logic of the current BossEnemy GameObject
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleMovement(gameTime);
            knockbackMovement = (float)(knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            if (knockback)
            {
                knockbackTime += gameTime.ElapsedGameTime.TotalSeconds;

                if (GameWorld.player.Position.X < position.X)
                {
                    position.X += (float)(0.7*knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (GameWorld.player.Position.X > position.X)
                {
                    position.X -= (float)(0.7*knockbackDistance * movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
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
                GameWorld.upgradeCritDamageBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y - 218);
                GameWorld.upgradeCritChanceBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y - 100);
                GameWorld.upgradeHealthBtn.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 10);
                GameWorld.upgradeHealthRegenBtn.Position = new Vector2(GameWorld.ui.Position.X - 500, GameWorld.ui.Position.Y + 165);
                GameWorld.upgradeLifestealBtn.Position = new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y + 165);
                GameWorld.upgradeMovementSpeedBtn.Position = new Vector2(GameWorld.ui.Position.X - 250, GameWorld.ui.Position.Y + 165);
                GameWorld.upgradeMeleeDamageBtn.Position = new Vector2(GameWorld.ui.Position.X + 85, GameWorld.ui.Position.Y + 135);
                GameWorld.upgradeRangedDamageBtn.Position = new Vector2(GameWorld.ui.Position.X - 75, GameWorld.ui.Position.Y + 135);
                GameWorld.resetButton.Position = new Vector2(GameWorld.ui.Position.X + 245, GameWorld.ui.Position.Y + 165);
                GameWorld.goodWeaponBtn.Position = new Vector2(GameWorld.ui.Position.X - 500, GameWorld.ui.Position.Y - 25);
                GameWorld.goodKarmaButton.Position = new Vector2(GameWorld.ui.Position.X - 500, GameWorld.ui.Position.Y - 218);
                GameWorld.evilWeaponBtn.Position = new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 25);
                GameWorld.buyLightningBoltButton.Position = new Vector2(GameWorld.ui.Position.X - 250, GameWorld.ui.Position.Y - 218);
                GameWorld.buyBloodStormButton.Position = new Vector2(GameWorld.ui.Position.X + 245, GameWorld.ui.Position.Y - 218);
                GameWorld.badKarmaButton.Position = new Vector2(GameWorld.ui.Position.X + 475, GameWorld.ui.Position.Y - 218);
                GameWorld.finalBossButton.Position = new Vector2(GameWorld.ui.Position.X, GameWorld.ui.Position.Y + 225);
                GameWorld.buyGodModeAbility.Position = new Vector2(GameWorld.ui.Position.X + 245, GameWorld.ui.Position.Y - 25);
                GameWorld.upgradeAbilityDamageBtn.Position = new Vector2(GameWorld.ui.Position.X - 250, GameWorld.ui.Position.Y - 25);
            }


            battleModeTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (battleModeTime > 12)
            {
                battleMode = false;
            }

            if (charge == true)
            {
                movementSpeed = 750;
                bossSlow = 1;
            }
            else if (charge == false)
            {
                movementSpeed = 300;
                bossSlow = 0.5f;
            }

        }


        protected override void HandleMovement(GameTime gameTime)
        {

            Gravity = false;
            if (battleMode is true)
            {
                if (GameWorld.player.Position.Y < position.Y)
                {
                    position.Y -= (float)((movementSpeed * bossSlow) * gameTime.ElapsedGameTime.TotalSeconds);
                }

                if (GameWorld.player.Position.Y > position.Y)
                {
                    position.Y += (float)((movementSpeed * bossSlow) * gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (GameWorld.player.Position.X < position.X)
                {
                    facingRight = true;
                    position.X -= (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (GameWorld.player.Position.X > position.X)
                {
                    facingRight = false;
                    position.X += (float)(movementSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                }
                abilityTime = 0;

            }
            if (battleMode is false)
            {        
                if (GameWorld.rnd.Next(1, 4) == 2 && bossTeleport == false)
                {
                    Position = new Vector2(2 * 128, 2 * 128);
                    bossTeleport = true;
                }
                else if (GameWorld.rnd.Next(1, 4) == 3 && bossTeleport == false)
                {
                    Position = new Vector2(27 * 128, 2 * 128);
                    bossTeleport = true;
                }

                abilityTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (abilityTime > abilityDuration)
                {
                    charge = true;
                    battleMode = true;
                    battleModeTime = 0;
                }


            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is Weapon || otherObject is Projectile)
            {
                battleMode = true;
                charge = false;
                bossTeleport = false;
            }
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}
