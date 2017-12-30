/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using PongGame.InputCommands;

namespace PongGame.GameState
{
    /// <summary>
    /// Handles game state changes
    /// </summary>
    public class GameStateManager
    {
        private static readonly GameStateManager _instance = new GameStateManager();
        private Mediator _mediator = Mediator.GetMediator();
        private GameObjects.GameObjects _gameObjects;
        public InputHandler InputHandler { get; set; }
        public GameState GameState { get; private set; }

        /// <summary>
        /// Constructor for the GameStateManager class
        /// </summary>
        private GameStateManager()
        {
            GameState = GameState.GameActive;
            _mediator.GameUpdated += SubscribeToGameUpdates;
            _mediator.GameUpdated += ManageGameState;
        }

        /// <summary>
        /// Static method to retrieve the singleton instance of the GameStateManager 
        /// </summary>
        /// <returns>Singleton instance of the GameStateManager</returns>
        public static GameStateManager GetGameStateManager()
        {
            return _instance;
        }

        /// <summary>
        /// Gets called in the game loop to update game state
        /// </summary>
        /// <param name="gametime">The game time</param>
        public void Update(GameTime gametime)
        {
            Command command = InputHandler.HandleInput();
            command?.Execute();
        }

        /// <summary>
        /// Subscribes to game updates from the GameUpdated event and updates GameStateManager's GameState property
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">The event arguments, which consists of the GameState enumeration</param>
        private void SubscribeToGameUpdates(object sender, GameUpdatedEventArgs e)
        {
            GameState = e.GameState;
        }

        /// <summary>
        /// Event handler to manage game states
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">The event arguments, which consists of the GameState enumeration</param>
        private void ManageGameState(object sender, GameUpdatedEventArgs e)
        {
            switch (e.GameState)
            {
                case GameState.PlayerScored:
                    GameState = GameState.GameActive;
                    break;
                case GameState.GameReset:
                    GameState = GameState.GameActive;
                    break;
            }
        }

    }
}
