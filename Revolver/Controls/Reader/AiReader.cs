using Microsoft.Xna.Framework;
using Revolver.Interface;
using Revolver.Objects;
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
        private Movable self;
        private Movable tracker;
        public Vector2 ReadInput()
        {
            Vector2 direction = Vector2.Zero;

            //stabilize when directly underneath
            if(Math.Abs(self.MinPosition.X - tracker.MinPosition.X) > 1)
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

        public AiReader(Movable self, Movable tracker = null)
        {
            this.self = self;
            this.tracker = tracker;
        }
    }
}