using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Objects;
using Revolver.Objects.Scenes;
using System.Collections.Generic;

namespace Revolver.Managers
{
    internal static class GameStateManager
    {
        public static List<BaseObject> gameObjects;
        public static GraphicsDevice graphics;
        private static List<BaseScene> LevelList = new()
        {
            new Level1(),
            new Level2(),
        };
        public static int LevelIndex = 0;
        public static BaseScene CurrentScene()
        {
            return LevelList[LevelIndex];
        }
    }
}
