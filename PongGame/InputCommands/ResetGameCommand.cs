﻿using System;

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
            Mediator.GetMediator().OnGameUpdated(new GameUpdatedEventArgs {GameState = GameState.GameReset});
        }
    }
}