using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using Revolver.Objects.GameObjects;
using SharpDX.Direct2D1;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Revolver.Objects
{
    delegate void del(Vector2 position);
    internal abstract class BaseScene
    {
        public  Dictionary<char, del> objAbbreviation = new()
        {
            {'0', null },
            {'1', delegate(Vector2 position){ new Block(position); } }
        };

        public abstract void LoadScene();
        public abstract char[,] Map { get; set; }

        public void LoadMap()
        {
            if(Map != null)
            {
                for (int y = 0; y < Map.GetLength(1); y++)
                {
                    for (int x = 0; x < Map.GetLength(0); x++)
                    {
                        objAbbreviation[Map[x, y]](new Vector2(30 * x, 30 * y));
                    }
                }
            }
        }
    }
}
