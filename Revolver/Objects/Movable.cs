using Microsoft.Xna.Framework;
using Revolver.Interfaces;
using Revolver.Managers;
using Revolver.Objects.GameObjects;

namespace Revolver.Objects
{
    internal abstract class Movable : BaseObject
    {
        public IMovement Movement { get; set; }
        public int Weight { get; set; }
        public virtual void Update(GameTime gameTime)
        {
            MovementManager.Move(this, gameTime);
            foreach (var hitbox in Hitboxes) { hitbox.Flip(this); }
        }
    }
}
