using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Block : BaseObject
    {
        public bool IsWall { get; set; }
        public Block(Vector2 position)
        {
            Texture = GameStateManager.content.Load<Texture2D>("Tileset");
            Facing = new Vector2(0, 0);
            MinPosition = position;
        }
    }
}