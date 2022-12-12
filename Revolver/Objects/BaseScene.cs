using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using Revolver.Objects.GameObjects;
using SharpDX.Direct2D1;
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

        public void DrawScene(SpriteBatch spriteBatch)
        {
            /*
            foreach(char tile in Map)
            {
                objAbbreviation[tile](new Vector2(1,1));
            }
            */

            foreach (BaseObject gObject in GameStateManager.gameObjects)
            {
                //handeld by BaseObject/Movable
                gObject.Draw(spriteBatch);
            }
        }
    }
}
