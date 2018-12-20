using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the default functionality and game logic of the Vendor GameObject.
    /// Handles the overall sprite stages, and checks if the Player GameObject is able to interact with the Vendor GameObject.
    /// </summary>
    public class Vendor : AnimatedGameObject
    {
        private float nextClick = 0.3f;
        private double keyPressed;

        private bool vendorInteract = false;

        /// <summary>
        /// Vendor Constructor, that sets vendor animation values, start position and sprite name 
        /// </summary>
        public Vendor() : base(4, 4, new Vector2(300, -1500), "Vendor")
        {

        }

        /// <summary>
        /// Update Method that enables constant gravity on the Vendor GameObject, and updates base game logic.
        /// Checks wether or not the Player GameObject is within reach or the Vendor, in order to switch between different Vendor sprite states.
        /// Also checks turns Vendors facing direction left or right, depending on the Player's current position of the Vendor.
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
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
        /// Method that handles Vendor collision functionality with the other current GameObjects in the game.
        /// Handles the enabling and disabling of the triggerVendor bool value.
        /// </summary>
        /// <param name="otherObject">The GameObject that the Vendor object collides with</param>
        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            //Loops through all GameObjects, in order to find collision with the Player GameObject
            foreach(GameObject go in GameWorld.gameObjects)
            {
                otherObject = go;
                if (otherObject.IsColliding(this) && otherObject is Player) //Checks if the other GameObject is the Player, if so, the value of vendorInteract is to to true.
                {
                    vendorInteract = true;  //The Player can begin interactions with the Vendor GameObject
                }
                else if(!GameWorld.player.IsColliding(this))    //If no collision between Vendor and Player is detected, interactions and shopping options are unavailable
                {
                    GameWorld.triggerVendor = false;
                    vendorInteract = false;
                }

                if (otherObject is Platform)    //Statement that checks if the Vendor is colliding with a Platform, to prevent the Vendor from glitching through the floor
                {
                    while (otherObject.IsColliding(this))
                    {
                        position.Y -= 1;
                    }
                }
            }
        }
    }
}