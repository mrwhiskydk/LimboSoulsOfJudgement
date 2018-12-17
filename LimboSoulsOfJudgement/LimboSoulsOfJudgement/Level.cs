using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace LimboSoulsOfJudgement
{
    public class Level
    {
        public BossEnemy boss;
        public NeutralBoss neutralBoss;
        public MinorEnemy minorEnemy;
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

                // Trapdoor
                PlaceBlocks(4, 1, 63, 43, 2);


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
                    PlaceEnemy(1, 68, 55);
                    PlaceEnemy(1, 78, 55);
                }
                if (GameWorld.badKarmaButton.currentKarma > GameWorld.goodKarmaButton.currentKarma)
                {
                    PlaceEnemy(2, 27, 10);
                    PlaceEnemy(2, 40, 14);
                    PlaceEnemy(2, 46, 14);
                    PlaceEnemy(2, 65, 18);
                    PlaceEnemy(2, 69, 18);
                    PlaceEnemy(2, 65, 28);
                    PlaceEnemy(2, 71, 28);
                    PlaceEnemy(2, 3, 55);
                    PlaceEnemy(2, 11, 55);
                    PlaceEnemy(2, 19, 55);
                    PlaceEnemy(2, 27, 55);
                    PlaceEnemy(2, 35, 55);
                    PlaceEnemy(2, 68, 55);
                    PlaceEnemy(2, 78, 55);
                }
                if (GameWorld.badKarmaButton.currentKarma == GameWorld.goodKarmaButton.currentKarma)
                {
                    PlaceEnemy(3, 27, 10);
                    PlaceEnemy(3, 40, 14);
                    PlaceEnemy(3, 46, 14);
                    PlaceEnemy(3, 65, 18);
                    PlaceEnemy(3, 69, 18);
                    PlaceEnemy(3, 65, 28);
                    PlaceEnemy(3, 71, 28);
                    PlaceEnemy(3, 3, 55);
                    PlaceEnemy(3, 11, 55);
                    PlaceEnemy(3, 19, 55);
                    PlaceEnemy(3, 27, 55);
                    PlaceEnemy(3, 35, 55);
                    PlaceEnemy(3, 68, 55);
                    PlaceEnemy(3, 78, 55);
                }

                portal = new Portal(new Vector2(87 * 64, 55 * 64));

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
                PlaceBlocks(6, 2, 72, 0, 10);
                PlaceBlocks(6, 2, 69, 0, 10);
                PlaceBlocks(6, 2, 60, 0, 10);
                PlaceBlocks(6, 2, 54, 0, 10);
                PlaceBlocks(6, 2, 48, 0, 10);
                PlaceBlocks(6, 2, 42, 0, 10);
                PlaceBlocks(6, 2, 36, 0, 10);
                PlaceBlocks(6, 2, 20, 0, 10);
                PlaceBlocks(6, 2, 14, 0, 10);

                PlaceBlocks(6, 2, 4, 18, 10);
                PlaceBlocks(6, 2, 30, 44, 20);
                PlaceBlocks(6, 2, 82, 31, 19);
                PlaceBlocks(6, 2, 41, 20, 20);
                PlaceBlocks(6, 2, 69, 42, 20);

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
                    PlaceEnemy(1, 87, 54);
                    PlaceEnemy(1, 50, 41);
                    PlaceEnemy(1, 12, 40);
                    PlaceEnemy(1, 22, 40);
                    PlaceEnemy(1, 30, 40);
                    PlaceEnemy(1, 12, 14);
                    PlaceEnemy(1, 46, 14);
                    PlaceEnemy(1, 38, 14);
                    PlaceEnemy(1, 56, 14);
                    PlaceEnemy(1, 66, 14);
                }
                if (GameWorld.badKarmaButton.currentKarma > GameWorld.goodKarmaButton.currentKarma)
                {
                    PlaceEnemy(2, 87, 54);
                    PlaceEnemy(2, 50, 41);
                    PlaceEnemy(2, 12, 40);
                    PlaceEnemy(2, 22, 40);
                    PlaceEnemy(2, 30, 40);
                    PlaceEnemy(2, 12, 14);
                    PlaceEnemy(2, 46, 14);
                    PlaceEnemy(2, 38, 14);
                    PlaceEnemy(2, 56, 14);
                    PlaceEnemy(2, 66, 14);
                }
                if (GameWorld.badKarmaButton.currentKarma == GameWorld.goodKarmaButton.currentKarma)
                {
                    PlaceEnemy(3, 87, 54);
                    PlaceEnemy(3, 50, 41);
                    PlaceEnemy(3, 12, 40);
                    PlaceEnemy(3, 22, 40);
                    PlaceEnemy(3, 30, 40);
                    PlaceEnemy(3, 12, 14);
                    PlaceEnemy(3, 46, 14);
                    PlaceEnemy(3, 38, 14);
                    PlaceEnemy(3, 56, 14);
                    PlaceEnemy(3, 66, 14);
                }
                levelLoaded = true;
            }
            if (GameWorld.stage == 3)
            {
                new Platform(new Vector2(-511, 2048), "VerticalFrame");
                new Platform(new Vector2(6272, 2048), "VerticalFrame");
                new Platform(new Vector2(2880, 72 * 64), "HorizontalFrame");
                new Platform(new Vector2(2880, -512), "HorizontalFrame");

                portal = new Portal(new Vector2(21 * 64, 9 * 64));

                // Platforms
                PlaceBlocks(2, 1, 1, 11, 3);
                PlaceBlocks(3, 2, 20, 12, 11);
                PlaceBlocks(3, 2, 24, 12, 11);
                PlaceBlocks(3, 1, 28, 12, 1);
                PlaceBlocks(3, 1, 36, 12, 2);
                PlaceBlocks(3, 1, 44, 12, 1);
                PlaceBlocks(3, 1, 52, 12, 1);
                PlaceBlocks(3, 1, 60, 12, 3);
                PlaceBlocks(2, 1, 17, 25, 1);
                PlaceBlocks(2, 1, 1, 35, 1);
                PlaceBlocks(2, 1, 17, 47, 1);
                PlaceBlocks(3, 1, 24, 52, 4);
                PlaceBlocks(2, 1, 35, 63, 1);
                PlaceBlocks(3, 2, 48, 38, 7);
                PlaceBlocks(3, 1, 40, 38, 2);
                PlaceBlocks(2, 1, 27, 47, 2);
                PlaceBlocks(3, 1, 28, 26, 11);
                PlaceBlocks(3, 2, 68, 30, 4);
                PlaceBlocks(2, 1, 55, 63, 2);
                PlaceBlocks(2, 1, 63, 63, 2);
                PlaceBlocks(2, 1, 71, 63, 2);
                PlaceBlocks(2, 1, 79, 63, 2);
                PlaceBlocks(2, 1, 87, 63, 2);
                PlaceBlocks(2, 1, 71, 43, 4);
                PlaceBlocks(2, 1, 78, 25, 2);
                PlaceBlocks(3, 1, 84, 34, 2);
                PlaceBlocks(2, 1, 83, 17, 4);
                PlaceBlocks(2, 1, 74, 13, 2);

                // Trapdoors
                PlaceBlocks(4, 1, 7, 11, 6);
                PlaceBlocks(4, 1, 31, 11, 2);
                PlaceBlocks(4, 1, 31, 13, 2);
                PlaceBlocks(4, 1, 47, 11, 2);
                PlaceBlocks(4, 1, 47, 13, 2);
                PlaceBlocks(4, 1, 55, 11, 2);
                PlaceBlocks(4, 1, 55, 13, 2);

                // Chains
                PlaceBlocks(6, 2, 43, 40, 18);
                PlaceBlocks(6, 2, 35, 28, 13);
                PlaceBlocks(6, 2, 85, 36, 22);
                PlaceBlocks(6, 2, 79, 26, 10);
                PlaceBlocks(6, 2, 80, 0, 18);
                PlaceBlocks(6, 2, 85, 17, 10);

                // Lava
                for (int i = 0; i < 5; i++)
                {
                    new Lava(new Vector2(37 * 64 + (i *128), 4040), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(51 * 64 + (i * 128), 4040), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(59 * 64 + (i * 128), 4040), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(67 * 64 + (i * 128), 4040), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(75 * 64 + (i * 128), 4040), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(83 * 64 + (i * 128), 4040), "SurfaceLava");
                }

                // Enemies
                if (GameWorld.badKarmaButton.currentKarma < GameWorld.goodKarmaButton.currentKarma)
                {
                    PlaceEnemy(1, 16, 21);
                    PlaceEnemy(1, 2, 33);
                    PlaceEnemy(1, 16, 45);
                    PlaceEnemy(1, 43, 36);
                    PlaceEnemy(1, 80, 59);
                    PlaceEnemy(1, 86, 32);
                    PlaceEnemy(1, 28, 21);
                    PlaceEnemy(1, 36, 21);
                    PlaceEnemy(1, 46, 21);
                    PlaceEnemy(1, 56, 21);
                    PlaceEnemy(1, 86, 14);
                    PlaceEnemy(1, 36, 7);
                    PlaceEnemy(1, 60, 7);
                }
                if (GameWorld.badKarmaButton.currentKarma > GameWorld.goodKarmaButton.currentKarma)
                {
                    PlaceEnemy(1, 16, 21);
                    PlaceEnemy(1, 2, 33);
                    PlaceEnemy(1, 16, 45);
                    PlaceEnemy(1, 43, 36);
                    PlaceEnemy(1, 80, 59);
                    PlaceEnemy(1, 86, 32);
                    PlaceEnemy(1, 28, 21);
                    PlaceEnemy(1, 36, 21);
                    PlaceEnemy(1, 46, 21);
                    PlaceEnemy(1, 56, 21);
                    PlaceEnemy(1, 86, 14);
                    PlaceEnemy(1, 36, 7);
                    PlaceEnemy(1, 60, 7);
                }
                if (GameWorld.badKarmaButton.currentKarma == GameWorld.goodKarmaButton.currentKarma)
                {
                    PlaceEnemy(3, 16, 21);
                    PlaceEnemy(3, 2, 33);
                    PlaceEnemy(3, 16, 45);
                    PlaceEnemy(3, 43, 36);
                    PlaceEnemy(3, 80, 59);
                    PlaceEnemy(3, 86, 32);
                    PlaceEnemy(3, 28, 21);
                    PlaceEnemy(3, 36, 21);
                    PlaceEnemy(3, 46, 21);
                    PlaceEnemy(3, 56, 21);
                    PlaceEnemy(3, 86, 14);
                    PlaceEnemy(3, 36, 7);
                    PlaceEnemy(3, 60, 7);
                }
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

                PlaceBlocks(2, 1, 3, 5, 2);
                PlaceBlocks(2, 1, 9, 7, 2);
                PlaceBlocks(2, 1, 15, 9, 2);
                PlaceBlocks(2, 1, 21, 11, 3);
                PlaceBlocks(2, 1, 27, 5, 4);
                PlaceBlocks(2, 1, 35, 11, 3);
                PlaceBlocks(2, 1, 43, 9, 2);
                PlaceBlocks(2, 1, 49, 7, 2);
                PlaceBlocks(2, 1, 55, 5, 2);

                PlaceBlocks(2, 1, 3, 13, 1);
                PlaceBlocks(2, 1, 7, 15, 2);
                PlaceBlocks(2, 1, 13, 17, 2);
                PlaceBlocks(2, 1, 19, 19, 2);
                PlaceBlocks(2, 1, 25, 21, 2);
                PlaceBlocks(2, 1, 33, 21, 2);
                PlaceBlocks(2, 1, 39, 19, 2);
                PlaceBlocks(2, 1, 45, 17, 2);
                PlaceBlocks(2, 1, 51, 15, 2);
                PlaceBlocks(2, 1, 57, 13, 1);


                // Lava
                PlaceBlocks(5, 2, 1, 1, 16);
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(5 * 64 + (i * 128), 1990), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(11 * 64 + (i * 128), 1990), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(19 * 64 + (i * 128), 1990), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(25 * 64 + (i * 128), 1990), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(33 * 64 + (i * 128), 1990), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(39 * 64 + (i * 128), 1990), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(47 * 64 + (i * 128), 1990), "SurfaceLava");
                }
                for (int i = 0; i < 2; i++)
                {
                    new Lava(new Vector2(53 * 64 + (i * 128), 1990), "SurfaceLava");
                }
                PlaceBlocks(5, 2, 59, 1, 16);

                // Chains
                PlaceBlocks(6, 2, 7, 0, 12);
                PlaceBlocks(6, 2, 11, 8, 16);
                PlaceBlocks(6, 2, 23, 12, 12);
                PlaceBlocks(6, 2, 27, 6, 10);
                PlaceBlocks(6, 2, 33, 6, 10);
                PlaceBlocks(6, 2, 37, 12, 12);
                PlaceBlocks(6, 2, 49, 8, 16);
                PlaceBlocks(6, 2, 53, 0, 12);

                // Boss
                if (GameWorld.badKarmaButton.currentKarma < GameWorld.goodKarmaButton.currentKarma)
                {
                    boss = new BossEnemy(4, 4, "DevilBoss");
                }
                else if (GameWorld.badKarmaButton.currentKarma > GameWorld.goodKarmaButton.currentKarma)
                {
                    boss = new BossEnemy(4, 4, "AngelBoss");
                }
                else if (GameWorld.badKarmaButton.currentKarma == GameWorld.goodKarmaButton.currentKarma)
                {
                    neutralBoss = new NeutralBoss();
                }
            }

            if (GameWorld.stage == 10)
            {
                MediaPlayer.Play(GameWorld.musicBoss);
            }
            else
            {
                MediaPlayer.Play(GameWorld.musicMain);
            }
        }

        /// <summary>
        /// A method for placing non animated gameobjects in a level
        /// </summary>
        /// <param name="s">The type of the platform. 1 = small, 2 = medium , 3 = big, 4 = Trapdoor, 5 = Lava, 6 = Chains</param>
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
                    name = "MediumBlock";
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
                else if (s == 6)
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
        /// <param name="x">Where on the x-axis, measured in times of 64, the enemy should be placed</param>
        /// <param name="y">Where on the y-axis, measured in times of 64, the enemy should be placed</param>
        private void PlaceEnemy(int t, int x, int y)
        {

            if (t == 1)
            {
                minorEnemy = new MinorEnemy(new Vector2(x * 64, y * 64), "SmallDevil");
            }
            else if (t == 2)
            {
                minorEnemy = new MinorEnemy(new Vector2(x * 64, y * 64), "SmallAngel");
            }
            else if (t == 3)
            {
                minorEnemy= new MinorEnemy(new Vector2(x * 64, y * 64), "NeutralEnemy");
            }
        }
    }

}