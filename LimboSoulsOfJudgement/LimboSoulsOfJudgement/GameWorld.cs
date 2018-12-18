﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        private SpriteBatch spriteBatch;
        public static List<GameObject> gameObjects = new List<GameObject>();
        private static List<GameObject> toBeAdded = new List<GameObject>();
        private static List<GameObject> toBeRemoved = new List<GameObject>();
        public static List<GameObjectPassive> gameObjectsPassive = new List<GameObjectPassive>();
        private static List<GameObjectPassive> toBeAddedPassive = new List<GameObjectPassive>();
        private static List<GameObjectPassive> toBeRemovedPassive = new List<GameObjectPassive>();
        public static UIAbilityBar uiAbilityBar;
        public static Player player;
        private Texture2D collisionTexture;
        private Texture2D loseScreen;
        private double gameCooldown;
        public static Camera camera;
        public static SpriteFont font;
        public static Vendor vendor;
        public static UI ui;
        public static SpriteFont damageFont;
        public static Song musicMain;
        public static Song musicBoss;
        
        //Button Fields below
        public static Button button;
        public static BadKarmaButton badKarmaButton;
        public static UpgradeHealthBtn upgradeHealthBtn;
        public static float levelCount = 1;
        public static bool levelReset = false;
        public bool playerAlive;
        public static GoodKarmaButton goodKarmaButton;
        public static EvilWeaponBtn evilWeaponBtn;
        public static GoodWeaponBtn goodWeaponBtn;
        public static ResetButton resetButton;
        public static UpgradeHealthRegenBtn upgradeHealthRegenBtn;
        public static UpgradeLifetealBtn upgradeLifestealBtn;
        public static UpgradeCritChanceBtn upgradeCritChanceBtn;
        public static UpgradeCritDamageBtn upgradeCritDamageBtn;
        public static UpgradeMeleeDamageBtn upgradeMeleeDamageBtn;
        public static UpgradeRangedDamageBtn upgradeRangedDamageBtn;
        public static UpgradeMovementSpeedBtn upgradeMovementSpeedBtn;
        public static BuyLightningBoltButton buyLightningBoltButton;
        public static BuyBloodStormButton buyBloodStormButton;
        public static FinalBossButton finalBossButton;
        public static bool triggerFinalBoss = false;

        // Healthbar
        public static HealthBar healthBar;
        public static Texture2D healthBarOutline;

        // KarmaBar
        public static KarmaBar karmaBar;
        public static Texture2D karmaBarOutline;

        public static int levelCounter = 1;
        public static int stage = 1;
        public static bool teleport = false;
        public static Level level;
        public static bool addLevel = true;

        public static Random rnd = new Random();
        public static Crosshair mouse;
        private Texture2D backGround;
        private Texture2D shadow;
        private Texture2D evilAura;
        private Texture2D goodAura;
        private static GraphicsDeviceManager graphics;

        //Insert GameWorld fields below
        public static float gravityStrength = 12f;
        public static bool triggerVendor = false;
        //Fields below is used for Fade in and out Image
        //private int alphaValue = 0;
        //private static int fadeIncrease = 3;
        //private double fadeDelay = 0;    //default is .010;

        public static Rectangle ScreenSize
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Bounds;
            }
        }

        private static ContentManager _content;
        public static ContentManager ContentManager
        {
            get
            {
                return _content;
            }
        }



        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 900;   // set this value to the desired height of your window
            //graphics.ToggleFullScreen();
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            _content = Content;

        }

        public static void AddGameObject(GameObject go)
        {
            toBeAdded.Add(go);
        }

        public static void RemoveGameObject(GameObject go)
        {
            toBeRemoved.Add(go);
        }

        public static void AddGameObjectPassive(GameObjectPassive go)
        {
            toBeAddedPassive.Add(go);
        }

        public static void RemoveGameObjectPassive(GameObjectPassive go)
        {
            toBeRemovedPassive.Add(go);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("ExampleFont");
            backGround = Content.Load<Texture2D>("GreyBackground");
            shadow = Content.Load<Texture2D>("Darkness");
            evilAura = Content.Load<Texture2D>("EvilAura");
            goodAura = Content.Load<Texture2D>("GoodAura");
            collisionTexture = Content.Load<Texture2D>("CollisionTexture");
            damageFont = Content.Load<SpriteFont>("DamageFont");
            loseScreen = Content.Load<Texture2D>("GameOver");

            //Sound
            MediaPlayer.Volume = 0.05f;
            MediaPlayer.IsRepeating = true;
            musicMain = Content.Load<Song>("sound/musicmain");
            musicBoss = Content.Load<Song>("sound/musicboss");
            MediaPlayer.Play(musicMain);


            //Load Vendor & Vendor UI
            vendor = new Vendor();
            uiAbilityBar = new UIAbilityBar();
            player = new Player();
            camera = new Camera();
            ui = new UI();
            

            
            badKarmaButton = new BadKarmaButton();
            upgradeHealthBtn = new UpgradeHealthBtn();
            goodKarmaButton = new GoodKarmaButton();
            evilWeaponBtn = new EvilWeaponBtn();
            goodWeaponBtn = new GoodWeaponBtn();
            resetButton = new ResetButton();
            upgradeHealthRegenBtn = new UpgradeHealthRegenBtn();
            upgradeLifestealBtn = new UpgradeLifetealBtn();
            upgradeCritChanceBtn = new UpgradeCritChanceBtn();
            upgradeCritDamageBtn = new UpgradeCritDamageBtn();
            upgradeMeleeDamageBtn = new UpgradeMeleeDamageBtn();
            upgradeRangedDamageBtn = new UpgradeRangedDamageBtn();
            upgradeMovementSpeedBtn = new UpgradeMovementSpeedBtn();
            buyLightningBoltButton = new BuyLightningBoltButton();
            buyBloodStormButton = new BuyBloodStormButton();
            finalBossButton = new FinalBossButton();
            

            // Healthbar
            healthBar = new HealthBar(Vector2.Zero);
            healthBar.healthBarTexture = Content.Load<Texture2D>("healthbar");
            healthBarOutline = Content.Load<Texture2D>("healthBarOutline");

            //karmabar
            karmaBar = new KarmaBar(Vector2.Zero);
            karmaBar.karmaBarTexture = Content.Load<Texture2D>("karmaBar");
            karmaBarOutline = Content.Load<Texture2D>("karmaBarOutline");


            mouse = new Crosshair();

            
        }



        //go = new AnimatedGameObject(4,20,Content,"HeroStrip");

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (teleport == true)
            {
                levelReset = true;
                addLevel = true;
                teleport = false;
                level.levelLoaded = false;
            }
            if (player.playerLives > 0)
            {
                playerAlive = true;
            }
            else if (playerAlive is false)
            {
                stage = 1;
                foreach (var item in gameObjects)
                {
                    item.Destroy();
                }
                gameCooldown += gameTime.ElapsedGameTime.TotalSeconds;
                if (gameCooldown > 3)
                {
                    levelReset = false;
                    addLevel = true;
                    vendor = new Vendor();
                    player = new Player();
                    ui = new UI();
                    badKarmaButton = new BadKarmaButton();
                    upgradeHealthBtn = new UpgradeHealthBtn();
                    goodKarmaButton = new GoodKarmaButton();
                    evilWeaponBtn = new EvilWeaponBtn();
                    goodWeaponBtn = new GoodWeaponBtn();
                    mouse = new Crosshair();
                    playerAlive = true;
                }
            }

            if (player.health <= 0)
            {
                levelReset = true;
                addLevel = true;
                player.playerLives -= 1;
            }

            if (player.playerLives == 0)
            {
                playerAlive = false;
            }

            foreach (GameObject go in gameObjects)
            {
                //Applies gravity to GameObject
                if (go.Gravity)
                {
                    go.Position = new Vector2(go.Position.X, go.Position.Y + gravityStrength);
                }

                go.Update(gameTime);
                
                foreach (GameObject other in gameObjects)
                {
                    if (go != other && go.IsColliding(other))
                    {
                        go.DoCollision(other);
                    }
                }
            }
            if (levelReset == false && addLevel == true)
            {
                level = new Level();
                addLevel = false;

            }
            else if (levelReset == true)
            {
                foreach (var item in gameObjects)
                {
                    if (item is Player is false && item is Vendor is false && item is Crosshair is false && item is UI is false && item is Button is false && item is Weapon is false && item is Arm is false)
                    {
                        item.Destroy();
                    }
                }
                levelReset = false;

                player.health = player.MaxHealth;
                if (stage == 1)
                {
                    player.Position = new Vector2(200, 500);
                }
                else if (stage == 2)
                {
                    player.Position = new Vector2(5 * 64, 55 * 64);
                }
                else if (stage == 10)
                {
                    player.Position = new Vector2(30 * 64, 27 * 64);
                }
                else if (stage == 3)
                {
                    player.Position = new Vector2(4 * 64, 8 * 64);
                }

            }

            //manually updating classes with important order
            camera.Position = new Vector2(MathHelper.Lerp(camera.Position.X, player.Position.X, 0.25f), MathHelper.Lerp(camera.Position.Y, player.Position.Y, 0.25f));
            mouse.Update(gameTime);

            foreach (GameObjectPassive go in gameObjectsPassive)
            {
                go.Update(gameTime);
            }

            
            foreach (GameObject go in toBeRemoved)
            {
                gameObjects.Remove(go);
            }
            toBeRemoved.Clear();

            gameObjects.AddRange(toBeAdded);
            toBeAdded.Clear();



            foreach (GameObjectPassive go in toBeRemovedPassive)
            {
                gameObjectsPassive.Remove(go);
            }
            toBeRemovedPassive.Clear();

            gameObjectsPassive.AddRange(toBeAddedPassive);
            toBeAddedPassive.Clear();





            //if (level1.boss.enemyHealth <= 0)
            //{
            //    vendor.Position = new Vector2(5300, 3328);
            //}

            if (stage == 2 && level.levelLoaded == true)
            {
                level.movingLava.position.Y -= (float)(30 * gameTime.ElapsedGameTime.TotalSeconds);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, camera.viewMatrix);
            spriteBatch.Draw(backGround, new Vector2(camera.Position.X - ScreenSize.Width * 0.5f, camera.Position.Y - ScreenSize.Height * 0.5f), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.01f);
            spriteBatch.Draw(shadow, new Vector2(camera.Position.X - ScreenSize.Width * 0.5f, camera.Position.Y - ScreenSize.Height * 0.5f), null, Color.White, 0f, new Vector2(160, 80), 1f, SpriteEffects.None, 0.99f);

            if ((badKarmaButton.currentStatValue / badKarmaButton.maxStatValue) * 100 > 80 && badKarmaButton.currentStatValue > goodKarmaButton.currentStatValue)
            {
                spriteBatch.Draw(evilAura, new Vector2(camera.Position.X - ScreenSize.Width * 0.5f, camera.Position.Y - ScreenSize.Height * 0.5f), null, Color.White, 0f, new Vector2(160, 80), 1f, SpriteEffects.None, 0.02f);
            }

            if ((goodKarmaButton.currentStatValue / goodKarmaButton.maxStatValue) * 100 > 80 && badKarmaButton.currentStatValue < goodKarmaButton.currentStatValue)
            {
                spriteBatch.Draw(goodAura, new Vector2(camera.Position.X - ScreenSize.Width * 0.5f, camera.Position.Y - ScreenSize.Height * 0.5f), null, Color.White, 0f, new Vector2(160, 80), 1f, SpriteEffects.None, 0.02f);
            }

            if (playerAlive == false)
            {
                spriteBatch.Draw(loseScreen, new Vector2(camera.Position.X - ScreenSize.Width * 0.5f, camera.Position.Y - ScreenSize.Height * 0.5f), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            }

            foreach (GameObject go in gameObjects)
            {
                go.Draw(spriteBatch);

#if DEBUG
                DrawCollisionBox(go);
#endif
            }

            //Manually drawing classes with important order
            mouse.Draw(spriteBatch);

            foreach (GameObjectPassive go in gameObjectsPassive)
            {
                go.Draw(spriteBatch);
            }

            if (stage != 10 && level.portal != null)
            {
                spriteBatch.DrawString(font, "Press E", new Vector2(level.portal.Position.X - 30, level.portal.Position.Y - 100), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            }

            spriteBatch.DrawString(font, $"Souls: {player.currentSouls}", new Vector2(camera.Position.X - 750, camera.Position.Y - 425), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Melee Weapon Damage: {player.melee.damage}", new Vector2(camera.Position.X - 750, camera.Position.Y - 350), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Ranged Weapon Damage: {player.ranged.damage}", new Vector2(camera.Position.X - 750, camera.Position.Y - 325), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Health: {player.health} / {player.maxHealth}", new Vector2(healthBar.Position.X, healthBar.Position.Y), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.993f);
            spriteBatch.DrawString(font, $"Lives: {player.playerLives}", new Vector2(camera.Position.X - 750, camera.Position.Y - 375), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Coordinates: X: {Mouse.GetState().X - camera.viewMatrix.Translation.X}   Y: {Mouse.GetState().Y - camera.viewMatrix.Translation.Y}", new Vector2(camera.Position.X, camera.Position.Y - 500), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Press E to interact", new Vector2(vendor.Position.X - 60, vendor.Position.Y - 120), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Health regen: {player.healthRegen.ToString("0.00")}", new Vector2(camera.Position.X - 750, camera.Position.Y - 300), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Crit Chance: {player.critChance * 100f}%", new Vector2(camera.Position.X - 750, camera.Position.Y - 275), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Crit Damage: {player.critDmgModifier * 100f}%", new Vector2(camera.Position.X - 750, camera.Position.Y - 250), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Level: {levelCounter}", new Vector2(camera.Position.X + 720, camera.Position.Y - 430), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);

            //Text of current Button Stat Cost
            if (triggerVendor)
            {
                spriteBatch.DrawString(font, $"Soul Cost: {upgradeHealthBtn.statCost}", new Vector2(upgradeHealthBtn.Position.X - 50, upgradeHealthBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Soul Cost: {upgradeHealthRegenBtn.statCost}", new Vector2(upgradeHealthRegenBtn.Position.X - 50, upgradeHealthRegenBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Soul Cost: {upgradeLifestealBtn.statCost}", new Vector2(upgradeLifestealBtn.Position.X - 50, upgradeLifestealBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Soul Cost: {upgradeCritChanceBtn.statCost}", new Vector2(upgradeCritChanceBtn.Position.X - 50, upgradeCritChanceBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Soul Cost: {upgradeCritDamageBtn.statCost}", new Vector2(upgradeCritDamageBtn.Position.X - 50, upgradeCritDamageBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Soul Cost: {goodKarmaButton.statCost}", new Vector2(goodKarmaButton.Position.X - 50, goodKarmaButton.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Soul Cost: {badKarmaButton.statCost}", new Vector2(badKarmaButton.Position.X - 50, badKarmaButton.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Soul Cost: {upgradeMeleeDamageBtn.statCost}", new Vector2(upgradeMeleeDamageBtn.Position.X - 50, upgradeMeleeDamageBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Soul Cost: {upgradeMovementSpeedBtn.statCost}", new Vector2(upgradeMovementSpeedBtn.Position.X - 50, upgradeMovementSpeedBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);

                //Cost and Karma Required Text of Good Weapon
                spriteBatch.DrawString(font, $"Soul Cost: {goodWeaponBtn.statCost}", new Vector2(goodWeaponBtn.Position.X - 50, goodWeaponBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Angel Karma Required: {goodWeaponBtn.karmaRequirements}", new Vector2(goodWeaponBtn.Position.X - 50, goodWeaponBtn.Position.Y + 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                //Cost and Karma Required Text of Good/Lightning Bolt Ability
                spriteBatch.DrawString(font, $"Soul Cost: {buyLightningBoltButton.statCost}", new Vector2(buyLightningBoltButton.Position.X - 50, buyLightningBoltButton.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Angel Karma Required: {buyLightningBoltButton.karmaRequirements}", new Vector2(buyLightningBoltButton.Position.X - 80, buyLightningBoltButton.Position.Y + 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                //Karma Required Text of HealthRegen Stat
                spriteBatch.DrawString(font, $"Angel Karma Required: {upgradeHealthRegenBtn.karmaRequirements}", new Vector2(upgradeHealthRegenBtn.Position.X - 80, upgradeHealthRegenBtn.Position.Y + 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                //Cost and Karma Reuquired Text of Evil Weapon
                spriteBatch.DrawString(font, $"Soul Cost: {evilWeaponBtn.statCost}", new Vector2(evilWeaponBtn.Position.X - 50, evilWeaponBtn.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Demonic Karma Required: {evilWeaponBtn.karmaRequirements}", new Vector2(evilWeaponBtn.Position.X - 50, evilWeaponBtn.Position.Y + 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                //Cost and Karma Required Text of Evil/Blood Storm Ability
                spriteBatch.DrawString(font, $"Soul Cost: {buyBloodStormButton.statCost}", new Vector2(buyBloodStormButton.Position.X - 50, buyBloodStormButton.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                spriteBatch.DrawString(font, $"Demonic Karma Required: {buyBloodStormButton.karmaRequirements}", new Vector2(buyBloodStormButton.Position.X - 80, buyBloodStormButton.Position.Y + 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
                //Karma Required Text of Lifesteal Stat
                spriteBatch.DrawString(font, $"Angel Karma Required: {upgradeLifestealBtn.karmaRequirements}", new Vector2(upgradeLifestealBtn.Position.X - 80, upgradeLifestealBtn.Position.Y + 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }


            if (triggerVendor && badKarmaButton.maxStatValue <= badKarmaButton.currentStatValue)
            {
                spriteBatch.DrawString(font, "MAX BAD KARMA!", new Vector2(badKarmaButton.Position.X - 70, badKarmaButton.Position.Y + -55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Bad Karma
            else if (triggerVendor && badKarmaButton.maxStatValue >= badKarmaButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"Demonic Karma Value: {badKarmaButton.currentStatValue} / {badKarmaButton.maxStatValue}", new Vector2(badKarmaButton.Position.X - 68, badKarmaButton.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Completed Purchase of Evil Melee Weapon
            if(triggerVendor && evilWeaponBtn.maxStatValue <= evilWeaponBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"EVIL WEAPON PURCHASED", new Vector2(evilWeaponBtn.Position.X - 62, evilWeaponBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Evil Melee Weapon
            else if(triggerVendor && evilWeaponBtn.maxStatValue >= evilWeaponBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"BUY EVIL MELEE WEAPON", new Vector2(evilWeaponBtn.Position.X - 62, evilWeaponBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Completed Purchase of Good Melee Weapon
            if(triggerVendor && goodWeaponBtn.maxStatValue <= goodWeaponBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"GOOD WEAPON PURCHASED", new Vector2(goodWeaponBtn.Position.X - 52, goodWeaponBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Good Melee Weapon
            else if (triggerVendor && goodWeaponBtn.maxStatValue >= goodWeaponBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"BUY GOOD MELEE WEAPON", new Vector2(goodWeaponBtn.Position.X - 85, goodWeaponBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Completed Purchase of Good Ability: Lightning Bolt
            if (triggerVendor && buyLightningBoltButton.maxStatValue <= buyLightningBoltButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"LIGHTNING BOLT PURCHASED", new Vector2(buyLightningBoltButton.Position.X - 92, buyLightningBoltButton.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Good Ability: Lightning Bolt
            else if (triggerVendor && buyLightningBoltButton.maxStatValue >= buyLightningBoltButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"BUY LIGHTNING BOLT", new Vector2(buyLightningBoltButton.Position.X - 85, buyLightningBoltButton.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Completed Purchase of Evil Ability: Blood Storm
            if (triggerVendor && buyBloodStormButton.maxStatValue <= buyBloodStormButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"BLOODSTORM PURCHASED", new Vector2(buyBloodStormButton.Position.X - 92, buyBloodStormButton.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Evil Ability: Blood Storm
            else if (triggerVendor && buyBloodStormButton.maxStatValue >= buyBloodStormButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"BUY BLOODSTORM", new Vector2(buyBloodStormButton.Position.X - 85, buyBloodStormButton.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Completed Purchase of Good Karma
            if (triggerVendor && goodKarmaButton.maxStatValue <= goodKarmaButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"MAX GOOD KARMA!", new Vector2(goodKarmaButton.Position.X - 114, goodKarmaButton.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Good Karma
            else if (triggerVendor && goodKarmaButton.maxStatValue >= goodKarmaButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"Angel Karma Value: {goodKarmaButton.maxStatValue} / {goodKarmaButton.currentStatValue}", new Vector2(goodKarmaButton.Position.X - 114, goodKarmaButton.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase Max Player Health
            if(triggerVendor && upgradeHealthBtn.maxStatValue >= upgradeHealthBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"Player Health Value: {upgradeHealthBtn.currentStatValue} / {upgradeHealthBtn.maxStatValue}", new Vector2(upgradeHealthBtn.Position.X - 134, upgradeHealthBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Completed of Purchase Life Steal
            if (triggerVendor && upgradeLifestealBtn.maxFloatStatValue <= upgradeLifestealBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"LifeSteal: {upgradeLifestealBtn.currentFloatStatValue.ToString("0.00")}% / {upgradeLifestealBtn.maxFloatStatValue.ToString("0.00")}%", new Vector2(upgradeLifestealBtn.Position.X - 68, upgradeLifestealBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text of Purchase Life Steal
            if (triggerVendor && upgradeLifestealBtn.maxFloatStatValue >= upgradeLifestealBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"LifeSteal: {upgradeLifestealBtn.currentFloatStatValue.ToString("0.00")}% / {upgradeLifestealBtn.maxFloatStatValue.ToString("0.00")}%", new Vector2(upgradeLifestealBtn.Position.X - 68, upgradeLifestealBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Completed of Purchase Health Regen
            if (triggerVendor && upgradeHealthRegenBtn.maxFloatStatValue <= upgradeHealthRegenBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"Health Regen: {upgradeHealthRegenBtn.currentFloatStatValue.ToString("0.00")} / {upgradeHealthRegenBtn.maxFloatStatValue.ToString("0.00")}", new Vector2(upgradeHealthRegenBtn.Position.X - 68, upgradeHealthRegenBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Upgrade Health Regen,- text of currentRegenStatValue is using 'ToString("0.00")', in order to show a maximum of only 2 decimal numbers.
            else if (triggerVendor && upgradeHealthRegenBtn.maxFloatStatValue >= upgradeHealthRegenBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"Health Regen: {upgradeHealthRegenBtn.currentFloatStatValue.ToString("0.00")} / {upgradeHealthRegenBtn.maxFloatStatValue.ToString("0.00")}", new Vector2(upgradeHealthRegenBtn.Position.X - 68, upgradeHealthRegenBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Completed of Upgrade Crit Chance,- text of currentRegenStatValue is using 'ToString("0.00")', in order to show a maximum of only 2 decimal numbers.
            if (triggerVendor && upgradeCritChanceBtn.maxFloatStatValue <= upgradeCritChanceBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"Crit Chance: {upgradeCritChanceBtn.currentFloatStatValue.ToString("0.00")}% / {upgradeCritChanceBtn.maxFloatStatValue.ToString("0.00")}%", new Vector2(upgradeCritChanceBtn.Position.X - 68, upgradeCritChanceBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Upgrade Crit Chance,- text of currentRegenStatValue is using 'ToString("0.00")', in order to show a maximum of only 2 decimal numbers.
            else if (triggerVendor && upgradeCritChanceBtn.maxFloatStatValue >= upgradeCritChanceBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"Crit Chance: {upgradeCritChanceBtn.currentFloatStatValue * 100f}% / {upgradeCritChanceBtn.maxFloatStatValue * 100f}%", new Vector2(upgradeCritChanceBtn.Position.X - 68, upgradeCritChanceBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Completed of Upgrade Crit Damage,- text of currentRegenStatValue is using 'ToString("0.00")', in order to show a maximum of only 2 decimal numbers.
            if (triggerVendor && upgradeCritDamageBtn.maxFloatStatValue <= upgradeCritDamageBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"Crit Damage: {upgradeCritDamageBtn.currentFloatStatValue * 100f}% / {upgradeCritDamageBtn.maxFloatStatValue * 100f}%", new Vector2(upgradeCritDamageBtn.Position.X - 68, upgradeCritDamageBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Upgrade Crit Damage,- text of currentRegenStatValue is using 'ToString("0.00")', in order to show a maximum of only 2 decimal numbers.
            else if (triggerVendor && upgradeCritDamageBtn.maxFloatStatValue >= upgradeCritDamageBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"Crit Damage: {upgradeCritDamageBtn.currentFloatStatValue * 100f}% / {upgradeCritDamageBtn.maxFloatStatValue * 100f}%", new Vector2(upgradeCritDamageBtn.Position.X - 68, upgradeCritDamageBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Completed of Upgrade Default Melee Damage
            if (triggerVendor && upgradeMeleeDamageBtn.maxStatValue <= upgradeMeleeDamageBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"Melee Damage: {upgradeMeleeDamageBtn.currentStatValue} / {upgradeMeleeDamageBtn.maxStatValue}", new Vector2(upgradeMeleeDamageBtn.Position.X - 68, upgradeMeleeDamageBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Upgrade Default Melee Damage
            else if (triggerVendor && upgradeMeleeDamageBtn.maxStatValue >= upgradeMeleeDamageBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"Melee Damage: {upgradeMeleeDamageBtn.currentStatValue} / {upgradeMeleeDamageBtn.maxStatValue}", new Vector2(upgradeMeleeDamageBtn.Position.X - 68, upgradeMeleeDamageBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Completed of Upgrade Default Ranged Damage
            if (triggerVendor && upgradeRangedDamageBtn.maxStatValue <= upgradeRangedDamageBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"Ranged Damage: {upgradeRangedDamageBtn.currentStatValue} / {upgradeRangedDamageBtn.maxStatValue}", new Vector2(upgradeRangedDamageBtn.Position.X - 68, upgradeRangedDamageBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Upgrade Default Ranged Damage
            else if (triggerVendor && upgradeRangedDamageBtn.maxStatValue >= upgradeRangedDamageBtn.currentStatValue)
            {
                spriteBatch.DrawString(font, $"Ranged Damage: {upgradeRangedDamageBtn.currentStatValue} / {upgradeRangedDamageBtn.maxStatValue}", new Vector2(upgradeRangedDamageBtn.Position.X - 68, upgradeRangedDamageBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Completed of Upgrade Movement Speed
            if (triggerVendor && upgradeMovementSpeedBtn.maxFloatStatValue <= upgradeMovementSpeedBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"Movement Speed: {upgradeMovementSpeedBtn.currentFloatStatValue} / {upgradeMovementSpeedBtn.maxFloatStatValue}", new Vector2(upgradeMovementSpeedBtn.Position.X - 90, upgradeMovementSpeedBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Upgrade MovementSpeed
            else if (triggerVendor && upgradeMovementSpeedBtn.maxFloatStatValue >= upgradeMovementSpeedBtn.currentFloatStatValue)
            {
                spriteBatch.DrawString(font, $"Movement Speed: {upgradeMovementSpeedBtn.currentFloatStatValue} / {upgradeMovementSpeedBtn.maxFloatStatValue}", new Vector2(upgradeMovementSpeedBtn.Position.X - 90, upgradeMovementSpeedBtn.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Description of the Reset Button
            if (triggerVendor)
            {
                spriteBatch.DrawString(font, "RESET LEVEL!", new Vector2(resetButton.Position.X - 60, resetButton.Position.Y - 55), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            //Text Completed Purchase of Final Boss Button
            if (triggerVendor && goodKarmaButton.maxStatValue <= goodKarmaButton.currentStatValue || triggerVendor && badKarmaButton.maxStatValue <= badKarmaButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"CLICK TO ENTER FINAL BOSS ROOM!", new Vector2(finalBossButton.Position.X - 114, finalBossButton.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }
            //Text Purchase of Final Boss Button
            else if (triggerVendor && goodKarmaButton.maxStatValue >= goodKarmaButton.currentStatValue || triggerVendor && badKarmaButton.maxStatValue >= badKarmaButton.currentStatValue)
            {
                spriteBatch.DrawString(font, $"Requires either: MAX Demonic Karma or MAX Angel Karma to unlock!", new Vector2(finalBossButton.Position.X - 214, finalBossButton.Position.Y + 35), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.995f);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawCollisionBox(GameObject go)
        {
            Rectangle collisionBox = go.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
    }
}
