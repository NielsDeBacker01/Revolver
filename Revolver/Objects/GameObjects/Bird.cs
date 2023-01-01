using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Controls.Movement;
using Revolver.Interfaces;
using Revolver.Managers;
using System.Collections.Generic;
using System.Linq;


namespace Revolver.Objects.GameObjects
{
    internal class Bird : DynamicObject, IAnimate
    {
        public int currentFrameIndex { get; set; }
        public int holdFrame { get; set; }

        public Bird(Vector2 position)
        {
            Tags = new HashSet<Tag>
            {
                Tag.Deadly,
                Tag.Mortal
            };
            Movement = new FlyingMovement();
            Texture = GameStateManager.content.Load<Texture2D>("vulture");
            MinPosition = position;
            Facing = new Vector2(1, 0);
            Weight = 0;
        }

        public override bool Interaction(BaseObject gameObject)
        {

            if (gameObject is Bullet)
            {
                Bullet originTest = gameObject as Bullet;
                if (originTest.Origin == this)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
