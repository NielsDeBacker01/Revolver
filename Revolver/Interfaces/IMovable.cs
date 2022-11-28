using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Interfaces;
using Revolver.Managers;
using Revolver.Objects;
using SharpDX.Direct2D1;
using System.Collections.Generic;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Revolver.Interface
{
    internal interface IMovable : IObject
    {
        public IMovement Movement { get; set; }
        public int Weight { get; set; }
        public void Update(GameTime gameTime, List<IMovable> gameObjects) 
        { MovementManager.Move(this, gameTime, gameObjects); 
          foreach (var hitbox in Hitboxes) {hitbox.Flip(this);}}
        int Interaction(IMovable gameObject);
    }
}
