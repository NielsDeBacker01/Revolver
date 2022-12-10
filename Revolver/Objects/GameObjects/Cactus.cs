using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Cactus : Movable
    {

        public Cactus(Texture2D texture, Vector2 position)
        {
            GameStateManager.gameObjects.Add(this);
            Tags = new HashSet<Tag>
            {
                Tag.Deadly
            };
            Movement = new NoMovement();
            Texture = texture;
            Facing = new Vector2(0, 0);
            Width = 30;
            Height = 30;
            MinPosition = position;
            Weight = 0;
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0), texture)
            };
        }
    }
}