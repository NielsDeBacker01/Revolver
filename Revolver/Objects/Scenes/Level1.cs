﻿using Microsoft.Xna.Framework;
using Revolver.Objects.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Objects.Scenes
{
    internal class Level1 : BaseScene
    {
        public override char[,] Map { get; set; }

        public override void LoadScene()
        {
            new Player(new Vector2(1, 1));
            new Cactus(new Vector2(150, 450));
            new Cactus(new Vector2(450, 0));
            new Cactus(new Vector2(180, 450));
            new Cactus(new Vector2(600, 375));
            new Bandit(new Vector2(400, 200));
            new Gun(new Vector2(120, 400));
            new Gun(new Vector2(120, 50));
            new Gun(new Vector2(450, 50));
            new Block(new Vector2(70, 450));
        }
    }
}