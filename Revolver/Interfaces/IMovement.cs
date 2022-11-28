using Microsoft.Xna.Framework;
using Revolver.Interface;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Interfaces
{
    internal interface IMovement
    {
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public void ResetMovement();
    }
}
