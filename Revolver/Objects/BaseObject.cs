using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Interfaces;
using Revolver.Managers;
using Revolver.Objects.GameObjects;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using Revolver.Objects;
using SharpDX.DirectWrite;

namespace Revolver.Objects
{
    internal abstract class BaseObject : GameElement
    {
        public Texture2D Texture { get; set; }
        public float scale = 1;
        private status status;
        public status Status
        {
            get
            {
                return status;
            }
            set
            {
                if(status != value)
                {
                    if (this is IAnimate animatable) { animatable.currentFrameIndex = 0; }
                    status = value;
                }
            }
        }
        public new int Width {
            get
            {
                return (int)(CurrentFrame.frame.Width * scale);
            }
        }
        public new int Height
        {
            get
            {
                return (int)(CurrentFrame.frame.Height * scale);
            }
        }
        public Vector2 Facing { get; set; }
        public HashSet<Tag> Tags { get; set; }
        public AnimationFrame CurrentFrame { get; set; }
        public BaseObject()
        {
            GameStateManager.gameObjects.Add(this);
            Tags = new HashSet<Tag>();
            switch (this)
            {
                case Player:
                    scale = 1.5f;
                    break;
                case Bandit:
                    scale = 1f;
                    break;
                default:
                    break;
            }
            Status = status.Idle;
            Facing = new Vector2(1,0);
            CurrentFrame = AnimationManager.GetCurrentFrame(0, this);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            /*
            Texture2D _texture;
            _texture = new Texture2D(GameStateManager.graphics, 1, 1);
            _texture.SetData(new Color[] { Color.DarkSlateGray });
            spriteBatch.Draw(_texture, new Rectangle((int)MinPosition.X, (int)MinPosition.Y, Width, Height), currentFrame.frame, Color.White);
            */

            if (Facing.X < 0)
            {
                spriteBatch.Draw(Texture, new Rectangle((int)MinPosition.X, (int)MinPosition.Y, Width, Height), CurrentFrame.frame, Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, new Rectangle((int)MinPosition.X, (int)MinPosition.Y, Width, Height), CurrentFrame.frame, Color.White, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
            }

            
            //foreach (var hitbox in CurrentFrame.Hitboxes) { spriteBatch.Draw(hitbox.Texture, MinPosition + hitbox.Offset, hitbox.Box, Color.Blue); }
        }
    }
}