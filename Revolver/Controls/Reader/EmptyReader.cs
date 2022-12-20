using Microsoft.Xna.Framework;
using Revolver.Interface;

namespace Revolver.Controls.Reader
{
    internal class EmptyReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            return Vector2.Zero;
        }
    }
}
