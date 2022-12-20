using Revolver.Controls.Jump;
using Revolver.Controls.Reader;
using Revolver.Controls.Run;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;

namespace Revolver.Controls.Movement
{
    internal class NoMovement : IMovement
    {
        public MovementManager MovementManager { get; set; }
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public int GravityStrength { get; set; }
        public NoMovement()
        {
            InputReader = new EmptyReader();
            JumpManager = new NoJump();
            RunManager = new NoRun();
            MovementManager = new MovementManager();
            GravityStrength = 0;
        }
        public void ResetMovement()
        {
            //does nothing
        }
    }
}
