using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public class Score
    {
        private Mediator _mediator = Mediator.GetMediator();
        private const int MAX_SCORE = 2;
        private readonly SpriteFont _font;
        private readonly Rectangle _gameBoundaries;
        private readonly GameStateManager _gameStateManager;

        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        private int _player1Score;
        private int _player2Score;


        public Score(SpriteFont font, Rectangle gameBoundaries,GameStateManager gameStateManager,string player1Name,string player2Name)
        {
            _font = font;
            _gameBoundaries = gameBoundaries;
            _gameStateManager = gameStateManager;
            Player1Name = player1Name;
            Player2Name = player2Name;
            _player1Score = 0;
            _player2Score = 0;
            _mediator.GameUpdated += ResetScoreEventHandler;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            string scoreText = $"{_player1Score} {Player1Name} : {Player2Name} {_player2Score}";
            float scoreTextXPosition = (_gameBoundaries.Width / 2) - _font.MeasureString(scoreText).X / 2;
            Vector2 scoreTextposition = new Vector2(scoreTextXPosition, _gameBoundaries.Height - 50);

            spriteBatch.DrawString(_font, scoreText, scoreTextposition, Color.Black);

            if (_gameStateManager.GameState == GameState.GameOver)
            {
                string wonGameText = $"{WhoWonGame()} won the game!";
                float wonGameXPosition = (_gameBoundaries.Width / 2) - _font.MeasureString(scoreText).X / 2;
                Vector2 wonGamePosition = new Vector2(wonGameXPosition, _gameBoundaries.Height/2);
                spriteBatch.DrawString(_font, wonGameText, wonGamePosition, Color.Black);
            }
        }

        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            
            if (gameObjects.Ball.Location.X + gameObjects.Ball.Width < 0)
            {
                _player2Score++;
                PlayerScored();
            }

            if (gameObjects.Ball.Location.X > _gameBoundaries.Width)
            {
                _player1Score++;
                PlayerScored();
            }

            if (_gameStateManager.GameState == GameState.GameActive)
            {
                if (_player1Score == MAX_SCORE | _player2Score == MAX_SCORE)
                {
                    GameWon();
                }
            }

        }

        private void ResetScoreEventHandler(object sender, GameUpdatedEventArgs e)
        {
            if (e.GameState == GameState.GameReset)
            {
                _player1Score = 0;
                _player2Score = 0;
            }
        }

        private void PlayerScored()
        {
            _mediator.OnGameUpdated(new GameUpdatedEventArgs {GameState = GameState.PlayerScored});
        }

        private void GameWon()
        {
            _mediator.OnGameUpdated(new GameUpdatedEventArgs{GameState = GameState.GameOver});
        }

        private string WhoWonGame()
        {
            if (_player1Score == MAX_SCORE)
            {
                return Player1Name;
            }
            if (_player2Score == MAX_SCORE)
            {
                return Player2Name;
            }
            return null;
        }
    }
}