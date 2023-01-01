using Revolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Run
{
    internal class QuadDirectionalRun : IRun
    {
        public float TimeRunning { get; set; }
        public float Speed { get; set; }
        public float SpeedCap { get; set; }
        public float Acceleration { get; set; }

        public QuadDirectionalRun(float Speed, float SpeedCap, float Acceleration)
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
