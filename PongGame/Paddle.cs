using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class Paddle : Sprite
    {
        private readonly Rectangle _screenBounds;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds) : base(texture, location)
        {
            _screenBounds = screenBounds;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Velocity = new Vector2(0, -3f);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Velocity = new Vector2(0, 3f);


            base.Update(gameTime); //this updates the location
        }

        protected override void CheckBounds()
        {
            //if our location.Y is between 0 and the screenbound height - paddle height, then its fine, else it will be set to either to 0, or screenbound.height-texture.height
            Location.Y = MathHelper.Clamp(Location.Y, 0, _screenBounds.Height - Texture.Height);
        }
    }

    public abstract class Sprite
    {
        protected readonly Texture2D Texture;
        protected Vector2 Location;
        protected Vector2 Velocity = Vector2.Zero;

        protected Sprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            Location += Velocity;
            CheckBounds();
        }

        protected abstract void CheckBounds();
    }
}