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

        private void ManageGameState(object sender, GameUpdatedEventArgs e)
        {
            if (e.GameState == GameState.PlayerScored)
            {
                _mediator.OnGameUpdated(new GameUpdatedEventArgs { GameState = GameState.GameActive });
            }
            if (e.GameState == GameState.GameReset)
            {
                _mediator.OnGameUpdated(new GameUpdatedEventArgs {GameState = GameState.GameActive});
            }
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
