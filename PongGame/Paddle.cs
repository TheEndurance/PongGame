using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public class Paddle : Sprite
    {
        public Paddle(Texture2D texture, Vector2 location) : base(texture, location)
        {
        }
    }

    public class Sprite
    {
        private readonly Texture2D _texture;
        private readonly Vector2 _location;

        public Sprite(Texture2D texture, Vector2 location)
        {
            _texture = texture;
            _location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }
    }
}