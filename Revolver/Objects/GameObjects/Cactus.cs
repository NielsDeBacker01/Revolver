using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Cactus : BaseObject
    {
        public Cactus(Vector2 position)
        {
            Tags = new HashSet<Tag>
            {
                Tag.Deadly
            };
            Texture = GameStateManager.content.Load<Texture2D>("Cactus");
            Facing = new Vector2(0, 0);
            MinPosition = position;
        }
    }
}