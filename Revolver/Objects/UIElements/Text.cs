using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Revolver.Managers;

namespace Revolver.Objects.UIElements
{
    internal class Text : GameElement
    {
        public string Content { get; set; }

        public Text(Vector2 position, string content)
        {
            MinPosition = position;
            Content = content;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GameStateManager.Font, Content, MinPosition, Color.Black);
        }
    }
}
