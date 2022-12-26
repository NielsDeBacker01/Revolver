using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using Revolver.Objects.GameObjects;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace Revolver.Objects.Scenes
{
    delegate void del(Vector2 position);
    internal abstract class BaseScene
    {
        public Dictionary<string, del> objAbbreviation = new()
        {
            {"0", null },
            {"1", delegate(Vector2 position){ new Block(position); } },
            {"G", delegate(Vector2 position){ new Goal(position); } },
            {"C", delegate(Vector2 position){ new Cactus(position); } }
        };

        public abstract void LoadScene();
        public string[,] Map { get; set; }
        public Texture2D Background { get; set; }

        public void LoadMap()
        {
            if (Map != null)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    for (int y = 0; y < Map.GetLength(0); y++)
                    {
                        if (objAbbreviation[Map[y, x]] != null)
                        {
                            var newObject = objAbbreviation[Map[y, x]].DynamicInvoke(new Vector2(30 * x, 30 * y));
                            if(y != 0 && newObject is Block newBlock && Map[y-1, x] != "0")
                            {
                                newBlock.IsWall = true;
                            }
                        }
                    }
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(Background != null)
            {
                spriteBatch.Draw(Background, new Rectangle(0, 0, ScreenManager.ScreenWidth, ScreenManager.ScreenHeight), new Rectangle(0, 0, Background.Width, Background.Height), Color.White);
            }
        }
    }
}
