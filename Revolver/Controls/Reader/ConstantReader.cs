using Microsoft.Xna.Framework;
using Revolver.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Reader
{
    internal class ConstantReader : IInputReader
    {
        Vector2 direction;
        public Vector2 ReadInput()
        {
            return direction;
        }

        public ConstantReader(Vector2 direction)
        {
            this.direction = direction;
        }
    }
}
