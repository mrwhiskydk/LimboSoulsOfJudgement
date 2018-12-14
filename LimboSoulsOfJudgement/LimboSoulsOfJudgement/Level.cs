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
        public Portal portal;
        public Lava movingLava;
        public bool levelLoaded;
        public Level()
        {

            if (GameWorld.stage == 1)
            {
                //Platforms

                PlaceBlocks(3, 1, 2, 12, 3);
                PlaceBlocks(3, 1, 2, 16, 9);
                PlaceBlocks(3, 1, 38, 20, 6);
                PlaceBlocks(2, 1, 37, 17, 10);
                PlaceBlocks(2, 1, 49, 15, 4);
                PlaceBlocks(2, 1, 51, 13, 3);
                PlaceBlocks(3, 1, 62, 22, 5);
                PlaceBlocks(3, 1, 62, 11, 3);
                PlaceBlocks(2, 2, 75, 11, 5);
                PlaceBlocks(2, 2, 77, 13, 4);
                PlaceBlocks(2, 2, 79, 15, 3);
                PlaceBlocks(2, 2, 81, 17, 3);
                PlaceBlocks(2, 1, 9, 31, 21);
                PlaceBlocks(2, 1, 9, 33, 23);
                PlaceBlocks(3, 1, 52, 36, 10);
                PlaceBlocks(2, 1, 25, 29, 11);
                PlaceBlocks(2, 1, 31, 27, 2);
                PlaceBlocks(2, 1, 9, 29, 2);
                PlaceBlocks(2, 1, 25, 29, 11);
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


                //Chains
                for (int i = 0; i < 15; i++)
                {
                    new Chain(new Vector2(4670, 35 + i * 64), "chain");
                }
                for (int i = 0; i < 15; i++)
                {
                    new Chain(new Vector2(210, 1187 + i * 64), "chain");
                }
                for (int i = 0; i < 16; i++)
                {
                    new Chain(new Vector2(1980, 2210 + i * 64), "chain");
                }
                for (int i = 0; i < 12; i++)
                {
                    new Chain(new Vector2(5200, 2468 + i * 64), "chain");
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
                    PlaceEnemy(1, 27, 10);
                    PlaceEnemy(1, 40, 14);
                    PlaceEnemy(1, 46, 14);
                    PlaceEnemy(1, 65, 18);
                    PlaceEnemy(1, 69, 18);
                    PlaceEnemy(1, 65, 28);
                    PlaceEnemy(1, 71, 28);
                    PlaceEnemy(1, 3, 55);
                    PlaceEnemy(1, 11, 55);
                    PlaceEnemy(1, 19, 55);
                    PlaceEnemy(1, 27, 55);
                    PlaceEnemy(1, 35, 55);
                }
                if (GameWorld.badKarmaButton.currentKarma > GameWorld.goodKarmaButton.currentKarma)
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
                if (GameWorld.badKarmaButton.currentKarma == GameWorld.goodKarmaButton.currentKarma)
                {
                    new MinorEnemy(new Vector2(27 * 64, 10 * 64), "Melee");
                    new MinorEnemy(new Vector2(40 * 64, 14 * 64), "Melee");
                    new MinorEnemy(new Vector2(46 * 64, 14 * 64), "Melee");
                    new MinorEnemy(new Vector2(65 * 64, 18 * 64), "Melee");
                    new MinorEnemy(new Vector2(69 * 64, 18 * 64), "Melee");
                    new MinorEnemy(new Vector2(65 * 64, 28 * 64), "Melee");
                    new MinorEnemy(new Vector2(71 * 64, 28 * 64), "Melee");
                    new MinorEnemy(new Vector2(3 * 64, 55 * 64), "Melee");
                    new MinorEnemy(new Vector2(11 * 64, 55 * 64), "Melee");
                    new MinorEnemy(new Vector2(19 * 64, 55 * 64), "Melee");
                    new MinorEnemy(new Vector2(27 * 64, 55 * 64), "Melee");
                    new MinorEnemy(new Vector2(35 * 64, 55 * 64), "Melee");
                }

                portal = new Portal(new Vector2(/*87 * 64, 55 * 64*/200, 500));
            }
            if (GameWorld.stage == 2)
            {
                // Frame
                new Platform(new Vector2(-511, 2048), "VerticalFrame");
                new Platform(new Vector2(6272, 2048), "VerticalFrame");
                new Platform(new Vector2(2880, 72 * 64), "HorizontalFrame");
                new Platform(new Vector2(2880, -512), "HorizontalFrame");

                // portal to the boss
                portal = new Portal(new Vector2(5 * 64, 7 * 64));

                // Platforms
                PlaceBlocks(2, 1, 3, 59, 3);
                PlaceBlocks(2, 1, 18, 63, 6);
                PlaceBlocks(2, 1, 20, 61, 5);
                PlaceBlocks(2, 1, 22, 59, 4);
                PlaceBlocks(2, 1, 24, 57, 3);
                PlaceBlocks(2, 1, 33, 57, 2);
                PlaceBlocks(2, 1, 41, 57, 2);
                PlaceBlocks(2, 1, 49, 57, 2);
                PlaceBlocks(2, 1, 57, 57, 2);
                PlaceBlocks(2, 1, 65, 57, 2);
                PlaceBlocks(2, 1, 75, 57, 8);

                PlaceBlocks(2, 1, 1, 43, 19);
                PlaceBlocks(2, 1, 51, 45, 4);
                PlaceBlocks(2, 1, 67, 41, 2);
                PlaceBlocks(2, 1, 73, 45, 2);
                PlaceBlocks(2, 1, 61, 37, 2);
                PlaceBlocks(2, 1, 81, 30, 5);
                PlaceBlocks(2, 1, 47, 41, 1);
                PlaceBlocks(2, 1, 43, 37, 1);
                PlaceBlocks(2, 1, 1, 33, 3);
                PlaceBlocks(2, 1, 9, 33, 4);
                PlaceBlocks(2, 1, 17, 33, 3);
                PlaceBlocks(2, 1, 25, 33, 3);
                PlaceBlocks(2, 1, 33, 33, 2);

                PlaceBlocks(2, 1, 23, 19, 34);
                PlaceBlocks(2, 1, 15, 21, 2);
                PlaceBlocks(2, 1, 9, 25, 2);
                PlaceBlocks(2, 1, 1, 17, 3);
                PlaceBlocks(2, 1, 73, 17, 9);
                PlaceBlocks(2, 1, 77, 15, 7);
                PlaceBlocks(2, 1, 81, 13, 5);
                PlaceBlocks(2, 1, 85, 11, 3);
                PlaceBlocks(2, 1, 89, 9, 1);

                PlaceBlocks(2, 1, 1, 9, 5);
                PlaceBlocks(2, 1, 25, 9, 2);
                PlaceBlocks(2, 1, 31, 9, 2);
                PlaceBlocks(2, 1, 63, 9, 2);
                PlaceBlocks(2, 1, 77, 7, 2);

                //Chains
                PlaceBlocks(7, 2, 72, 0, 10);
                PlaceBlocks(7, 2, 69, 0, 10);
                PlaceBlocks(7, 2, 60, 0, 10);
                PlaceBlocks(7, 2, 54, 0, 10);
                PlaceBlocks(7, 2, 48, 0, 10);
                PlaceBlocks(7, 2, 42, 0, 10);
                PlaceBlocks(7, 2, 36, 0, 10);
                PlaceBlocks(7, 2, 20, 0, 10);
                PlaceBlocks(7, 2, 14, 0, 10);

                PlaceBlocks(7, 2, 4, 18, 10);
                PlaceBlocks(7, 2, 30, 44, 20);
                PlaceBlocks(7, 2, 82, 31, 19);
                PlaceBlocks(7, 2, 41, 20, 20);

                // Trapdoors
                PlaceBlocks(4, 1, 7, 33, 1);
                PlaceBlocks(4, 1, 17, 33, 1);
                PlaceBlocks(4, 1, 23, 33, 1);
                PlaceBlocks(4, 1, 31, 33, 1);

                // Moving Lava
                movingLava = new Lava(new Vector2(GameWorld.ScreenSize.Width * 2 - (5 * 64), 6100), "MegaLava");

                // Enemies
                if (GameWorld.badKarmaButton.currentKarma < GameWorld.goodKarmaButton.currentKarma)
                {

                }
                if (GameWorld.badKarmaButton.currentKarma > GameWorld.goodKarmaButton.currentKarma)
                {

                }
                if (GameWorld.badKarmaButton.currentKarma == GameWorld.goodKarmaButton.currentKarma)
                {

                }
                levelLoaded = true;
            }
            if (GameWorld.stage == 10)
            {
                // Frame
                new Platform(new Vector2(-511, 2048), "VerticalFrame");
                new Platform(new Vector2(68 * 64, 2048), "VerticalFrame");
                new Platform(new Vector2(2880, 40 * 64), "HorizontalFrame");
                new Platform(new Vector2(2880, -512), "HorizontalFrame");

                //Platforme
                PlaceBlocks(2, 1, 3, 31, 1);
                PlaceBlocks(2, 1, 9, 31, 1);
                PlaceBlocks(2, 1, 15, 31, 2);
                PlaceBlocks(2, 1, 23, 31, 1);
                PlaceBlocks(2, 1, 29, 31, 2);
                PlaceBlocks(2, 1, 37, 31, 1);
                PlaceBlocks(2, 1, 43, 31, 2);
                PlaceBlocks(2, 1, 51, 31, 1);
                PlaceBlocks(2, 1, 57, 31, 1);

                PlaceBlocks(2, 1, 3, 7, 2);
                PlaceBlocks(2, 1, 9, 9, 2);
                PlaceBlocks(2, 1, 15, 11, 2);
                PlaceBlocks(2, 1, 21, 13, 3);
                PlaceBlocks(2, 1, 27, 7, 4);
                PlaceBlocks(2, 1, 35, 13, 3);
                PlaceBlocks(2, 1, 43, 11, 2);
                PlaceBlocks(2, 1, 49, 9, 2);
                PlaceBlocks(2, 1, 55, 7, 2);

                PlaceBlocks(2, 1, 3, 15, 1);
                PlaceBlocks(2, 1, 7, 17, 2);
                PlaceBlocks(2, 1, 13, 19, 2);
                PlaceBlocks(2, 1, 19, 21, 2);
                PlaceBlocks(2, 1, 25, 23, 2);
                PlaceBlocks(2, 1, 33, 23, 2);
                PlaceBlocks(2, 1, 39, 21, 2);
                PlaceBlocks(2, 1, 45, 19, 2);
                PlaceBlocks(2, 1, 51, 17, 2);
                PlaceBlocks(2, 1, 57, 15, 1);


                // Lava
                PlaceBlocks(5, 2, 1, 1, 16);
                PlaceBlocks(5, 1, 5, 31, 2);
                PlaceBlocks(5, 1, 11, 31, 2);
                PlaceBlocks(5, 1, 19, 31, 2);
                PlaceBlocks(5, 1, 25, 31, 2);
                PlaceBlocks(5, 1, 33, 31, 2);
                PlaceBlocks(5, 1, 39, 31, 2);
                PlaceBlocks(5, 1, 47, 31, 2);
                PlaceBlocks(5, 1, 53, 31, 2);
                PlaceBlocks(5, 2, 59, 1, 16);

                // Chains
                PlaceBlocks(7, 2, 7, 0 ,12);
                PlaceBlocks(7, 2, 11, 10, 16);
                PlaceBlocks(7, 2, 23, 14, 12);
                PlaceBlocks(7, 2, 27, 8, 10);
                PlaceBlocks(7, 2, 33, 8, 10);
                PlaceBlocks(7, 2, 37, 14, 12);
                PlaceBlocks(7, 2, 49, 10, 16);
                PlaceBlocks(7, 2, 53, 0, 12);

                // Boss
                if (GameWorld.badKarmaButton.currentKarma < GameWorld.goodKarmaButton.currentKarma)
                {
                    boss = new BossEnemy("Boss");
                }
                else
                {
                    boss = new BossEnemy("GoodBoss");
                }

                portal = new Portal(new Vector2(30 * 64, 20 * 64));
            }
        }

        /// <summary>
        /// A method for placing non animated gameobjects in a level
        /// </summary>
        /// <param name="s">The type of the platform. 1 = small, 2 = medium , 3 = big, 4 = Trapdoor, 5 = Lava, 6 = Lava surface, 7 = Chains</param>
        /// <param name="d">The direction the blocks are placed. Either 1 for Horizontal or 2 for vertical</param>
        /// <param name="x">Where on the x-axis, measured in times of 64, the platform should be placed</param>
        /// <param name="y">Where on the y-axis, measured in times of 64, the platform should be placed</param>
        /// <param name="z">How many platforms should be placed beside eachother</param>
        private void PlaceBlocks(int s, int d, int x, int y, int z)
        {
            string name = "MediumBlock";
            if (d == 1)
            {
                if (s == 1 || s == 2 || s == 3)
                {
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

                    for (int i = 0; i < z; i++)
                    {
                        new Platform(new Vector2((x * 64) + (i * s), (y * 64)), $"{name}");

                    }
                }
                else if (s == 4)
                {
                    name = "MediumBlock";
                    s = 128;
                    for (int i = 0; i < z; i++)
                    {
                        new Trapdoor(new Vector2((x * 64) + (i * s), (y * 64)), $"{name}");
                    }
                }
                else if (s == 5)
                {
                    name = "MediumLava";
                    s = 128;
                    for (int i = 0; i < z; i++)
                    {
                        new Lava(new Vector2((x * 64) + (i * s), (y * 64)), $"{name}");
                    }
                }
                else if (s == 6)
                {
                    name = "SurfaceLava";
                    s = 128;
                    for (int i = 0; i < z; i++)
                    {
                        new Lava(new Vector2((x * 64) + (i * s), (y * 64)), $"{name}");
                    }
                }
            }

            if (d == 2)
            {
                if (s == 1 || s == 2 || s == 3)
                {
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
                    for (int i = 0; i < z; i++)
                    {
                        new Platform(new Vector2((x * 64), (i * s) + (y * 64)), $"{name}");
                    }
                }
                else if (s == 4)
                {
                    name = "Trapdoor";
                    s = 128;
                    for (int i = 0; i < z; i++)
                    {
                        new Trapdoor(new Vector2((x * 64), (i * s) + (y * 64)), $"{name}");
                    }
                }
                else if (s == 5)
                {
                    name = "MediumLava";
                    s = 128;
                    for (int i = 0; i < z; i++)
                    {
                        new Lava(new Vector2((x * 64), (i * s) + (y * 64)), $"{name}");
                    }
                }
                else if (s == 7)
                {
                    name = "Chain";
                    s = 64;
                    for (int i = 0; i < z; i++)
                    {
                        new Chain(new Vector2((x * 64), (i * s) + (y * 64)), $"{name}");
                    }
                }

            }   
            
        }

        /// <summary>
        /// A method for placing enemies in a level
        /// </summary>
        /// <param name="t">Which type of enemy, 1 = Smalldevil, 2 = Smallangel, 3 = Default</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PlaceEnemy(int t, int x, int y)
        {

            if (t == 1)
            {
                new MinorEnemy(new Vector2(x * 64, y * 64), "SmallDevil");
            }
            else if (t == 2)
            {
                new MinorEnemy(new Vector2(x * 64, y * 64), "SmallAngel");
            }
            else if (t == 3)
            {
                new MinorEnemy(new Vector2(x * 64, y * 64), "Melee");
            }
        }
    }

}