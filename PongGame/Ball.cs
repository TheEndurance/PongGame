using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class Ball : Sprite
    {
        private Paddle AttachedToPaddle;
        public Ball(Texture2D texture, Vector2 location, Rectangle gameBoundaries) : base(texture, location, gameBoundaries)
        {

        }

        public override void Update(GameTime gameTime, GameObjects gameObject)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && AttachedToPaddle != null)
            {
                var newVelocity = new Vector2(5f, AttachedToPaddle.Velocity.Y * 0.65f);
                Velocity = newVelocity;
                AttachedToPaddle = null;
            }

            if (AttachedToPaddle != null)
            {
                Location.X = AttachedToPaddle.Location.X + AttachedToPaddle.Width;
                Location.Y = AttachedToPaddle.Location.Y;
            }

            base.Update(gameTime, gameObject);
        }

        protected override void CheckBounds()
        {
            if (Location.Y + this.Height > GameBoundaries.Height || Location.Y <= 0)
            {
                Velocity = new Vector2(Velocity.X, -(Velocity.Y));
            }
        }

        public void AttachTo(Paddle paddle)
        {
            AttachedToPaddle = paddle;



        }
    }
}