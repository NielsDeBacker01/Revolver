using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Objects;
using Revolver.Objects.Scenes;
using Revolver.Scenes;
using System.Collections.Generic;

namespace Revolver.Managers
{
    internal static class GameStateManager
    {
        public static bool UIToggle = false;
        public static List<BaseObject> gameObjects;
        public static List<GameElement> gameElements;
        public static GraphicsDevice graphics;
        public static ContentManager content;
        public static SpriteFont Font;
        public static bool loading;
        private static List<BaseScene> LevelList = new()
        {
            new TitleScreen(),
            new Level1(),
            new Level2(),
            new Level3(),
            new Level4(),
            new Level5(),
            new GameOverScene()
        };
        public static int LevelIndex = 0;
        private static int currentLevel;
        public static BaseScene CurrentScene()
        {
            return LevelList[LevelIndex];
        }
        public static void NextLevel(int index = -1)
        {
            if (index < 0)
            {
                if (LevelIndex == 5)
                {
                    LevelIndex = 0;
                } else 
                if (LevelIndex == 6) 
                {
                    LevelIndex = currentLevel;
                } else
                {
                    LevelIndex++;
                }
            }
            else if (index == 6)
            {
                currentLevel = LevelIndex;
                LevelIndex = index;
            }
            else
            {
                LevelIndex = index;
            }

            ScreenManager.Load();
        }

        public static void Remove(GameElement removable)
        {
            gameElements.Remove(removable);
            if (removable is BaseObject removable2) 
            {
                gameObjects.Remove(removable2);
            }
        }
    }
}