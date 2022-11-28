using Revolver.Controls.Jump;
using Revolver.Controls.Reader;
using Revolver.Controls.Run;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Movement
{
    internal class NoMovement : IMovement
    {
        public MovementManager MovementManager { get; set; }
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public NoMovement()
        {
            InputReader = new EmptyReader();
            JumpManager = new NoJump();
            RunManager = new NoRun();
            MovementManager = new MovementManager();
        }
        public void ResetMovement()
        {
            //does nothing
        }
    }
}
