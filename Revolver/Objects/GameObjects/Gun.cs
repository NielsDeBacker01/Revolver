using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls;
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


        public Gun(Texture2D texture, Vector2 position)
        {
            Movement = new NoMovement();
            Texture = texture;
            Facing = new Vector2(0, 0);
            Width = 30;
            Height = 30;
            MinPosition = position;
            Weight = 0;
            Hitboxes = new List<Hitbox>();
            Hitboxes.Add(new Hitbox(30, 10, new Vector2(0, 10), texture));
            Hitboxes.Add(new Hitbox(10, 30, new Vector2(10, 0), texture)); 
        }
        public void Update(GameTime gameTime, List<IMovable> gameObjects)
        {
            MovementManager.Move(this, gameTime, gameObjects);
            foreach (var hitbox in Hitboxes) {hitbox.Flip(this);}
            if(GunContent != null)
            {
                Vector2 direction = GunContent.Movement.InputReader.ReadInput();
                if (direction != Vector2.Zero)
                {   
                    if(direction.Y == 0 || direction.X == 0)
                    {
                        GunContent.Movement = new ShotMovement(direction);
                    } 
                    else
                    {
                        GunContent.Movement = new ShotMovement(new Vector2(direction.X, 0));
                    }
                }
                if (CollisionManager.IsColliding(GunContent, gameObjects))
                {
                    GunContent.Movement = new PlayerMovement();
                    GunContent = null;
                }
            }
        }

        public int Interaction(IMovable gameObject)
        {
            return 0;
        }

        public void Load(IMovable gameObject)
        {
            this.GunContent = gameObject;
            this.GunContent.Movement = new NoMovement();
            this.GunContent.Movement.InputReader = new KeyboardReader();
            this.GunContent.MinPosition = new Vector2(100, 400);
        }
    }
}