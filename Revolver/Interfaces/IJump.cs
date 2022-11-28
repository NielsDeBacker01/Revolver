namespace Revolver.Interfaces
{
    internal interface IJump
    {
        public int JumpHeight { get; set; }
        public float JumpTime { get; set; }
        public float AirTime { get; set; }
        public bool IsJumping { get; set; }
        public float CalculateJump();
    }
}
