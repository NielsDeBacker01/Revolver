using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Interfaces;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Player : DynamicObject, IAnimate
    {
        private bool delayedInteraction = false;
        public int currentFrameIndex { get; set; }
        public int holdFrame { get; set; }

        public Player(Vector2 position)
        {
            scale = 2;
            Tags = new HashSet<Tag>
            {
                Tag.Mortal,
                Tag.Loadable
            };
            Movement = new PlayerMovement();
            MinPosition = position;
            Texture = GameStateManager.content.Load<Texture2D>("bulletSheet");
            Facing = new Vector2(1, 0);
            Weight = 10;
        }

        public override void Update(GameTime gameTime)
        {
            if (delayedInteraction)
            {
                this.Movement = new PlayerMovement();
                this.Tags.Add(Tag.Mortal);
                this.Tags.Remove(Tag.Deadly);
                delayedInteraction = false;
            }

            base.Update(gameTime);

            if (this.Tags.Contains(Tag.Deadly) && CollisionManager.IsCollidingWithBoundaries(this))
            {
                this.Movement = new PlayerMovement();
                this.Tags.Add(Tag.Mortal);
                this.Tags.Remove(Tag.Deadly);
            }
        }

        public override bool Interaction(BaseObject gameObject)
        {
            if (gameObject is Goal && !GameStateManager.loading)
            {
                GameStateManager.NextLevel();
                return false;
            }

            if (this.Tags.Contains(Tag.Deadly) && gameObject is not Gun)
            {
                if (gameObject is Cactus)
                {
                    Respawn();
                    return false;
                }
                if (gameObject.Tags.Contains(Tag.Mortal))
                {
                    GameStateManager.gameObjects.Remove(gameObject);
                }
                delayedInteraction = true;
                return true;
            }

            if (gameObject.Tags.Contains(Tag.Deadly))
            {
                Respawn();
                return false;
            }

            if (gameObject is Gun)
            {
                return false;
            }

            return true;
        }

        public void Respawn()
        {
            MinPosition = new Vector2(1, 1);
            Movement = new PlayerMovement();
            Tags = new HashSet<Tag>
            {
                Tag.Mortal,
                Tag.Loadable
            };
            GameStateManager.NextLevel(6);
        }
    }
}
