using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Goal : BaseObject
    {
        public Goal(Vector2 position)
        {
            Texture = new Texture2D(GameStateManager.graphics, 1, 1);
            Texture.SetData(new[] { Color.White });
            Facing = new Vector2(0, 0);
            MinPosition = position;
        }
    }
}
