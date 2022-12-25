using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Objects
{
    internal abstract class GameElement
    {
        public Vector2 MinPosition { get; set; }
        public Vector2 MaxPosition
        {
            get { return MinPosition + new Vector2(Width, Height); }
            set { MinPosition = value - new Vector2(Width, Height); }
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public abstract void Draw(SpriteBatch spriteBatch);

        public GameElement()
        {
            GameStateManager.gameElements.Add(this);
        }
    }
}
