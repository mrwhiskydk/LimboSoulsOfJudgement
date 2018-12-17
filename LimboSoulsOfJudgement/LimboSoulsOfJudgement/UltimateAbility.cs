using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LimboSoulsOfJudgement
{
    class UltimateAbility : Ability
    {
        private double duration;
        private bool activated = false;

        public UltimateAbility() : base("LightningBoltAbility")
        {
            cooldown = 10;
            cooldownTimer = cooldown;
        }

        public override void UseAbility()
        {
            activated = true;
            GameWorld.player.critChance = GameWorld.player.critChance * 2;
            GameWorld.player.critDmgModifier = GameWorld.player.critDmgModifier * 2;
            if (GameWorld.goodKarmaButton.currentKarma > GameWorld.badKarmaButton.currentKarma)
            {
                GameWorld.player.healthRegen = GameWorld.player.healthRegen * 2;
            }
            else if (GameWorld.goodKarmaButton.currentKarma < GameWorld.badKarmaButton.currentKarma)
            {
                GameWorld.player.lifeSteal = GameWorld.player.lifeSteal * 2;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position = UIAbilityBar.abilitySlot3;

            if (activated)
            {
                duration += gameTime.ElapsedGameTime.TotalSeconds;
                if (duration > 5)
                {
                    duration = 0;

                    GameWorld.player.critChance = GameWorld.player.critChance * 0.5f;
                    GameWorld.player.critDmgModifier = GameWorld.player.critDmgModifier * 0.5f;
                    if (GameWorld.goodKarmaButton.currentKarma > GameWorld.badKarmaButton.currentKarma)
                    {
                        GameWorld.player.healthRegen = GameWorld.player.healthRegen * 0.5f;
                    }
                    else if (GameWorld.goodKarmaButton.currentKarma < GameWorld.badKarmaButton.currentKarma)
                    {
                        GameWorld.player.lifeSteal = GameWorld.player.lifeSteal * 0.5f;
                    }
                    activated = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //if (GameWorld.buyLightningBoltButton.abilityPurchased)
            //{
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.992f);
            //}
            //else
            //{
            //    spriteBatch.Draw(sprite, position, null, Color.White * 0.0f, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.992f);
            //}
        }
    }
}
