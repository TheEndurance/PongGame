using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public abstract class Sprite
    {
        protected readonly Texture2D Texture;
        public Vector2 Location;
        public int Width { get { return Texture.Width; } }
        public int Height { get { return Texture.Height; } }
        public Vector2 Velocity { get; protected set; }

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, Width, Height); }
        }

        public Rectangle GameBoundaries { get; }

        protected Sprite(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
        {
            Texture = texture;
            Location = location;
            Velocity = Vector2.Zero;
            GameBoundaries = gameBoundaries;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Location += Velocity;
            CheckBounds();
        }

        protected abstract void CheckBounds();
    }


}
