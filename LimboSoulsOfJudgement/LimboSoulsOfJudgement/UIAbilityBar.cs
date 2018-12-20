﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class UIAbilityBar : GameObjectPassive
    {
        //Positions of the ability slots
        public static Vector2 abilitySlot1;
        public static Vector2 abilitySlot2;
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
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position = new Vector2(GameWorld.camera.Position.X, GameWorld.camera.Position.Y + GameWorld.ScreenSize.Height * 0.5f - sprite.Height / 2);
            abilitySlot1 = position - new Vector2(distanceBetweenSlots, 0);
            abilitySlot2 = position;
            abilitySlot3 = position + new Vector2(distanceBetweenSlots, 0);
        }
    }
}
