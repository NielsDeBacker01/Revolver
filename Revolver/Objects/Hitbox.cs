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
                    return this.offset + new Vector2(parentWidth - this.Box.Width - 2 * (this.offset.X), 0);
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
        private bool flipped;
        private int parentWidth;

        public Hitbox(int width, int height, Vector2 offset)
        {
            this.Box = new Rectangle(0, 0, width, height);
            this.Offset = offset;
            Texture = new Texture2D(GameStateManager.graphics, 1, 1);
            Texture.SetData(new[] { Color.White });
            flipped = false;
            
        }

        public void Flip(DynamicObject parent)
        {
            if (parent.Facing.X > 0)
            {
                flipped = true;
                parentWidth = parent.Width;
            }
            else if (parent.Facing.X < 0)
            {
                flipped = false;
            }
        }
    }
}
