/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGame.GameState;
using PongGame.InputCommands;
using PongGame.SoundState;

namespace PongGame.GameObjects
{
    /// <summary>
    /// Represents a Ball sprite in the game
    /// </summary>
    public class Ball : Sprite
    {
        private readonly InputHandler _inputHandler;
        private readonly Vector2 _initialLocation;

        /// <summary>
        /// Constructor for the Ball class
        /// </summary>
        /// <param name="texture">Texture2D which represents the texture for the sprite</param>
        /// <param name="location">Vector2D which represents the location of the sprite</param>
        /// <param name="gameBoundaries">Rectangle which represents the game boundaries which the sprite can exist in</param>
        /// <param name="inputHandler">InputHandler which provides commands upon receiving user input</param>
        public Ball(Texture2D texture, Vector2 location, Rectangle gameBoundaries, InputHandler inputHandler) : base(texture, location, gameBoundaries)
        {
            _inputHandler = inputHandler;
            _initialLocation = location;
            Mediator.GetMediator().GameUpdated += GameUpdatedEventHandler;
        }

        /// <summary>
        /// Updates the ball in the game loop
        /// </summary>
        /// <param name="gameTime">GameTime which represents the game time</param>
        /// <param name="gameObjects">GameObjects which is a class that encapsulates all objects in the game</param>
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

        /// <summary>
        /// Checks to see if the ball is within the game boundaries
        /// </summary>
        protected override void CheckBounds()
        {
            if (Location.Y + this.Height > GameBoundaries.Height || Location.Y <= 0)
            {
                Velocity = new Vector2(Velocity.X, -(Velocity.Y));
            }
        }

        /// <summary>
        /// Resets the position of the ball to its initial location
        /// </summary>
        public override void ResetPosition()
        {
            Velocity = new Vector2(0, 0);
            Location = _initialLocation;
        }


        /// <summary>
        /// Event handler for game updates
        /// </summary>
        /// <param name="sender">The object which triggered the event</param>
        /// <param name="e">The event arguments which consist of the GameState enum</param>
        private void GameUpdatedEventHandler(object sender, GameUpdatedEventArgs e)
        {
            if (e.GameState == GameState.GameState.PlayerScored || e.GameState == GameState.GameState.GameReset)
            {
                ResetPosition();
            }
        }
    }
}