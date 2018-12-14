using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LimboSoulsOfJudgement
{
    class EditButton : GameObject
    {
        private bool editOn;
        private bool clicked = false;
        private double clickReset;
        private float clickedTime = 2;
        public EditButton() : base(new Vector2(600, 200), "Edit")
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (editOn == true)
            {
                GameWorld.player.editMode = true;
            }
            else if (editOn == false)
            {
                GameWorld.player.editMode = false;
            }

            if (clicked == true)
            {
                clickReset += gameTime.ElapsedGameTime.TotalSeconds;
                if (clickReset > clickedTime)
                {
                    clicked = false;
                }
            }

        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is MeleeWeapon && GameWorld.player.editMode == false && clicked == false)
            {
                editOn = true;
                clicked = true;
            }
            if (otherObject is MeleeWeapon && GameWorld.player.editMode == true && clicked == false)
            {
                editOn = false;
                clicked = true;
            }
        }
    }
}
