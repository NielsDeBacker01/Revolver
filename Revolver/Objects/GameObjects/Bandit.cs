using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Objects.GameObjects
{
    internal class Bandit : IMovable, IShoot
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
        public float ShootCooldown { get; set; }

        public Bandit(Texture2D texture, Vector2 position, IMovable player = null)
        {
            if (player == null || player is not Player)
            {
                player = this;
            }
            Texture = texture;
            Movement = new ChasingMovement(this, player);
            MinPosition = position;
            Facing = new Vector2(1, 0);
            Width = 30;
            Height = 30;
            Weight = 10;
            Hitboxes = new List<Hitbox>();
            Hitboxes.Add(new Hitbox(30, 30, new Vector2(0, 0), texture));
            Hitboxes.Add(new Hitbox(20, 10, new Vector2(20, 10), texture));
            ShootCooldown = 0;
        }

        public void Update(GameTime gameTime, List<IMovable> gameObjects)
        {
            MovementManager.Move(this, gameTime, gameObjects);
            foreach (var hitbox in Hitboxes) { hitbox.Flip(this); }
            //update bullet list
            foreach (IMovable test in gameObjects.ToList())
            {
                if(test is Bullet)
                {
                    Bullet bullet = test as Bullet;
                    if (bullet.Origin == this && CollisionManager.IsColliding(bullet, gameObjects))
                    {
                        gameObjects.Remove(bullet);
                    }
                }
            }
            
            ShootCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (ShootCooldown <= 0)
            {
                gameObjects.Add(new Bullet(Texture, this.MinPosition + new Vector2(0, Height/2), this.Facing, this));
                ShootCooldown = 1;
            }
        }

        public int Interaction(IMovable gameObject)
        {
            if (gameObject is Bullet)
            {
                Bullet originTest = gameObject as Bullet;
                if(originTest.Origin == this)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
