using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class Ball : Sprite
    {
        private readonly InputHandler _inputHandler;
        private readonly Vector2 _initialLocation;

        public Ball(Texture2D texture, Vector2 location, Rectangle gameBoundaries, InputHandler inputHandler) : base(texture, location, gameBoundaries)
        {
            _inputHandler = inputHandler;
            _initialLocation = location;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Space) && AttachedToPaddle != null)
            //{
            //    Vector2 newVelocity;
            //    var rand = new Random();   
            //    var direction = rand.Next(0, 2);
            //    if (direction == 0)
            //    {
            //        newVelocity = new Vector2(9f,5f);
            //    }
            //    else
            //    {
            //        newVelocity = new Vector2(9f, -5f);
            //    }

            //    Velocity = newVelocity;
            //    AttachedToPaddle = null;
            //}
            Command command = _inputHandler.HandleInput();
            command?.Execute(this);

            if (BoundingBox.Intersects(gameObjects.Player1Paddle.BoundingBox))
            {
                while (BoundingBox.Intersects(gameObjects.Player1Paddle.BoundingBox))
                {
                    Location = new Vector2(Location.X + 1, Location.Y);
                }
                Velocity = new Vector2(-(Velocity.X), Velocity.Y);
            }

            if (BoundingBox.Intersects(gameObjects.Player2Paddle.BoundingBox))
            {
                while (BoundingBox.Intersects(gameObjects.Player2Paddle.BoundingBox))
                {
                    Location = new Vector2(Location.X - 1, Location.Y);
                }
                Velocity = new Vector2(-(Velocity.X), Velocity.Y);
            }

   
            base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
            if (Location.Y + this.Height > GameBoundaries.Height || Location.Y <= 0)
            {
                Velocity = new Vector2(Velocity.X, -(Velocity.Y));
            }
        }

        public void ResetBall()
        {
            Velocity = new Vector2(0, 0);
            Location = _initialLocation;
        }
    }
}