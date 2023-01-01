using Microsoft.Xna.Framework;
using Revolver.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Reader
{
    internal class FlyReader : IInputReader
    {
        Vector2 direction;
        private int timeMoving;
        public Vector2 ReadInput()
        {
            if(timeMoving > 50)
            {
                direction *= -1;
                timeMoving = 0;
            }
            timeMoving++;
            return direction;
        }

        public FlyReader()
        {
            direction = new Vector2(0, -1);
            timeMoving = 0;
        }
    }
}
