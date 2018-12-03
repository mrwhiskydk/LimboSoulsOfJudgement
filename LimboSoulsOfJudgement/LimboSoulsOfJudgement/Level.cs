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
            //starting floor
            for (int i = 0; i < 20; i++)
            {
                new Platform(new Vector2((i * 128), 2048), "MediumBlock");
            }
            //left wall starting floor
            for (int i = 0; i < 5; i++)
            {
                new Platform(new Vector2(0, 2048 - 128 * i), "MediumBlock");
            }
            //first enemy
            new MinorEnemy(new Vector2(1700, 1800));
            //first "cave" entrance
            for (int i = 0; i < 6; i++)
            {
                new Platform(new Vector2(2432 + 128 * i,2176), "MediumBlock");
            }
        }
    }
}