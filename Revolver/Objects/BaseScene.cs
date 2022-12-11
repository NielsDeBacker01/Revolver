using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Objects.GameObjects;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Revolver.Objects
{
    delegate void del(Texture2D texture, Vector2 position);
    internal abstract class BaseScene
    {
        public  Dictionary<char, del> objAbbreviation = new()
        {
            {'0', null },
            {'1', delegate(Texture2D texture, Vector2 position){ new Block(position); } }
        };

        public abstract void LoadScene();

        public void DrawScene(char[,] map)
        {
            foreach(char tile in map)
            {

            }
        }
    }
}
