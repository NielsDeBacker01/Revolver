﻿using Microsoft.Xna.Framework;
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

        public Bullet(Texture2D texture, Vector2 position, Vector2 facing, Movable origin)
        {
            GameStateManager.gameObjects.Add(this);
            Tags = new HashSet<Tag>
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (CollisionManager.IsCollidingWithBoundaries(this))
            {
                GameStateManager.gameObjects.Remove(this);
            }
        }

        public override bool Interaction(Movable gameObject)
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