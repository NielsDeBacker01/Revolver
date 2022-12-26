using Microsoft.Xna.Framework;
using Revolver.Controls.Jump;
using Revolver.Controls.Reader;
using Revolver.Controls.Run;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;

namespace Revolver.Controls.Movement
{
    internal class ShotMovement : IMovement
    {
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public int GravityStrength { get; set; }
        public ShotMovement(Vector2 direction, float speed = 7f)
        {
            InputReader = new ConstantReader(direction);
            JumpManager = new NoJump();
            RunManager = new quadDirectionalRun(speed, speed, 0f);
            GravityStrength = 0;
        }
        public void ResetMovement()
        {
            JumpManager.AirTime = 0;
            RunManager.TimeRunning = 0;
            JumpManager.IsJumping = false;
            GravityStrength = 0;
        }
    }
}