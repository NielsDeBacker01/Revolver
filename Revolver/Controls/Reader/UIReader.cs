using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Revolver.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Controls.Reader
{
    internal class UIReader
    {
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Enter))
            {
                GameStateManager.NextLevel();
            }
            if (state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.Up))
            {
                direction.Y += -1;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
            }
            return direction;
        }
    }
}