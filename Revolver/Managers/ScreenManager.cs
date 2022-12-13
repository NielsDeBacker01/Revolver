using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Objects;
using System.Linq;
using System;

namespace Revolver.Managers
{
    internal static class ScreenManager
    {
        internal static void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseObject gObject in GameStateManager.gameObjects)
            {
                //handeld by BaseObject/Movable
                gObject.Draw(spriteBatch);
            }
        }

        internal static void Update(GameTime gameTime)
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

        internal static void Load()
        {
            GameStateManager.gameObjects.Clear();
            GameStateManager.currentScene.LoadScene();
            GameStateManager.currentScene.LoadMap();
        }
    }
}
