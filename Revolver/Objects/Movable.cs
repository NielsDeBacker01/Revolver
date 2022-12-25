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

        public bool InteractWith(BaseObject gameObject)
        {
            bool interact = Interaction(gameObject);
            if (interact)
            {
                if (this.Tags.Contains(Tag.Mortal) && gameObject.Tags.Contains(Tag.Deadly))
                {
                    if (!(this is Bandit && gameObject is Cactus))
                    {
                        GameStateManager.Remove(this);
                        return false;
                    }
                }

                if (this.Tags.Contains(Tag.Deadly) && gameObject.Tags.Contains(Tag.Mortal))
                {
                    if (gameObject is Player player)
                    {
                        player.Respawn();
                    }
                    else
                    {
                        GameStateManager.Remove(gameObject);
                    }
                    return false;
                }
            }
            return interact;
        }

        public abstract bool Interaction(BaseObject gameObject);

    }
}
