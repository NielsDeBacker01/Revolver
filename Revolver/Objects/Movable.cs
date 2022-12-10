using Microsoft.Xna.Framework;
using Revolver.Interfaces;
using Revolver.Managers;

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
        public virtual bool Interaction(BaseObject gameObject)
        {
            return true;
        }
    }
}
