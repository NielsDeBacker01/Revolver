using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
