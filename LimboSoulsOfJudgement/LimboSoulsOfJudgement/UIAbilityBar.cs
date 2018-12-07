using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    public class UIAbilityBar : GameObjectPassive
    {
        public static Vector2 abilitySlot1;
        public static Vector2 abilitySlot2;
        public static Vector2 abilitySlot3;

        public UIAbilityBar() : base("UIAbilityBar")
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            position = new Vector2(GameWorld.player.Position.X, GameWorld.player.Position.Y);
            abilitySlot1 = position;
        }
    }
}
