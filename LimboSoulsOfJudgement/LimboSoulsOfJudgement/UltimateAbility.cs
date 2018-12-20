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
        private double durationTimer;
        private int duration = 10;
        public static bool activated = false;

        public UltimateAbility() : base("angelUltimate")
        {
            cooldown = 30;
            cooldownTimer = cooldown;

        }

        /// <summary>
        /// Sets all the stats to *2 
        /// </summary>
        public override void UseAbility()
        {
            base.UseAbility();
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
            GameWorld.player.melee.damage = GameWorld.player.melee.damage * 2;
            GameWorld.player.ranged.damage = GameWorld.player.ranged.damage * 2;

            LightningBoltAbility.LightningBolt.damage = LightningBoltAbility.LightningBolt.damage * 2;
            BloodstormAbility.Bloodstorm.damage = BloodstormAbility.Bloodstorm.damage * 2;
        }

        /// <summary>
        /// if the ability is activated, count the duration and set stats to *0.5
        /// </summary>
        /// <param name="gameTime">Time elapsed since last call in the update</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position = UIAbilityBar.abilitySlot3;

            if (activated)
            {
                durationTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (durationTimer > duration)
                {
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
                    GameWorld.player.melee.damage = (int)(GameWorld.player.melee.damage * 0.5f);
                    GameWorld.player.ranged.damage = (int)(GameWorld.player.ranged.damage * 0.5f);

                    LightningBoltAbility.LightningBolt.damage = (int)(LightningBoltAbility.LightningBolt.damage * 0.5f);
                    BloodstormAbility.Bloodstorm.damage = (int)(BloodstormAbility.Bloodstorm.damage * 0.5f);

                    activated = false;
                    durationTimer = 0;
                }
            }

            if (GameWorld.goodKarmaButton.currentKarma > GameWorld.badKarmaButton.currentKarma)
            {
                sound = new Sound("sound/angelUltimate");
                sprite = GameWorld.ContentManager.Load<Texture2D>("angelUltimate");
            }
            else
            {
                sound = new Sound("sound/demonUltimate");
                sprite = GameWorld.ContentManager.Load<Texture2D>("demonUltimate");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameWorld.buyGodModeAbility.abilityPurchased)
            {
                spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, 0.992f);
            }
            
 
        }
    }
}
