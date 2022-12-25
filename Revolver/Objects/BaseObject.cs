using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects
{
    internal abstract class BaseObject : GameElement
    {
        public Texture2D Texture { get; set; }
        public Vector2 Facing { get; set; }
        public List<Hitbox> Hitboxes { get; set; }
        protected int spriteX { get; set; } = 0;
        protected int spriteY { get; set; } = 0;
        protected int dimensionsX { get; set; } = 32;
        protected int dimensionsY { get; set; } = 32;
        public HashSet<Tag> Tags { get; set; }
        public BaseObject()
        {
            GameStateManager.gameObjects.Add(this);
            Tags = new HashSet<Tag>();
            Hitboxes = new List<Hitbox>();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)MinPosition.X, (int)MinPosition.Y, Width, Height), new Rectangle(spriteX, spriteY, dimensionsX, dimensionsY), Color.White);
            //foreach (var hitbox in Hitboxes) { spriteBatch.Draw(hitbox.Texture, MinPosition + hitbox.Offset, hitbox.Box, Color.Blue); }
        }
    }
}