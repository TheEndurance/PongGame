using Microsoft.Xna.Framework;
using PongGame.InputCommands;

namespace PongGame.GameState
{
    public class GameStateManager
    {
        private static readonly GameStateManager _instance = new GameStateManager();
        private Mediator _mediator = Mediator.GetMediator();
        private GameObjects.GameObjects _gameObjects;
        public InputHandler InputHandler { get; set; }
        public GameState GameState { get; private set; }

        private GameStateManager()
        {
            GameState = GameState.GameActive;
            _mediator.GameUpdated += SubscribeToGameUpdates;
            _mediator.GameUpdated += ManageGameState;
        }

        public static GameStateManager GetGameStateManager()
        {
            return _instance;
        }


        public void Update(GameTime gametime)
        {
            Command command = InputHandler.HandleInput();
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
