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

namespace PongGame.GameObjects
{
    /// <summary>
    /// Represents a Paddle sprite in the game
    /// </summary>
    public class Paddle : Sprite
    {
        private readonly InputHandler _inputHandler;
        private readonly Vector2 _initialLocation;

        /// <summary>
        /// Constructor for the Paddle class
        /// </summary>
        /// <param name="texture">Texture2D which represents the texture for the sprite</param>
        /// <param name="location">Vector2D which represents the location of the sprite</param>
        /// <param name="gameBoundaries">Rectangle which represents the game boundaries which the sprite can exist in</param>
        /// <param name="inputHandler">InputHandler which provides commands upon receiving user input</param>
        public Paddle(Texture2D texture, Vector2 location, Rectangle gameBoundaries,InputHandler inputHandler) : base(texture, location, gameBoundaries)
        {
            _inputHandler = inputHandler;
            _initialLocation = location;
            Mediator.GetMediator().GameUpdated += GameUpdatedEventHandler;
        }

        /// <summary>
        /// Updates the Paddle in the game loop
        /// </summary>
        /// <param name="gameTime">GameTime which represents the game time</param>
        /// <param name="gameObjects">GameObjects which is a class that encapsulates all objects in the game</param>
        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Command command = _inputHandler.HandleInput();
            Velocity = new Vector2(0, 0);
            if (command != null)
            {
                command.Execute(this);
            }
            
            base.Update(gameTime, gameObjects); //this updates the location
        }

        /// <summary>
        /// Checks to see if the Paddle is within the game boundaries
        /// </summary>
        protected override void CheckBounds()
        {
            //if our location.Y is between 0 and the screenbound height - playerPaddle height, then its fine, else it will be set to either to 0, or screenbound.height-texture.height
            Location.Y = MathHelper.Clamp(Location.Y, 0, GameBoundaries.Height - this.Height);
        }


        /// <summary>
        /// Resets the position of the paddle to its initial location
        /// </summary>
        public override void ResetPosition()
        {
            Location = _initialLocation;
        }


        /// <summary>
        /// Event handler for game updates
        /// </summary>
        /// <param name="sender">The object which triggered the event</param>
        /// <param name="e">The event arguments which consist of the GameState enum</param>
        private void GameUpdatedEventHandler(object sender, GameUpdatedEventArgs e)
        {
            if (e.GameState == GameState.GameState.GameReset)
            {
                ResetPosition();
            }
        }
    }
}