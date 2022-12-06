namespace Revolver.Interfaces
{
    internal interface IRun
    {
        public float TimeRunning { get; set; }
        public float Speed { get; set; }
        public float SpeedCap { get; set; }
        public float Acceleration { get; set; }
        public float CalculateRun();
    }
}