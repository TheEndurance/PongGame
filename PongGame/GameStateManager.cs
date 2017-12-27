using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PongGame
{
    public class GameStateManager
    {
        private readonly InputHandler _inputHandler;
        public GameState GameState { get; private set; }

        public GameStateManager(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            GameState = GameState.GameActive;
            Mediator.GetMediator().GameUpdated += SubscribeToGameUpdates;
        }

        public void Update(GameTime gametime)
        {
            Command command = _inputHandler.HandleInput();
            command?.Execute();
        }

        private void SubscribeToGameUpdates(object sender, GameUpdatedEventArgs e)
        {
            GameState = e.GameState;
        }

    }
}
