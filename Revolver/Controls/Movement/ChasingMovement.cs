using Revolver.Controls.Jump;
using Revolver.Controls.Reader;
using Revolver.Controls.Run;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using Revolver.Objects;

namespace Revolver.Controls.Movement
{
    internal class ChasingMovement : IMovement
    {
        public MovementManager MovementManager { get; set; }
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public int GravityStrength { get; set; }
        public ChasingMovement(Movable self, Movable tracker)
        {
            InputReader = new AiReader(self, tracker);
            JumpManager = new NoJump();
            RunManager = new Standard2DRun(3, 4f, 0.1f);
            MovementManager = new MovementManager();
            GravityStrength = 1;
        }
        public void ResetMovement()
        {
            JumpManager.AirTime = 0;
            RunManager.TimeRunning = 0;
            JumpManager.IsJumping = false;
            GravityStrength = 1;
        }
    }
}
