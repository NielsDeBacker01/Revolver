using Revolver.Interfaces;

namespace Revolver.Controls.Jump
{
    internal class NoJump : IJump
    {
        public int JumpHeight { get; set; }
        public float JumpTime { get; set; }
        public bool IsJumping { get; set; }
        public float AirTime { get; set; }

        public float CalculateJump()
        {
            return 0;
        }

        public NoJump()
        {
            JumpHeight = 0;
            JumpTime = 0;
            IsJumping = false;
            AirTime = 0;
        }
    }
}
