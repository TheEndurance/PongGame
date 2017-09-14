using System;
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

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && AttachedToPaddle != null)
            {
                Vector2 newVelocity;
                var rand = new Random();   
                var direction = rand.Next(0, 2);
                if (direction == 0)
                {
                    newVelocity = new Vector2(9f,5f);
                }
                else
                {
                    newVelocity = new Vector2(9f, -5f);
                }
              
                Velocity = newVelocity;
                AttachedToPaddle = null;
            }

            if (AttachedToPaddle != null)
            {
                Location.X = AttachedToPaddle.Location.X + AttachedToPaddle.Width;
                Location.Y = AttachedToPaddle.Location.Y;
            }
            else
            {
                if (BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox))
                {
                    while (BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox))
                    {
                        Location = new Vector2(Location.X +1, Location.Y);
                    }
                    Velocity = new Vector2(-(Velocity.X), Velocity.Y);
                }

                if (BoundingBox.Intersects(gameObjects.ComputerPaddle.BoundingBox))
                {
                    while (BoundingBox.Intersects(gameObjects.ComputerPaddle.BoundingBox))
                    {
                        Location = new Vector2(Location.X - 1, Location.Y);
                    }
                    Velocity = new Vector2(-(Velocity.X), Velocity.Y);
                }
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

        public void AttachTo(Paddle paddle)
        {
            AttachedToPaddle = paddle;



        }
    }
}