﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using System.Collections.Generic;
using System.Linq;

namespace Revolver.Objects.GameObjects
{
    internal class Bandit : Movable
    {
        public float ShootCooldown { get; set; }

        public Bandit(Vector2 position)
        {
            Tags = new HashSet<Tag>
            {
                Tag.Deadly,
                Tag.Mortal
            };
            foreach (Player player in GameStateManager.gameObjects.OfType<Player>().ToList())
            {
                Movement = new ChasingMovement(this, player);
            }
            Movement ??= new ChasingMovement(this, this);
            Texture = new Texture2D(GameStateManager.graphics, 1, 1);
            Texture.SetData(new[] { Color.White });
            MinPosition = position;
            Facing = new Vector2(1, 0);
            Width = 30;
            Height = 30;
            Weight = 10;
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0)),
                new Hitbox(20, 10, new Vector2(20, 10))
            };
            ShootCooldown = 1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //update bullet list
            ShootCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (ShootCooldown <= 0)
            {
                GameStateManager.gameObjects.Add(new Bullet(this.MinPosition + new Vector2(0, Height/2), this.Facing, this));
                ShootCooldown = 1;
            }
        }
    }
}
