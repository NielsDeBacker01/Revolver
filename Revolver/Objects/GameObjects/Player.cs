using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Revolver.Controls;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using Revolver.Objects;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Player : IMovable
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

        public Player(Texture2D texture)
        {
            Tags = new List<Tag>();
            Tags.Add(Tag.Mortal);
            Tags.Add(Tag.Loadable);
            Movement = new PlayerMovement();
            MinPosition = new Vector2(1, 1);
            Texture = texture;
            Facing = new Vector2(1, 0);
            Width = 30;
            Height = 30;
            Weight = 10;
            Hitboxes = new List<Hitbox>();
            Hitboxes.Add(new Hitbox(20, 10, new Vector2(10, 20), texture));
            Hitboxes.Add(new Hitbox(20, 10, new Vector2(20, 10), texture));
            Hitboxes.Add(new Hitbox(10, 10, new Vector2(10, -10), texture));
        }

        public void Update(GameTime gameTime)
        {
            MovementManager.Move(this, gameTime);
            foreach (var hitbox in Hitboxes) { hitbox.Flip(this); }

            if (this.Tags.Contains(Tag.Deadly) && CollisionManager.IsCollidingWithBoundaries(this))
            {
                this.Movement = new PlayerMovement();
                this.Tags.Add(Tag.Loadable);
                this.Tags.Remove(Tag.Deadly);
            }
        }

        public bool Interaction(IMovable gameObject)
        {
            if (this.Tags.Contains(Tag.Deadly) && gameObject is not Gun)
            {
                if (gameObject.Tags.Contains(Tag.Mortal))
                {
                }
                this.Movement = new PlayerMovement();
                this.Tags.Add(Tag.Loadable);
                this.Tags.Remove(Tag.Deadly);
            }


            if (gameObject.Tags.Contains(Tag.Deadly))
            {
                MinPosition = new Vector2(1, 1);
                Movement.ResetMovement();
                return false;
            }

            if (gameObject is Gun)
            {
                return false;
            }

            return true;
        }
    }
}
