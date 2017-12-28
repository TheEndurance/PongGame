using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongGame.InputCommands;

namespace PongGame
{
    public class GameStateManager
    {
        private Mediator _mediator = Mediator.GetMediator();
        private readonly InputHandler _inputHandler;
        private GameObjects _gameObjects;
        public GameState GameState { get; private set; }

        public GameStateManager(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            GameState = GameState.GameActive;
            _mediator.GameUpdated += SubscribeToGameUpdates;
            _mediator.GameUpdated += ManageGameState;
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
