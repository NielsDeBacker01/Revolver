using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Objects;
using System.Collections.Generic;

namespace Revolver.Managers
{
    internal static class GameStateManager
    {
        public static List<BaseObject> gameObjects;
        public static BaseScene currentScene;
        public static GraphicsDevice graphics;
    }
}
