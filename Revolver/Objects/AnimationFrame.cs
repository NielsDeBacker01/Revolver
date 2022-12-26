using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Objects
{
    internal class AnimationFrame
    {
        public List<Hitbox> Hitboxes { get; set; }
        public Rectangle frame { get; set; }

        public AnimationFrame(List<Hitbox> hitboxes, int spriteX, int spriteY, int dimensionsX, int dimensionsY)
        {
            Hitboxes = hitboxes;
            frame = new Rectangle(spriteX, spriteY, dimensionsX, dimensionsY);
        }
    }
}