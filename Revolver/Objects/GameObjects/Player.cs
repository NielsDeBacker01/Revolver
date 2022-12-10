﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Revolver.Controls;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using Revolver.Objects;
using System;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Player : Movable
    {

        public Player(Texture2D texture)
        {
            GameStateManager.gameObjects.Add(this);
            Tags = new HashSet<Tag>
            {
                Tag.Mortal,
                Tag.Loadable
            };
            Movement = new PlayerMovement();
            MinPosition = new Vector2(1, 1);
            Texture = texture;
            Facing = new Vector2(1, 0);
            Width = 30;
            Height = 30;
            Weight = 10;
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(20, 10, new Vector2(10, 20), texture),
                new Hitbox(20, 10, new Vector2(20, 10), texture),
                new Hitbox(10, 10, new Vector2(10, -10), texture)
            };
        }

        public override void Update(GameTime gameTime)
        {  
            base.Update(gameTime);

            if (this.Tags.Contains(Tag.Deadly) && CollisionManager.IsCollidingWithBoundaries(this))
            {
                this.Movement = new PlayerMovement();
                this.Tags.Add(Tag.Mortal);
                this.Tags.Remove(Tag.Deadly);
            }
        }

        public override bool Interaction(Movable gameObject)
        {
            if (this.Tags.Contains(Tag.Deadly) && gameObject is not Gun)
            {
                if (gameObject.Tags.Contains(Tag.Mortal))
                {
                    GameStateManager.gameObjects.Remove(gameObject);
                }
                this.Movement = new PlayerMovement();
                this.Tags.Add(Tag.Mortal);
                this.Tags.Remove(Tag.Deadly);
                return false;
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