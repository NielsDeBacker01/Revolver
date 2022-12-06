using Microsoft.Xna.Framework;
using Revolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Run
{
    internal class NoRun : IRun
    {
        public float TimeRunning { get; set; }
        public float Speed { get; set; }
        public float SpeedCap { get; set; }
        public float Acceleration { get; set; }

        public NoRun()
        {
            TimeRunning = 0;
            Speed = 0;
            SpeedCap = 12f;
            Acceleration = 0.1f;
        }

        public float CalculateRun()
        {
            return 0f;
        }
    }
}
