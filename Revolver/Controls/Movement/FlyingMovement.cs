using Revolver.Controls.Jump;
using Revolver.Controls.Reader;
using Revolver.Controls.Run;
using Revolver.Interface;
using Revolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Movement
{
    internal class FlyingMovement : IMovement
    {
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public int GravityStrength { get; set; }
        public FlyingMovement()
        {
            InputReader = new FlyReader();
            JumpManager = new NoJump();
            RunManager = new QuadDirectionalRun(3, 4f, 0.1f);
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
