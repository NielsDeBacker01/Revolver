using Microsoft.Xna.Framework;
using Revolver.Interface;
using Revolver.Objects.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Reader
{
    internal class AiReader : IInputReader
    {
        private IMovable self;
        private IMovable tracker;
        public Vector2 ReadInput()
        {
            Vector2 direction = Vector2.Zero;

            if (self.MinPosition.X < tracker.MinPosition.X)
            {
                direction.X += 1;
            }
            else if (self.MinPosition.X > tracker.MinPosition.X)
            {
                direction.X += -1;
            }
            return direction;
        }

        public AiReader(IMovable self, IMovable tracker = null)
        {
            this.self = self;
            this.tracker = tracker;
        }
    }
}