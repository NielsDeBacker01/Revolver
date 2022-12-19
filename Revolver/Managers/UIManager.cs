using Microsoft.Xna.Framework;
using Revolver.Controls.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Managers
{
    internal static class UIManager
    {
        private static UIReader menuControls = new UIReader();
        private static int UIPosition;
        private static int Cooldown; 
        public static void Update(GameTime gameTime)
        {
            if(Cooldown < 0)
            {
                Vector2 input = menuControls.ReadInput();
                Cooldown = 15;
            }
            Cooldown--;
        }
    }
}
