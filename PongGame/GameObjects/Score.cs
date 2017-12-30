/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGame.GameState;
using PongGame.SoundState;

namespace PongGame.GameObjects
{
    /// <summary>
    /// Manages the score and game text
    /// </summary>
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

        /// <summary>
        /// Constructor for the score class
        /// </summary>
        /// <param name="font">SpriteFont used as the font for the game</param>
        /// <param name="gameBoundaries">Rectangle that specifies the boundaries of the game</param>
        /// <param name="gameStateManager">GameStateManager which contains the game state</param>
        /// <param name="player1Name">String, the name of player 1</param>
        /// <param name="player2Name">String, the name of player 2</param>
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

        /// <summary>
        /// Draws the score on the screen
        /// </summary>
        /// <param name="spriteBatch">Helper class responsible for drawing the font</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            string scoreText = $"{_player1Score} {Player1Name} : {Player2Name} {_player2Score}";
            float scoreTextXPosition = (_gameBoundaries.Width / 2.0f) - _font.MeasureString(scoreText).X / 2;
            Vector2 scoreTextposition = new Vector2(scoreTextXPosition, _gameBoundaries.Height - 50);

            spriteBatch.DrawString(_font, scoreText, scoreTextposition, Color.White);

            if (_gameStateManager.GameState == GameState.GameState.GameOver)
            {
                string wonGameText = $"{WhoWonGame()} won the game!";
                float wonGameXPosition = (_gameBoundaries.Width / 2.0f) - _font.MeasureString(wonGameText).X / 2;
                Vector2 wonGamePosition = new Vector2(wonGameXPosition, 100);
                spriteBatch.DrawString(_font, wonGameText, wonGamePosition, Color.White);
            }
        }

        /// <summary>
        /// Updates the score text during the game
        /// </summary>
        /// <param name="gameTime">GameTime represents the time in the game</param>
        /// <param name="gameObjects">GameObjects encapsulates all of the game sprites and objects</param>
        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            
            if (gameObjects.Ball.Location.X + gameObjects.Ball.Width < 0)
            {
                _player2Score++;
                _mediator.OnSoundUpdated(new SoundUpdatedEventArgs { Sound = Sound.PlayerScored });
                PlayerScored();
            }

            if (gameObjects.Ball.Location.X > _gameBoundaries.Width)
            {
                _player1Score++;
                _mediator.OnSoundUpdated(new SoundUpdatedEventArgs { Sound = Sound.PlayerScored });
                PlayerScored();
            }

            if (_gameStateManager.GameState == GameState.GameState.GameActive)
            {
                if (_player1Score == MAX_SCORE | _player2Score == MAX_SCORE)
                {
                    _mediator.OnSoundUpdated(new SoundUpdatedEventArgs {Sound = Sound.GameWon});
                    GameWon();
                }
            }

        }

        /// <summary>
        /// Event handler for GameUpdate event which Resets the score
        /// </summary>
        /// <param name="sender">Object that called the event</param>
        /// <param name="e">The game update event arguments, which contains the GameState enum</param>
        private void ResetScoreEventHandler(object sender, GameUpdatedEventArgs e)
        {
            if (e.GameState == GameState.GameState.GameReset)
            {
                _player1Score = 0;
                _player2Score = 0;
            }
        }


        /// <summary>
        /// Triggers the GameUpdated Event with GameState.PlayerScored event arguments
        /// </summary>
        private void PlayerScored()
        {
            _mediator.OnGameUpdated(new GameUpdatedEventArgs {GameState = GameState.GameState.PlayerScored});
        }

        /// <summary>
        /// Triggers the GameUpdated Event with GameState.GameOver event arguments
        /// </summary>
        private void GameWon()
        {
            _mediator.OnGameUpdated(new GameUpdatedEventArgs{GameState = GameState.GameState.GameOver});
        }

        /// <summary>
        /// Determines which player won the game
        /// </summary>
        /// <returns>Name of player</returns>
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