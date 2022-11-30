using Revolver.Controls.Jump;
using Revolver.Controls.Reader;
using Revolver.Controls.Run;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;

namespace Revolver.Controls.Movement
{
    internal class PlayerMovement : IMovement
    {
        public MovementManager MovementManager { get; set; }
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public int GravityStrength { get; set; }
        public PlayerMovement()
        {
            InputReader = new KeyboardReader();
            JumpManager = new StandardParabolicJump(120, 0.75f);
            RunManager = new StandardRun(8, 12f, 0.1f);
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
