using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Interface;
using Revolver.Interfaces;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects.GameObjects
{
    internal class Bandit : Movable
    {
        public float ShootCooldown { get; set; }

        public Bandit(Texture2D texture, Vector2 position)
        {
            Tags = new HashSet<Tag>
            {
                Tag.Deadly,
                Tag.Mortal
            };
            foreach (BaseObject gObject in GameStateManager.gameObjects)
            {
                if(gObject is Player player)
                {
                    Movement = new ChasingMovement(this, player);
                }
            }
            Movement ??= new ChasingMovement(this, this);
            Texture = texture;
            MinPosition = position;
            Facing = new Vector2(1, 0);
            Width = 30;
            Height = 30;
            Weight = 10;
            Hitboxes = new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0), texture),
                new Hitbox(20, 10, new Vector2(20, 10), texture)
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
                GameStateManager.gameObjects.Add(new Bullet(Texture, this.MinPosition + new Vector2(0, Height/2), this.Facing, this));
                ShootCooldown = 1;
            }
        }

        public override bool Interaction(BaseObject gameObject)
        {

            if (gameObject is Bullet)
            {
                Bullet originTest = gameObject as Bullet;
                if(originTest.Origin == this)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
