using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
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

        public Player(Texture2D texture)
        {
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

        public int Interaction(IMovable gameObject)
        {
            if (gameObject is Cactus || gameObject is Bandit || gameObject is Bullet)
            {
                MinPosition = new Vector2(1, 1);
                Movement.ResetMovement();
                return 0;
            }
            return 1;
        }
    }
}
