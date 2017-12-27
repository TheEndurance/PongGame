using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public class Score
    {
        private const int MAX_SCORE = 2;
        private bool showGameWonText;
        private double timeSinceGameWon = 0d;
        private readonly SpriteFont _font;
        private readonly Rectangle _gameBoundaries;

        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }


        public Score(SpriteFont font, Rectangle gameBoundaries,string player1Name,string player2Name)
        {
            _font = font;
            _gameBoundaries = gameBoundaries;
            Player1Name = player1Name;
            Player2Name = player2Name;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var scoreText = $"{Player1Score} {Player1Name} : {Player2Name} {Player2Score}";
            var xPosition = (_gameBoundaries.Width / 2) - _font.MeasureString(scoreText).X / 2;
            var position = new Vector2(xPosition, _gameBoundaries.Height - 50);

            spriteBatch.DrawString(_font, scoreText, position, Color.Black);

            if (showGameWonText)
            {
                string wonGameText = $"{WhoWonGame()} won the game!";
                var x = (_gameBoundaries.Width / 2) - _font.MeasureString(scoreText).X / 2;
                var wonPosition = new Vector2(xPosition, _gameBoundaries.Height/2);

                spriteBatch.DrawString(_font, wonGameText, wonPosition, Color.Black);
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

            if (Player1Score == MAX_SCORE)
            {
                GameWon(gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (Player2Score == MAX_SCORE)
            {
                GameWon(gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        public void GameWon( double totalSeconds)
        {
            showGameWonText = true;
            timeSinceGameWon += totalSeconds;
            if (timeSinceGameWon > 2d)
            {
                ResetScores();
            }
        }

        public string WhoWonGame()
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

        public void ResetScores()
        {
            Player1Score = 0;
            Player2Score = 0;
            timeSinceGameWon = 0d;
            showGameWonText = false;
        }
    }
}