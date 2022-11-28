using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Interface;
using SharpDX.WIC;

namespace Revolver.Objects
{
    internal class Hitbox
    {
        public Rectangle Box { get; set; }
        public Vector2 Offset { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Facing { get; set; }
        public Hitbox(int width, int height, Vector2 offset, Texture2D texture)
        {
            this.Box = new Rectangle(0, 0, width, height);
            this.Offset = offset;
            this.Texture = texture;
            this.Facing = new Vector2(1, 0);
        }

        public void Flip(IMovable parent)
        {
            if(Facing.X != parent.Facing.X)
            {
                this.Offset += new Vector2(parent.Width - this.Box.Width - 2*(this.Offset.X), 0);
                this.Facing *= new Vector2(-1,0);
            }
        }
    }
}
