using Microsoft.Xna.Framework;
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
    internal class ShotMovement : IMovement
    {
        public MovementManager MovementManager { get; set; }
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public int GravityStrength { get; set; }
        public ShotMovement(Vector2 direction)
        {
            InputReader = new ConstantReader(direction);
            JumpManager = new NoJump();
            RunManager = new quadDirectionalRun(10, 10f, 0f);
            MovementManager = new MovementManager();
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