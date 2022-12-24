using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Reader;
using Revolver.Objects;
using System.Linq;

namespace Revolver.Managers
{
    internal static class ScreenManager
    {
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }
        private static UIReader menuController = new UIReader();
        internal static void Draw(SpriteBatch spriteBatch)
        {
            GameStateManager.CurrentScene().Draw(spriteBatch);
            foreach (BaseObject gObject in GameStateManager.gameObjects)
            {
                //handeld by BaseObject/Movable
                gObject.Draw(spriteBatch);
            }
        }

        internal static void Update(GameTime gameTime)
        {
            if (GameStateManager.UIToggle)
            {
                UIManager.Update(gameTime);
            }
            else
            {
                // TODO: Add your update logic here
                foreach (BaseObject gObject in GameStateManager.gameObjects.ToList())
                {
                    if (gObject is Movable movableObject)
                    {
                        //handeld by Movable
                        movableObject.Update(gameTime);
                    }
                }
            }
        }

        internal static void Load()
        {
            GameStateManager.gameObjects.Clear();
            GameStateManager.CurrentScene().LoadScene();
            GameStateManager.CurrentScene().LoadMap();
        }
    }
}
