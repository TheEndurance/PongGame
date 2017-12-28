using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGame.GameObjects;
using PongGame.GameState;
using PongGame.InputCommands;
using PongGame.SoundState;

namespace PongGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //low level graphics engine 
        GraphicsDeviceManager graphics;
        //handles drawing sprites
        SpriteBatch spriteBatch;



        public GameStateManager GameStateManager;
        private SoundManager _soundManager;
        private GameObjects.GameObjects _gameObjects;
        private GameCommands _gameCommands;
        private InputHandler _player1InputHandler;
        private InputHandler _player2InputHandler;
        private InputHandler _ballInputHandler;
        private Paddle _player1Paddle;
        private Paddle _player2Paddle;
        private Paddle _computerPaddle;
        private Ball _ball;
        private Score _score;
        private SoundEffect _paddleBallHit;
        private SoundEffect _playerScored;
        private SoundEffect _applause;
 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _gameCommands = new GameCommands();
            GameStateManager = GameStateManager.GetGameStateManager();
            GameStateManager.InputHandler =
                new InputHandler(new List<Func<Command>> {_gameCommands.SpaceBarResetGameAction});
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            //Sounds
            _paddleBallHit = Content.Load<SoundEffect>("sounds/click");
            _playerScored = Content.Load<SoundEffect>("sounds/ding");
            _applause = Content.Load<SoundEffect>("sounds/applause1");

            _soundManager = new SoundManager(_paddleBallHit, _playerScored, _applause);

            //Textures
            Texture2D leftPaddleTexture = Content.Load<Texture2D>("images/BatLeft");
            Texture2D RightPaddleTexture = Content.Load<Texture2D>("images/BatRight");
            Texture2D ballTexture = Content.Load<Texture2D>("images/Ball");
            SpriteFont spriteFont = Content.Load<SpriteFont>("fonts/SpriteFont1");

            //Game boundary and starting locations
            Rectangle gameBoundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            Vector2 player1PaddleLocation = new Vector2(0, gameBoundaries.Height / 2.0f - leftPaddleTexture.Height/2.0f);
            Vector2 player2PaddleLocation = new Vector2(gameBoundaries.Width - RightPaddleTexture.Width, gameBoundaries.Height/2.0f - RightPaddleTexture.Height/2.0f);
            Vector2 ballLocation = new Vector2(gameBoundaries.Width / 2.0f - ballTexture.Width / 2.0f,
                gameBoundaries.Height / 2.0f - ballTexture.Height / 2.0f);

            //Input handlers
            _player1InputHandler =
                new InputHandler(new List<Func<Command>> {_gameCommands.AKeyAction, _gameCommands.ZKeyAction});
            _player2InputHandler =
                new InputHandler(new List<Func<Command>> {_gameCommands.UpKeyAction, _gameCommands.DownKeyAction});
            _ballInputHandler = new InputHandler(new List<Func<Command>> {_gameCommands.ReleaseBall});
           
            //Game objects
            _player1Paddle = new Paddle(leftPaddleTexture, player1PaddleLocation, gameBoundaries,_player1InputHandler);
            _player2Paddle = new Paddle(RightPaddleTexture, player2PaddleLocation, gameBoundaries,_player2InputHandler);
            _ball = new Ball(ballTexture, ballLocation, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height),_ballInputHandler);
            _score = new Score(spriteFont, gameBoundaries,GameStateManager,"Rawa Jalal","Satoshi Nakamoto");

            _gameObjects = new GameObjects.GameObjects { Score = _score, Player1Paddle = _player1Paddle, Player2Paddle = _player2Paddle, Ball = _ball };



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (GameStateManager.GameState == GameState.GameState.GameActive)
            {
                _player1Paddle.Update(gameTime, _gameObjects);
                _player2Paddle.Update(gameTime, _gameObjects);
                _ball.Update(gameTime, _gameObjects);
            }

            GameStateManager.Update(gameTime);
            _score.Update(gameTime, _gameObjects);
            


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            _player1Paddle.Draw(spriteBatch);
            _player2Paddle.Draw(spriteBatch);
            _ball.Draw(spriteBatch);
            _score.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
