using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Player : Movable
    {
        private bool delayedInteraction = false;
        private int scale = 2;
        public Player(Vector2 position)
        {
            Tags = new HashSet<Tag>
            {
                Tag.Mortal,
                Tag.Loadable
            };
            Movement = new PlayerMovement();
            MinPosition = position;
            Texture = GameStateManager.content.Load<Texture2D>("bulletSheet");
            Facing = new Vector2(1, 0);
            Width = 12 * scale;
            Height = 21 * scale;
            dimensionsX = 12;
            dimensionsY = 21;
            spriteX = 6;
            spriteY = 16;
            Weight = 10;
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(2* scale, 3* scale, new Vector2(1, 2)* scale),
                new Hitbox(6* scale, 5* scale, new Vector2(3, 0)* scale),
                new Hitbox(2* scale, 3* scale, new Vector2(9, 2)* scale),
                new Hitbox(12* scale, 14* scale, new Vector2(0, 5)* scale),
                new Hitbox(3* scale, 6* scale, new Vector2(1, 15)* scale),
                new Hitbox(3* scale, 6* scale, new Vector2(9, 15)* scale)
            };
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
            if (gameObject is Goal)
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
            GameStateManager.NextLevel(3);
        }
    }
}
