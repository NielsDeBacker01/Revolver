using Microsoft.Xna.Framework;
using Revolver.Interface;
using Revolver.Objects;
using System;

namespace Revolver.Controls.Reader
{
    internal class AiReader : IInputReader
    {
        private DynamicObject self;
        private DynamicObject tracker;
        public Vector2 ReadInput()
        {
            Vector2 direction = Vector2.Zero;

            //stabilize when directly underneath
            if (Math.Abs(self.MinPosition.X - tracker.MinPosition.X) > tracker.Width / 2)
            {
                if (self.MinPosition.X < tracker.MinPosition.X)
                {
                    direction.X += 1;
                }
                else if (self.MinPosition.X > tracker.MinPosition.X)
                {
                    direction.X += -1;
                }
            }
            return direction;
        }

        public AiReader(DynamicObject self, DynamicObject tracker = null)
        {
            this.self = self;
            this.tracker = tracker;
        }
    }
}