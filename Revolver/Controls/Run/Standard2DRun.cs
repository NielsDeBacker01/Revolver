using Revolver.Interfaces;

namespace Revolver.Controls.Run
{
    internal class Standard2DRun : IRun
    {
        public float TimeRunning { get; set; }
        public int Speed { get; set; }
        public float SpeedCap { get; set; }
        public float Acceleration { get; set; }

        public Standard2DRun(int Speed, float SpeedCap, float Acceleration)
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
