using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using Revolver.Objects.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Objects
{
    delegate void del(Texture2D texture, Vector2 position);
    internal class BaseScene
    {
        internal Dictionary<char, del> objAbbreviation = new Dictionary<char, del>
        {
            {'0', delegate(Texture2D texture, Vector2 position){ } },
            {'1', delegate(Texture2D texture, Vector2 position){ new Block(texture, position); } },
            {'C', delegate(Texture2D texture, Vector2 position){ new Cactus(texture, position); } },
            {'P', delegate(Texture2D texture, Vector2 position){ new Player(texture, position); } },
            {'B', delegate(Texture2D texture, Vector2 position){ new Bandit(texture, position); } },
            {'G', delegate(Texture2D texture, Vector2 position){ new Gun(texture, position); } }
        };
        public void LoadMap(char[,] map)
        {
            foreach(char tile in map)
            {

            }
        }
    }
}
