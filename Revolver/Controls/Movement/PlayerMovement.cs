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
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public int GravityStrength { get; set; }
        public PlayerMovement()
        {
            InputReader = new KeyboardReader();
            JumpManager = new StandardParabolicJump(100, 0.75f);
            RunManager = new Standard2DRun(8, 12f, 0.1f);
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
