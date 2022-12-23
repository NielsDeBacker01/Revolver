using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Block : BaseObject
    {
        public Block(Vector2 position)
        {
            Texture = GameStateManager.content.Load<Texture2D>("Tileset");
            Facing = new Vector2(0, 0);
            Width = 30;
            Height = 30;
            MinPosition = position;
            spriteX = 96;
            spriteY = 96;
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0))
            };
        }
    }
}