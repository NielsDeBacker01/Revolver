using Revolver.Interfaces;

namespace Revolver.Controls.Jump
{
    internal class StandardParabolicJump : IJump
    {
        public int JumpHeight { get; set; }
        public float JumpTime { get; set; }
        public bool IsJumping { get; set; }
        public float AirTime { get; set; }

        public float CalculateJump()
        {
            float a = 4 * JumpHeight / JumpTime;
            float b = -2.0f / JumpTime;
            return a * (b * AirTime + 1);
        }

        public StandardParabolicJump(int JumpHeight, float AirTime)
        {
            this.JumpHeight = JumpHeight;
            this.JumpTime = AirTime;
            IsJumping = false;
            AirTime = 0;
        }
    }
}