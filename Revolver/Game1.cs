using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using Revolver.Objects;
using Revolver.Objects.GameObjects;
using System.Collections.Generic;
using System.Linq;

namespace Revolver
{
    public enum Tag { Mortal, Deadly, Loadable}
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _playerTexture;
        private Texture2D _cactusTexture;
        private Texture2D _banditTexture;
        private Texture2D _blokTexture;
        private Texture2D _bulletTexture;
        private Texture2D _gunTexture;

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
            GameStateManager.gameObjects = new List<IMovable>();
            GameStateManager.gameObjects.Add(new Player(_playerTexture));
            GameStateManager.gameObjects.Add(new Cactus(_cactusTexture, new Vector2(150, 450)));
            GameStateManager.gameObjects.Add(new Cactus(_cactusTexture, new Vector2(150, 100)));
            GameStateManager.gameObjects.Add(new Cactus(_cactusTexture, new Vector2(180, 450)));
            GameStateManager.gameObjects.Add(new Cactus(_cactusTexture, new Vector2(600, 375)));
            GameStateManager.gameObjects.Add(new Bandit(_banditTexture, new Vector2(400, 200)));
            GameStateManager.gameObjects.Add(new Gun(_gunTexture, new Vector2(100,400)));
            GameStateManager.gameObjects.Add(new Gun(_gunTexture, new Vector2(450, 400)));
        }

        protected override void LoadContent()
        {
            _blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blokTexture.SetData(new[] { Color.White });
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _playerTexture = _blokTexture;
            _cactusTexture = _blokTexture;
            _banditTexture = _blokTexture;
            _bulletTexture = _blokTexture;
            _gunTexture = _blokTexture;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (IMovable gObject in GameStateManager.gameObjects.ToList())
            {
                //handeld by IGameObject
                gObject.Update(gameTime);
            }
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
            GraphicsDevice.Clear(Color.Honeydew);
            _spriteBatch.Begin();
            foreach (IMovable gObject in GameStateManager.gameObjects)
            {
                //handeld by IGameObject
                gObject.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}