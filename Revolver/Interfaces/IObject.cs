using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Interface;
using Revolver.Objects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Interfaces
{
    internal interface IObject
    {
        Texture2D Texture { get; set; }
        public Vector2 MinPosition { get; set; }
        public Vector2 MaxPosition
        {
            get { return MinPosition + new Vector2(Width, Height); }
            set { MinPosition = value - new Vector2(Width, Height); }
        }
        public Vector2 Facing { get; set; }
        public List<Hitbox> Hitboxes { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, MinPosition, new Rectangle(0, 0, Width, Height), Color.Red);
            foreach (var hitbox in Hitboxes) { spriteBatch.Draw(hitbox.Texture, MinPosition + hitbox.Offset, hitbox.Box, Color.Blue); }
        }
    }
}