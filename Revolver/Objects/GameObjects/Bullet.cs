using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Bullet : Movable
    {
        public Movable Origin;

        public Bullet(Vector2 position, Vector2 facing, Movable origin)
        {
            Tags = new HashSet<Tag>
            {
                Tag.Deadly
            };

            Texture =  new Texture2D(GameStateManager.graphics, 1, 1);
            Texture.SetData(new[] { Color.White });
            MinPosition = position;
            Width = 10;
            Height = 5;
            Weight = 0;
            Movement = new ShotMovement(facing);
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(Width, Height, new Vector2(0, 0))
            };
            Origin = origin;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (CollisionManager.IsCollidingWithBoundaries(this) || !GameStateManager.gameObjects.Contains(Origin))
            {
                GameStateManager.gameObjects.Remove(this);
            }
        }
    }
}
