using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using SharpDX.DirectWrite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Revolver.Objects
{
    internal class Hitbox
    {
        public Rectangle Box { get; set; }
        public Vector2 Offset
        {
            get
            {
                if (flipped)
                {
                    return offsetFlipped;
                }
                else
                {
                    return offset;
                }
            }
            set
            {
                offset = value;
            }
        }
        public Texture2D Texture { get; set; }
        private Vector2 offset;
        private Vector2 offsetFlipped;
        private bool flipped;

        public Hitbox(int width, int height, Vector2 offset)
        {
            this.Box = new Rectangle(0, 0, width, height);
            this.Offset = offset;
            Texture = new Texture2D(GameStateManager.graphics, 1, 1);
            Texture.SetData(new[] { Color.White });
            flipped = false;
            offsetFlipped = Vector2.Zero;
        }

        public void Flip(DynamicObject parent)
        {
            if (parent.Facing.X > 0)
            {
                flipped = true;
                if(offsetFlipped.Y == 0)
                {
                    offsetFlipped = this.offset + new Vector2(parent.Width - this.Box.Width - 2 * (this.offset.X), 1);
                }
            }
            else if (parent.Facing.X < 0)
            {
                flipped = false;
            }
        }
    }
}
