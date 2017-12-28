using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGame.InputCommands;

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
            Mediator.GetMediator().GameUpdated += GameUpdatedEventHandler;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Command command = _inputHandler.HandleInput();
            command?.Execute(this);

            if (BoundingBox.Intersects(gameObjects.Player1Paddle.BoundingBox))
            {
                while (BoundingBox.Intersects(gameObjects.Player1Paddle.BoundingBox))
                {
                    Location = new Vector2(Location.X + 1, Location.Y);
                }
                Velocity = new Vector2(-(Velocity.X), Velocity.Y);
                Mediator.GetMediator().OnSoundUpdated(new SoundUpdatedEventArgs {Sound = Sound.PaddleBallCollision});
            }

            if (BoundingBox.Intersects(gameObjects.Player2Paddle.BoundingBox))
            {
                while (BoundingBox.Intersects(gameObjects.Player2Paddle.BoundingBox))
                {
                    Location = new Vector2(Location.X - 1, Location.Y);
                }
                Velocity = new Vector2(-(Velocity.X), Velocity.Y);
                Mediator.GetMediator().OnSoundUpdated(new SoundUpdatedEventArgs { Sound = Sound.PaddleBallCollision });
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

        public override void ResetPosition()
        {
            Velocity = new Vector2(0, 0);
            Location = _initialLocation;
        }

        private void GameUpdatedEventHandler(object sender, GameUpdatedEventArgs e)
        {
            if (e.GameState == GameState.PlayerScored || e.GameState == GameState.GameReset)
            {
                ResetPosition();
            }
        }
    }
}