using System;

namespace PongGame.GameState
{
    public class GameUpdatedEventArgs : EventArgs
    {
        public GameState GameState { get; set; }
    }
}
