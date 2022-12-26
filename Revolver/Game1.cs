using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Revolver.Managers;
using Revolver.Objects;
using System.Collections.Generic;

namespace Revolver
{
    public enum Tag { Mortal, Deadly, Loadable };
    public enum status { Idle, Walking };
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            GameStateManager.gameObjects = new List<BaseObject>();
            GameStateManager.gameElements = new List<GameElement>();
            GameStateManager.graphics = GraphicsDevice;
            GameStateManager.content = this.Content;
            GameStateManager.LevelIndex = 0;
            GameStateManager.Font = Content.Load<SpriteFont>("Text");
            AnimationManager.Load();
            ScreenManager.ScreenWidth = Window.ClientBounds.Width;
            ScreenManager.ScreenHeight = Window.ClientBounds.Height;
            ScreenManager.Load();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            ScreenManager.Update(gameTime);
            base.Update(gameTime);

            //tester
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.T))
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);
            _spriteBatch.Begin();
            ScreenManager.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}