using Microsoft.Xna.Framework.Graphics;
using Revolver.Objects;
using Revolver.Objects.Scenes;
using System.Collections.Generic;

namespace Revolver.Managers
{
    internal static class GameStateManager
    {
        public static bool UIToggle = false;
        public static List<BaseObject> gameObjects;
        public static GraphicsDevice graphics;
        private static List<BaseScene> LevelList = new()
        {
            new TitleScreen(),
            new Level1(),
            new Level2(),
            new GameOverScene()
        };
        public static int LevelIndex = 0;
        public static BaseScene CurrentScene()
        {
            return LevelList[LevelIndex];
        }
        public static void NextLevel(int index = -1)
        {
            if (index < 0)
            {
                LevelIndex++;
            }
            else
            {
                LevelIndex = index;
            }

            if (LevelIndex < 0 || LevelIndex >= LevelList.Count)
            {
                LevelIndex = 0;
            }

            ScreenManager.Load();
        }
    }
}