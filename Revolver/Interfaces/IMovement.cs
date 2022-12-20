using Revolver.Interface;

namespace Revolver.Interfaces
{
    internal interface IMovement
    {
        public IInputReader InputReader { get; set; }
        public IJump JumpManager { get; set; }
        public IRun RunManager { get; set; }
        public int GravityStrength { get; set; }
        public void ResetMovement();
    }
}
