using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LimboSoulsOfJudgement
{
    public class Level
    {
        public Level()
        {
            //Platforms
            for (int i = 0; i < 3; i++)
            {
                new Platform(new Vector2(128 + i * 256, 768), "BigBlock");
            }            
            for (int i = 0; i < 9; i++)
            {
                new Platform(new Vector2(128 + i * 256, 1024), "BigBlock");
            }
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
            new Platform(new Vector2((74 * 64), (52 * 64)), "SmallBlock");
            new Platform(new Vector2((75 * 64), (52 * 64)), "SmallBlock");
            new Platform(new Vector2((77 * 64), (48 * 64)), "SmallBlock");
            new Platform(new Vector2((78 * 64), (48 * 64)), "SmallBlock");
            new Platform(new Vector2((84 * 64), (48 * 64)), "SmallBlock");
            new Platform(new Vector2((85 * 64), (48 * 64)), "SmallBlock");
            new Platform(new Vector2(9 * 64, 27 * 64), "MediumBlock");
            new Platform(new Vector2(39 * 64, 11 * 64), "MediumBlock");
            new Platform(new Vector2(44 * 64, 11 * 64), "MediumBlock");
            new Platform(new Vector2(3776, 768), "MediumBlock");
            new Platform(new Vector2(3392, 704), "MediumBlock");
            new Platform(new Vector2(3520, 704), "MediumBlock");
            new Platform(new Vector2(1664, 768), "BigBlock");
            new Platform(new Vector2(1920, 768), "BigBlock");
            new Platform(new Vector2(2112, 832), "MediumBlock");
            new Platform(new Vector2(960, 448), "MediumBlock");
            new Platform(new Vector2(1344, 448), "MediumBlock");



            // Trapdoor
            new Platform(new Vector2(63 * 64, 43 * 64), "MediumBlock");
            new Platform(new Vector2(65 * 64, 43 * 64), "MediumBlock");

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
                new Lava(new Vector2((13*64) + i * 128, (11 * 64)),"MediumLava");
            }
            for (int i = 0; i < 6; i++)
            {
                new Lava(new Vector2((13 * 64) + i * 128, (13 * 64)), "MediumLava");
            }
            for (int i = 0; i < 13; i++)
            {
                new Lava(new Vector2((55 * 64) + i * 128, (33 * 64)), "MediumLava");
            }

            //first "cave" entrance
            for (int i = 0; i < 6; i++)
            {
                
            }



            new Platform(new Vector2(-512, 2048), "VerticalFrame");
            new Platform(new Vector2(6272, 2048), "VerticalFrame");
            new Platform(new Vector2(2880, 4096), "HorizontalFrame");
            new Platform(new Vector2(2880, -512), "HorizontalFrame");
        }
    }
}