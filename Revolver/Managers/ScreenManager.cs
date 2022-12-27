using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Reader;
using Revolver.Interfaces;
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
            foreach (GameElement gElement in GameStateManager.gameElements)
            {
                //handeld by BaseObject/Movable
                gElement.Draw(spriteBatch);
            }
            GameStateManager.loading = false;
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
                    if (gObject is DynamicObject movableObject)
                    {
                        //handeld by Movable
                        movableObject.Update(gameTime);
                    }
                    if (gObject is IAnimate animatable)
                    {
                        if(animatable.holdFrame <= 0)
                        {
                            gObject.currentFrame = AnimationManager.getCurrentFrame(animatable.currentFrameIndex, gObject);
                        }else
                        {
                            animatable.holdFrame--;
                        }
                        
                    }
                }
            }
        }

        internal static void Load()
        {
            if (!GameStateManager.loading) 
            {
                GameStateManager.loading = true;
                GameStateManager.gameObjects.Clear();
                GameStateManager.gameElements.Clear();
                GameStateManager.CurrentScene().LoadScene();
                GameStateManager.CurrentScene().LoadMap();
            }
        }
    }
}
