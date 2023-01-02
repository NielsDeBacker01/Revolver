using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Bullet : DynamicObject
    {
        public DynamicObject Origin;

        public Bullet(Vector2 position, Vector2 facing, DynamicObject origin)
        {
            Tags = new HashSet<Tag>
            {
                Tag.Deadly
            };

            Texture = GameStateManager.content.Load<Texture2D>("bullet");
            MinPosition = position;
            Weight = 0;
            Movement = new ShotMovement(facing);
            Origin = origin;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (CollisionManager.IsCollidingWithBoundaries(this) || !GameStateManager.gameObjects.Contains(Origin))
            {
                GameStateManager.Remove(this);
            }
        }

        public override bool Interaction(BaseObject gameObject)
        {
            if (gameObject == Origin || gameObject is Player)
            {
                if (gameObject is Player)
                {
                    GameStateManager.Remove(this);
                }
                return false;
            }
            GameStateManager.Remove(this);
            return true;
        }
    }
}
