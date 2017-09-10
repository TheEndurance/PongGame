using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class Ball : Sprite
    {
        private Paddle AttachedToPaddle;
        public Ball(Texture2D texture, Vector2 location) : base(texture, location)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && AttachedToPaddle != null)
            {
                var newVelocity = new Vector2(5f, AttachedToPaddle.Velocity.Y);
                Velocity = newVelocity;
                AttachedToPaddle = null;
            }

            if (AttachedToPaddle != null)
            {
                Location.X = AttachedToPaddle.Location.X + AttachedToPaddle.Width;
                Location.Y = AttachedToPaddle.Location.Y;
            }

            base.Update(gameTime);
        }

        protected override void CheckBounds()
        {

        }

        public void AttachTo(Paddle paddle)
        {
            AttachedToPaddle = paddle;


         
        }
    }
}