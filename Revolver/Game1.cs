using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Revolver.Interface;
using Revolver.Managers;
using Revolver.Objects;
using Revolver.Objects.GameObjects;
using Revolver.Objects.Scenes;
using System.Collections.Generic;
using System.Linq;

namespace Revolver
{
    public enum Tag { Mortal, Deadly, Loadable }
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
            GameStateManager.gameObjects = new List<BaseObject>();
            GameStateManager.graphics = GraphicsDevice;
            new Player(new Vector2(1, 1));
            new Cactus(new Vector2(150, 450));
            new Cactus(new Vector2(450, 0));
            new Cactus(new Vector2(180, 450));
            new Cactus(new Vector2(600, 375));
            new Bandit(new Vector2(400, 200));
            new Gun(new Vector2(120, 400));
            new Gun(new Vector2(120, 50));
            new Gun(new Vector2(450, 50));
            new Block(new Vector2(70, 450));
            GameStateManager.currentScene = new Level1();
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
            foreach (BaseObject gObject in GameStateManager.gameObjects.ToList())
            {
                if (gObject is Movable movableObject)
                {
                    //handeld by IGameObject
                    movableObject.Update(gameTime);
                }
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
            foreach (BaseObject gObject in GameStateManager.gameObjects)
            {
                //handeld by BaseObject/Movable
                gObject.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}