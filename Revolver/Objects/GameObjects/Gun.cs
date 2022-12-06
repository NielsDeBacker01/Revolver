using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Controls.Reader;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Gun : IMovable
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
        public IMovable GunContent { get; set; }
        public float ShootCooldown { get; set; }
        public List<Tag> Tags { get; set; }

        public Gun(Texture2D texture, Vector2 position)
        {
            GameStateManager.gameObjects.Add(this);
            Tags = new List<Tag>();
            Movement = new NoMovement();
            Texture = texture;
            Facing = new Vector2(0, 0);
            Width = 30;
            Height = 30;
            MinPosition = position;
            Weight = 0;
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(30, 10, new Vector2(0, 10), texture),
                //new Hitbox(10, 30, new Vector2(10, 0), texture)
            };
        }
        public void Update(GameTime gameTime)
        {
            ShootCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            MovementManager.Move(this, gameTime);
            foreach (var hitbox in Hitboxes) { hitbox.Flip(this); }
            if (GunContent != null)
            {
                Vector2 direction = GunContent.Movement.InputReader.ReadInput();
                if (direction != Vector2.Zero && ShootCooldown <= 0 && GunContent.Movement is NoMovement)
                {
                    //shoot content
                    if (direction.Y == 0 || direction.X == 0)
                    {
                        GunContent.Movement = new ShotMovement(direction, 12);
                    }
                    else
                    {
                        GunContent.Movement = new ShotMovement(new Vector2(direction.X, 0), 12);
                    }
                    this.GunContent.Tags.Add(Tag.Deadly);
                }

                //no longer part of gun
                if (!CollisionManager.IsCollidingWithObject(this, GunContent))
                {
                    GunContent.Tags.Add(Tag.Loadable);
                    GunContent = null;
                }
            }
        }

        public bool Interaction(IMovable gameObject)
        {
            if (this.GunContent == null && gameObject.Tags.Contains(Tag.Loadable))
            {
                this.GunContent = gameObject;
                this.GunContent.Movement = new NoMovement
                {
                    InputReader = new KeyboardReader()
                };
                this.GunContent.MinPosition = this.MinPosition;
                this.ShootCooldown = 0.10f;
                this.GunContent.Tags.Remove(Tag.Loadable);
                this.GunContent.Tags.Remove(Tag.Mortal);
            }
            return false;
        }
    }
}