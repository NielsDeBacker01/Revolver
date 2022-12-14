using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Controls.Reader;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Gun : DynamicObject
    {
        public DynamicObject GunContent { get; set; }
        public float ShootCooldown { get; set; }

        public Gun(Vector2 position)
        {
            Movement = new NoMovement();
            Texture = GameStateManager.content.Load<Texture2D>("Gun");
            Facing = new Vector2(1, 0);
            MinPosition = position;
            Weight = 0;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ShootCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
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

        public override bool Interaction(BaseObject gameObject)
        {
            if (this.GunContent == null && gameObject.Tags.Contains(Tag.Loadable) && gameObject is DynamicObject movableObject)
            {
                this.GunContent = movableObject;
                this.GunContent.Movement = new NoMovement
                {
                    InputReader = new KeyboardReader()
                };
                this.GunContent.MinPosition = new Vector2(this.MinPosition.X + Width/2 - GunContent.Width/2, this.MinPosition.Y + Height / 2 - GunContent.Height / 2);
                this.ShootCooldown = 0.15f;
                this.GunContent.Tags.Remove(Tag.Loadable);
                this.GunContent.Tags.Remove(Tag.Mortal);
            }
            return false;
        }
    }
}