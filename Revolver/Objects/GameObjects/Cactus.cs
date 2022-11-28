using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Cactus : IMovable
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


        public Cactus(Texture2D texture, Vector2 position)
        {
            Movement = new NoMovement();
            Texture = texture;
            Facing = new Vector2(0, 0);
            Width = 30;
            Height = 30;
            MinPosition = position;
            Weight = 0;
            Hitboxes = new List<Hitbox>();
            Hitboxes.Add(new Hitbox(30, 30, new Vector2(0, 0), texture));
        }

        public int Interaction(IMovable gameObject)
        {
            return 1;
        }
    }
}