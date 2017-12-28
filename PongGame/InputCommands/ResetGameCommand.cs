using System;
using PongGame.GameObjects;
using PongGame.GameState;

namespace PongGame.InputCommands
{
    public class ResetGameCommand : Command
    {
        private readonly GameState.GameState gameState;
        public ResetGameCommand(GameState.GameState gameState)
        {
            this.gameState = gameState;
        }

        public override void Execute(Sprite sprite)
        {
            throw new NotImplementedException();
        }

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