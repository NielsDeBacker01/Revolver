using Revolver.Interfaces;

namespace Revolver.Controls.Run
{
    internal class StandardRun : IRun
    {
        public float TimeRunning { get; set; }
        public int Speed { get; set; }
        public float SpeedCap { get; set; }
        public float Acceleration { get; set; }

        public StandardRun(int Speed, float SpeedCap, float Acceleration)
        {
            TimeRunning = 0;
            this.Speed = Speed;
            this.SpeedCap = SpeedCap;
            this.Acceleration = Acceleration;
        }

        public float CalculateRun()
        {
            return Speed + Acceleration * TimeRunning > SpeedCap
                ? SpeedCap : Speed + Acceleration * TimeRunning;
        }
    }
}
