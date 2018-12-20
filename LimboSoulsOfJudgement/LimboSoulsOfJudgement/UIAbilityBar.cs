using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    /// <summary>
    /// Public Class that represents the functionality and game logic of the UIAbilityBar
    /// </summary>
    public class UIAbilityBar : GameObjectPassive
    {
        //Positions of the ability slots
        /// <summary>
        /// Used to indicate the position of abilitySlot1
        /// </summary>
        public static Vector2 abilitySlot1;
        /// <summary>
        /// Used to indicate the position of abilitySlot2
        /// </summary>
        public static Vector2 abilitySlot2;
        /// <summary>
        /// Used to indicate the position of abilitySlot3
        /// </summary>
        public static Vector2 abilitySlot3;
        private int distanceBetweenSlots = 82;

        /// <summary>
        /// Constructor
        /// </summary>
        public UIAbilityBar() : base("UIAbilityBar")
        {
            
        }

        /// <summary>
        /// Method gets run once every game tick. Updates the positions of the ability slots
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            position = new Vector2(GameWorld.camera.Position.X, GameWorld.camera.Position.Y + GameWorld.ScreenSize.Height * 0.5f - sprite.Height / 2);
            abilitySlot1 = position - new Vector2(distanceBetweenSlots, 0);
            abilitySlot2 = position;
            abilitySlot3 = position + new Vector2(distanceBetweenSlots, 0);
        }
    }
}
