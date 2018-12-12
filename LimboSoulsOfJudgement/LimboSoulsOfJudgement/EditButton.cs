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


        }

        public override void DoCollision(GameObject otherObject)
        {
            base.DoCollision(otherObject);

            if (otherObject is MeleeWeapon && GameWorld.player.editMode == false)
            {
                editOn = true;
            }
            if (otherObject is MeleeWeapon && GameWorld.player.editMode == true)
            {
                editOn = false;
            }
        }
    }
}
