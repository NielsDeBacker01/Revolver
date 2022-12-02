using Revolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Run
{
    internal class quadDirectionalRun : IRun
    {
        public float TimeRunning { get; set; }
        public int Speed { get; set; }
        public float SpeedCap { get; set; }
        public float Acceleration { get; set; }

        public quadDirectionalRun(int Speed, float SpeedCap, float Acceleration)
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
