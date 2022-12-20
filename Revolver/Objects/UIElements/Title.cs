﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;

namespace Revolver.Objects.UIElements
{
    internal class Title : BaseObject
    {
        public Title(Vector2 position)
        {
            Texture = new Texture2D(GameStateManager.graphics, 1, 1);
            Texture.SetData(new[] { Color.White });
            Facing = new Vector2(0, 0);
            Width = 240;
            Height = 100;
            MinPosition = position;
        }
    }
}