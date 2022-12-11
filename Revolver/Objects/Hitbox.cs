using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Interface;
using Revolver.Managers;

namespace Revolver.Objects
{
    internal class Hitbox
    {
        public Rectangle Box { get; set; }
        public Vector2 Offset { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Facing { get; set; }
        public Hitbox(int width, int height, Vector2 offset)
        {
            this.Box = new Rectangle(0, 0, width, height);
            this.Offset = offset;
            Texture = new Texture2D(GameStateManager.graphics, 1, 1);
            Texture.SetData(new[] { Color.White });
            this.Facing = new Vector2(1, 0);
        }

        public void Flip(Movable parent)
        {
            if (Facing.X != parent.Facing.X)
            {
                this.Offset += new Vector2(parent.Width - this.Box.Width - 2 * (this.Offset.X), 0);
                this.Facing *= new Vector2(-1, 0);
            }
        }
    }
}
