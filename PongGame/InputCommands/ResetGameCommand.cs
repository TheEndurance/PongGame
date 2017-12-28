using System;
using PongGame.GameObjects;
using PongGame.GameState;

namespace PongGame.InputCommands
{
    public class ResetGameCommand : Command
    {
        public override void Execute(Sprite sprite)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            Mediator.GetMediator().OnGameUpdated(new GameUpdatedEventArgs {GameState = GameState.GameState.GameReset});
        }
    }
}