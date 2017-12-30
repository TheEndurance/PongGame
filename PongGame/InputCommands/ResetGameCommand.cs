/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using System;
using PongGame.GameObjects;
using PongGame.GameState;

namespace PongGame.InputCommands
{
    /// <summary>
    /// A command that describes the behaviour of resetting the game
    /// </summary>
    public class ResetGameCommand : Command
    {
        private readonly GameState.GameState gameState;

        /// <summary>
        /// Constructor for the ResetGameCommand
        /// </summary>
        /// <param name="gameState">The current state of the game</param>
        public ResetGameCommand(GameState.GameState gameState)
        {
            this.gameState = gameState;
        }

        /// <summary>
        /// Executes the behaviour
        /// </summary>
        /// <param name="sprite">The sprite entity to execute the behaviour on</param>
        public override void Execute(Sprite sprite)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes the behaviour
        /// </summary>
        public override void Execute()
        {
            if (gameState == GameState.GameState.GameOver)
            {
                Mediator.GetMediator()
                    .OnGameUpdated(new GameUpdatedEventArgs {GameState = GameState.GameState.GameReset});
            }
        }
    }
}