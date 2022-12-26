using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;
using System.Collections.Generic;

namespace Revolver.Objects
{
    internal abstract class BaseObject : GameElement
    {
        public Texture2D Texture { get; set; }
        public int scale = 1;
        public status status { get; set; } = status.Idle;
        public new int Width {
            get
            {
                return currentFrame.frame.Width * scale;
            }
        }
        public new int Height
        {
            get
            {
                return currentFrame.frame.Height * scale;
            }
        }
        public Vector2 Facing { get; set; }
        public HashSet<Tag> Tags { get; set; }
        public AnimationFrame currentFrame { get; set; }
        public BaseObject()
        {
            GameStateManager.gameObjects.Add(this);
            Tags = new HashSet<Tag>();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            /*
            Texture2D _texture;
            _texture = new Texture2D(GameStateManager.graphics, 1, 1);
            _texture.SetData(new Color[] { Color.DarkSlateGray });
            spriteBatch.Draw(_texture, new Rectangle((int)MinPosition.X, (int)MinPosition.Y, Width, Height), currentFrame.frame, Color.White);
            */
            spriteBatch.Draw(Texture, new Rectangle((int)MinPosition.X, (int)MinPosition.Y, Width, Height), currentFrame.frame, Color.White);
            //foreach (var hitbox in currentFrame.Hitboxes) { spriteBatch.Draw(hitbox.Texture, MinPosition + hitbox.Offset, hitbox.Box, Color.Blue); }
        }
    }
}