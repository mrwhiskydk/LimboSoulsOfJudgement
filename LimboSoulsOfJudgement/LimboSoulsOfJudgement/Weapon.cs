﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LimboSoulsOfJudgement
{
    public class Weapon : GameObject
    {
        public Weapon(Vector2 startPosition, string spriteName) : base(startPosition, spriteName)
        {
        }
    }
}