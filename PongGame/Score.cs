using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public class Score
    {
        private const int MAX_SCORE = 2;
        private readonly SpriteFont _font;
        private readonly Rectangle _gameBoundaries;
        private readonly GameStateManager _gameStateManager;

        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }


        public Score(SpriteFont font, Rectangle gameBoundaries,GameStateManager gameStateManager,string player1Name,string player2Name)
        {
            _font = font;
            _gameBoundaries = gameBoundaries;
            _gameStateManager = gameStateManager;
            Player1Name = player1Name;
            Player2Name = player2Name;
            Mediator.GetMediator().GameUpdated += ResetScoreEventHandler;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            string scoreText = $"{Player1Score} {Player1Name} : {Player2Name} {Player2Score}";
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
                Player2Score++;
                gameObjects.Ball.ResetBall();
            }

            if (gameObjects.Ball.Location.X > _gameBoundaries.Width)
            {
                Player1Score++;
                gameObjects.Ball.ResetBall();
            }

            if (_gameStateManager.GameState == GameState.GameActive)
            {
                if (Player1Score == MAX_SCORE | Player2Score == MAX_SCORE)
                {
                    GameWon();
                }
            }

        }

        private void ResetScoreEventHandler(object sender, GameUpdatedEventArgs e)
        {
            if (e.GameState == GameState.GameActive)
            {
                Player1Score = 0;
                Player2Score = 0;
            }
        }

        private void GameWon()
        {
            Mediator.GetMediator().OnGameUpdated(new GameUpdatedEventArgs{GameState = GameState.GameOver});
        }

        private string WhoWonGame()
        {
            if (Player1Score == MAX_SCORE)
            {
                return Player1Name;
            }
            if (Player2Score == MAX_SCORE)
            {
                return Player2Name;
            }
            return null;
        }
    }
}