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
        public  Dictionary<string, del> objAbbreviation = new()
        {
            {"0", null },
            {"1", delegate(Vector2 position){ new Block(position); } }
        };

        public abstract void LoadScene();
        public abstract string[,] Map { get; set; }

        public void LoadMap()
        {
            if(Map != null)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    for (int y = 0; y < Map.GetLength(0); y++)
                    {
                        if(objAbbreviation[Map[y, x]] != null)
                        {
                            objAbbreviation[Map[y, x]].DynamicInvoke(new Vector2(30 * x, 30 * y));
                        }     
                    }
                }
            }
        }
    }
}
