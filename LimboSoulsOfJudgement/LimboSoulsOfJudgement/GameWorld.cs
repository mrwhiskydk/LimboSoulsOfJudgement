using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        public static Player player;
        private Texture2D collisionTexture;
        public static Camera camera;
        private SpriteFont font;
        private Vendor vendor;

        private Level level1;

        private Texture2D vendorUI;
        private Texture2D vendorBtn;
        private Rectangle vendorBtnRect;
        private Rectangle vendorUIRect;
        private Vector2 vendorBtnPos;
        private Vector2 vendorUIPosition;
        public static Random rnd = new Random();
        public static Crosshair mouse;
        private Texture2D backGround;
        private Texture2D shadow;
        private Texture2D evilAura;
        private static GraphicsDeviceManager graphics;

        //Insert GameWorld fields below
        public static float gravityStrength = 12f;
        public static bool triggerVendor = false;
        //Fields below is used for Fade in and out Image
        private int alphaValue = 0;
        private static int fadeIncrease = 3;
        private double fadeDelay = 0;    //default is .010;

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
            collisionTexture = Content.Load<Texture2D>("CollisionTexture");
            player = new Player();
            camera = new Camera();


            //Load Vendor & Vendor UI
            vendor = new Vendor(1, 1, new Vector2(400, 430), "VendorTest");
            vendorUI = Content.Load<Texture2D>("VendorUITest");
            vendorBtn = Content.Load<Texture2D>("buttonUITest");

            mouse = new Crosshair();
            camera.Position = player.Position;

            level1 = new Level();
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

            foreach (GameObject go in toBeRemoved)
            {
                gameObjects.Remove(go);
            }
            toBeRemoved.Clear();

            gameObjects.AddRange(toBeAdded);
            toBeAdded.Clear();


            if (triggerVendor)
            {
                alphaValue += fadeIncrease;
                fadeDelay += gameTime.ElapsedGameTime.TotalSeconds;
            }

            //else
            //{
            //    fadeIncrease -= 1;
            //}

            alphaValue += fadeIncrease;

            if (alphaValue >= 255 || alphaValue <= 0)

            //{
            //    fadeIncrease *= -1;
            //}
            

            camera.Position = new Vector2(MathHelper.Lerp(camera.Position.X, player.Position.X, 0.25f), MathHelper.Lerp(camera.Position.Y, player.Position.Y, 0.25f)); 
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null, camera.viewMatrix);
            spriteBatch.Draw(backGround, new Vector2(camera.Position.X - ScreenSize.Width*0.5f, camera.Position.Y - ScreenSize.Height * 0.5f), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.01f);
            spriteBatch.Draw(shadow, new Vector2(camera.Position.X - ScreenSize.Width * 0.5f, camera.Position.Y - ScreenSize.Height * 0.5f), null, Color.White, 0f, new Vector2(160, 80), 1f, SpriteEffects.None, 0.99f);
            //spriteBatch.Draw(evilAura, new Vector2(camera.Position.X - ScreenSize.Width * 0.5f, camera.Position.Y - ScreenSize.Height * 0.5f), null, Color.White, 0f, new Vector2(160, 80), 1f, SpriteEffects.None, 0.02f);


            foreach (GameObject go in gameObjects)
            {
                go.Draw(spriteBatch);

#if DEBUG
                DrawCollisionBox(go);
#endif
            }
            spriteBatch.DrawString(font, $"Souls: {player.currentSouls}", new Vector2(camera.Position.X - 750, camera.Position.Y - 425), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Health: {player.Health}", new Vector2(camera.Position.X - 750, camera.Position.Y - 400), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);
            spriteBatch.DrawString(font, $"Coordinates: X: {Mouse.GetState().X - camera.viewMatrix.Translation.X}   Y: {Mouse.GetState().Y - camera.viewMatrix.Translation.Y}", new Vector2(camera.Position.X, camera.Position.Y - 500), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.991f);

            vendorUIRect = new Rectangle(0, 0, vendorUI.Width, vendorUI.Height);    //Sets the rectangle of vendor UI
            vendorUIPosition = new Vector2(camera.Position.X + 150, camera.Position.Y - 400);   //Sets the default position of vendor UI

            vendorBtnRect = new Rectangle(0, 0, vendorBtn.Width, vendorBtn.Height);     //Sets the rectangle of the vendor button
            vendorBtnPos = new Vector2(vendorUIPosition.X + 70, vendorUIPosition.Y + 270);     //Sets the default position of the vendor button

            Color fadeColorIn = new Color(255, 255, 255, (int)MathHelper.Clamp(alphaValue, 0, 255));
            if (triggerVendor)
            {
                spriteBatch.Draw(vendorUI, vendorUIPosition, vendorUIRect, fadeColorIn, 0, Vector2.Zero, 1, SpriteEffects.None, 0.991f);
                spriteBatch.Draw(vendorBtn, vendorBtnPos, vendorBtnRect, fadeColorIn, 0, Vector2.Zero, 1, SpriteEffects.None, 0.991f);
                IsMouseVisible = true;
            }
            else
            {
                IsMouseVisible = false;
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
