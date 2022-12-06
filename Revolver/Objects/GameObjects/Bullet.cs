using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Bullet : IMovable
    {
        public Texture2D Texture { get; set; }
        public IMovement Movement { get; set; }
        public List<Hitbox> Hitboxes { get; set; }
        public Vector2 MinPosition { get; set; }
        public Vector2 MaxPosition
        {
            get { return MinPosition + new Vector2(Width, Height); }
            set { MinPosition = value - new Vector2(Width, Height); }
        }
        public Vector2 Facing { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<Tag> Tags { get; set; }
        public IMovable Origin;

        public Bullet(Texture2D texture, Vector2 position, Vector2 facing, IMovable origin)
        {
            GameStateManager.gameObjects.Add(this);
            Tags = new List<Tag>
            {
                Tag.Deadly
            };
            Texture = texture;
            MinPosition = position;
            Width = 10;
            Height = 5;
            Weight = 0;
            Movement = new ShotMovement(facing);
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(Width, Height, new Vector2(0, 0), texture)
            };
            Origin = origin;
        }

        public void Update(GameTime gameTime)
        {
            MovementManager.Move(this, gameTime);
            foreach (var hitbox in Hitboxes) { hitbox.Flip(this); }

            if (CollisionManager.IsCollidingWithBoundaries(this))
            {
                GameStateManager.gameObjects.Remove(this);
            }
        }

        public bool Interaction(IMovable gameObject)
        {
            if (gameObject == Origin || gameObject is Player)
            {
                if (gameObject is Player)
                {
                    GameStateManager.gameObjects.Remove(this);
                }
                return false;
            }
            GameStateManager.gameObjects.Remove(this);
            return true;
        }
    }
}
