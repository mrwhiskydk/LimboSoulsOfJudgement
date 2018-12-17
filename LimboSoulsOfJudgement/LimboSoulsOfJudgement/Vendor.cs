using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    public class Vendor : AnimatedGameObject
    {
        private float nextClick = 0.3f;
        private double keyPressed;

        private bool vendorInteract = false;

        /// <summary>
        /// Vendor Constructor, that sets vendor animation values, start position and sprite name 
        /// </summary>
        /// <param name="frameCount"></param>
        /// <param name="animationFPS"></param>
        /// <param name="startPostion"></param>
        /// <param name="spriteName"></param>
        public Vendor() : base(4, 4, new Vector2(600, -1550), "Vendor")
        {

        }

        /// <summary>
        /// Update Method that enables constant gravity on the Vendor GameObject, and updates base game logic
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            gravity = true;

            //Statement that checks if the player is colliding with the vendor GameObject.
            if (vendorInteract)
            {
                keyPressed += gameTime.ElapsedGameTime.TotalSeconds;
                //if true, button click 'E' on keyboard is available, as long as key pressed has reached the same amount of value as next click
                if (Keyboard.GetState().IsKeyDown(Keys.E) && keyPressed > nextClick)   
                {
                    //Enables the functionality to open & close the vendor UI, as long as the player remains in contact with the Vendor's BoxCollider
                    GameWorld.triggerVendor = !GameWorld.triggerVendor;
                    //GameWorld.ui.Position = new Vector2(GameWorld.vendor.Position.X, GameWorld.vendor.Position.Y + 120);
                    keyPressed = 0; //Upon click, the value of keyPressed is reset to 0 to add another time window for the next click to be available
                }

            }

            if (Vector2.Distance(position, GameWorld.player.Position) <= 400)
            {
                State(4, "Vendor2");
            }
            else if (Vector2.Distance(position, GameWorld.player.Position) > 400)
            {
                State(4, "Vendor");
            }

            if (GameWorld.player.Position.X > position.X)
            {
                facingRight = false;
            }
            else if (GameWorld.player.Position.X < position.X)
            {
                facingRight = true;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Method that handles Vendor collision functionality with the other current GameObjects in the game
        /// </summary>
        /// <param name="otherObject">The GameObject that the Vendor object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            foreach(GameObject go in GameWorld.gameObjects)
            {
                otherObject = go;
                if (otherObject.IsColliding(this) && otherObject is Player)
                {
                    vendorInteract = true;
                }
                else if(!GameWorld.player.IsColliding(this))
                {
                    GameWorld.triggerVendor = false;
                    vendorInteract = false;
                }

                if (otherObject is Platform)
                {
                    while (otherObject.IsColliding(this))
                    {
                        position.Y -= 1;
                    }
                    //position.Y += 1;
                }
            }
        }


    }
}