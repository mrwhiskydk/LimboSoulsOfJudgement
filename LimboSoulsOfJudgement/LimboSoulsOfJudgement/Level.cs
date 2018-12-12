using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LimboSoulsOfJudgement
{
    public class Level
    {
        public BossEnemy boss;
        public Level()
        {
            if (GameWorld.stage == 1)
            {
                //Platforms
                PlacePlatform(3, 1, 2, 12, 3);
                PlacePlatform(3, 1, 2, 16, 9);
                for (int i = 0; i < 6; i++)
                {
                    new Platform(new Vector2(2432 + i * 256, 1280), "BigBlock");
                }
                for (int i = 0; i < 10; i++)
                {
                    new Platform(new Vector2(2368 + i * 128, 1088), "MediumBlock");
                }
                for (int i = 0; i < 4; i++)
                {
                    new Platform(new Vector2(3136 + i * 128, 960), "MediumBlock");
                }
                for (int i = 0; i < 3; i++)
                {
                    new Platform(new Vector2(3264 + i * 128, 832), "MediumBlock");
                }
                for (int i = 0; i < 5; i++)
                {
                    new Platform(new Vector2(3968 + i * 256, 1408), "BigBlock");
                }
                for (int i = 0; i < 3; i++)
                {
                    new Platform(new Vector2(3968 + i * 256, 704), "BigBlock");
                }
                for (int i = 0; i < 5; i++)
                {
                    new Platform(new Vector2(4800, 704 + i * 128), "MediumBlock");
                }
                for (int i = 0; i < 4; i++)
                {
                    new Platform(new Vector2(4928, 832 + i * 128), "MediumBlock");
                }
                for (int i = 0; i < 3; i++)
                {
                    new Platform(new Vector2(5056, 960 + i * 128), "MediumBlock");
                }
                for (int i = 0; i < 3; i++)
                {
                    new Platform(new Vector2(5184, 1088 + i * 128), "MediumBlock");
                }
                for (int i = 0; i < 21; i++)
                {
                    new Platform(new Vector2(576 + i * 128, 1984), "MediumBlock");
                }
                for (int i = 0; i < 24; i++)
                {
                    new Platform(new Vector2(576 + i * 128, 2112), "MediumBlock");
                }
                for (int i = 0; i < 21; i++)
                {
                    new Platform(new Vector2(3328 + i * 256, 2304), "BigBlock");
                }
                for (int i = 0; i < 11; i++)
                {
                    new Platform(new Vector2((25*64) + i * 128, (29*64)), "MediumBlock");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Platform(new Vector2((31 * 64) + i * 128, (27 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Platform(new Vector2((9 * 64) + i * 128, (29 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 7; i++)
                {
                    new Platform(new Vector2((89 * 64), i * 128 + (21 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 4; i++)
                {
                    new Platform(new Vector2(128 + i * 256, 23*128), "BigBlock");
                }
                for (int i = 0; i < 5; i++)
                {
                    new Platform(new Vector2((1 * 64) + i * 128, (43 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 4; i++)
                {
                    new Platform(new Vector2((1 * 64) + i * 128, (41 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 9; i++)
                {
                    new Platform(new Vector2((45 * 64) + i * 128, (55 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 8; i++)
                {
                    new Platform(new Vector2((47 * 64) + i * 128, (53 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 7; i++)
                {
                    new Platform(new Vector2((49 * 64) + i * 128, (51 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 6; i++)
                {
                    new Platform(new Vector2((51 * 64) + i * 128, (49 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 5; i++)
                {
                    new Platform(new Vector2((53 * 64) + i * 128, (47 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 4; i++)
                {
                    new Platform(new Vector2((55 * 64) + i * 128, (45 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 3; i++)
                {
                    new Platform(new Vector2((57 * 64) + i * 128, (43 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 3; i++)
                {
                    new Platform(new Vector2((67 * 64) + i * 128, (43 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 3; i++)
                {
                    new Platform(new Vector2((73 * 64), i * 128 + (39 * 64)), "MediumBlock");
                }
                for (int i = 0; i < 4; i++)
                {
                    new Platform(new Vector2((81 * 64) + i * 128, (33 * 64)), "MediumBlock");
                }

                new Platform(new Vector2((77 * 64), (31 * 64)), "MediumBlock");
                new Platform(new Vector2((73 * 64), (31 * 64)), "MediumBlock");
                new Platform(new Vector2((71 * 64), (31 * 64)), "MediumBlock");
                new Platform(new Vector2((69 * 64), (31 * 64)), "MediumBlock");
                new Platform(new Vector2((65 * 64), (31 * 64)), "MediumBlock");
                new Platform(new Vector2((63 * 64), (31 * 64)), "MediumBlock");
                new Platform(new Vector2((61 * 64), (31 * 64)), "MediumBlock");
                new Platform(new Vector2((57 * 64), (31 * 64)), "MediumBlock");
                new Platform(new Vector2((21 * 64), (45 * 64)), "MediumBlock");
                new Platform(new Vector2((27 * 64), (49 * 64)), "MediumBlock");
                new Platform(new Vector2((35 * 64), (49 * 64)), "MediumBlock");
                new Platform(new Vector2((41 * 64), (45 * 64)), "MediumBlock");

                new Platform(new Vector2(9 * 64, 27 * 64), "MediumBlock");
                new Platform(new Vector2(39 * 64, 9 * 64), "MediumBlock");
                new Platform(new Vector2(45 * 64, 9 * 64), "MediumBlock");
                new Platform(new Vector2(3776, 768), "MediumBlock");
                new Platform(new Vector2(3392, 704), "MediumBlock");
                new Platform(new Vector2(3520, 704), "MediumBlock");
                new Platform(new Vector2(1664, 768), "BigBlock");
                new Platform(new Vector2(1920, 768), "BigBlock");
                new Platform(new Vector2(2112, 832), "MediumBlock");
                new Platform(new Vector2(960, 448), "MediumBlock");
                new Platform(new Vector2(1344, 448), "MediumBlock");



                // Trapdoor


                //Chains
                for (int i = 0; i < 15; i++)
                {
                    new Chain(new Vector2(4670, 35 + i * 70), "chain");
                }
                for (int i = 0; i < 15; i++)
                {
                    new Chain(new Vector2(210, 1187 + i * 70), "chain");
                }
                for (int i = 0; i < 16; i++)
                {
                    new Chain(new Vector2(1980, 2210 + i * 70), "chain");
                }
                for (int i = 0; i < 12; i++)
                {
                    new Chain(new Vector2(5200, 2468 + i * 70), "chain");
                }

                //Lava
                for (int i = 0; i < 6; i++)
                {
                    new Lava(new Vector2((13 * 64) + i * 128, (708)), "SurfaceLava");
                }
                for (int i = 0; i < 6; i++)
                {
                    new Lava(new Vector2((13 * 64) + i * 128, (13 * 64)), "MediumLava");
                }
                for (int i = 0; i < 13; i++)
                {
                    new Lava(new Vector2((55 * 64) + i * 128, (2116)), "SurfaceLava");
                }

                // Frame
                new Platform(new Vector2(-511, 2048), "VerticalFrame");
                new Platform(new Vector2(6272, 2048), "VerticalFrame");
                new Platform(new Vector2(2880, 64 * 64), "HorizontalFrame");
                new Platform(new Vector2(2880, -512), "HorizontalFrame");

                // Minor Enemies
                if (GameWorld.badKarmaButton.currentKarma < GameWorld.goodKarmaButton.currentKarma)
                {
                    new MinorEnemy(new Vector2(27 * 64, 10 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(40 * 64, 14 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(46 * 64, 14 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(65 * 64, 18 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(69 * 64, 18 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(65 * 64, 28 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(71 * 64, 28 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(3 * 64, 55 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(11 * 64, 55 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(19 * 64, 55 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(27 * 64, 55 * 64), "SmallDevil");
                    new MinorEnemy(new Vector2(35 * 64, 55 * 64), "SmallDevil");
                }
                else
                {
                    new MinorEnemy(new Vector2(27 * 64, 10 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(40 * 64, 14 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(46 * 64, 14 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(65 * 64, 18 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(69 * 64, 18 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(65 * 64, 28 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(71 * 64, 28 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(3 * 64, 55 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(11 * 64, 55 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(19 * 64, 55 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(27 * 64, 55 * 64), "SmallAngel");
                    new MinorEnemy(new Vector2(35 * 64, 55 * 64), "SmallAngel");
                }

            }

            if (GameWorld.stage == 10)
            {
                new Platform(new Vector2(-511, 2048), "VerticalFrame");
                new Platform(new Vector2(65 * 64, 2048), "VerticalFrame");
                new Platform(new Vector2(2880, 37 * 64), "HorizontalFrame");
                new Platform(new Vector2(2880, -512), "HorizontalFrame");

                // Boss
                if (GameWorld.badKarmaButton.currentKarma < GameWorld.goodKarmaButton.currentKarma)
                {
                    boss = new BossEnemy("Boss");
                }
                else
                {
                    boss = new BossEnemy("GoodBoss");
                }
            }
        }

        /// <summary>
        /// A method for placing platforms in a level
        /// </summary>
        /// <param name="s">The size of the platform. Either 1 for small, 2 for medium or 3 for big</param>
        /// <param name="d">The direction the blocks are placed. Either 1 for Horizontal or 2 for vertical</param>
        /// <param name="x">Where on the x-axis the platform should be placed</param>
        /// <param name="y">Where on the y-axis the platform should be placed</param>
        /// <param name="z">How many platforms should be placed beside eachother</param>
        private void PlacePlatform(int s, int d, int x, int y, int z)
        {
            string name = "MediumBlock";

            if (s == 1)
            {
                name = "SmallBlock";
                s = 64;
            }

            else if (s == 2)
            {
                name = "MediumBlock";
                s = 128;
            }

            else if (s == 3)
            {
                name = "BigBlock";
                s = 256;
            }

            if (d == 1)
            {
                for (int i = 0; i < z; i++)
                {
                    new Platform(new Vector2((x * 64) + (i * s), (y * 64)), $"{name}");
                    
                }
            }

            if (d == 2)
            {
                for (int i = 0; i < z; i++)
                {
                    new Platform(new Vector2((x * 64) + (i * s), (y * 64)), $"{name}");
                }
            }

        }

    }

}