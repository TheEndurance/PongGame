using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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


        private GameObjects gameObjects;
        private GameCommands gameCommands;
        private InputHandler _player1InputHandler;
        private InputHandler _player2InputHandler;
        private InputHandler _ballInputHandler;
        private Paddle player1Paddle;
        private Paddle player2Paddle;
        private Paddle computerPaddle;
        private Ball ball;
        private Score score;
 

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
            gameCommands = new GameCommands();
            Rectangle gameBoundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");
            Vector2 player2PaddleLocation = new Vector2(gameBoundaries.Width - paddleTexture.Width, 0);
            _player1InputHandler =
                new InputHandler(new List<Func<Command>> {gameCommands.AKeyAction, gameCommands.ZKeyAction});
            _player2InputHandler =
                new InputHandler(new List<Func<Command>> {gameCommands.UpKeyAction, gameCommands.DownKeyAction});
            _ballInputHandler = new InputHandler(new List<Func<Command>> {gameCommands.ReleaseBall});
            

            player1Paddle = new Paddle(paddleTexture, Vector2.Zero, gameBoundaries,_player1InputHandler);
            player2Paddle = new Paddle(paddleTexture,player2PaddleLocation, gameBoundaries,_player2InputHandler);


            ball = new Ball(Content.Load<Texture2D>("ball"), new Vector2(100,100), new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height),_ballInputHandler);

            score = new Score(Content.Load<SpriteFont>("GameFont"), gameBoundaries,"Rawa Jalal","Satoshi Nakamoto");

            gameObjects = new GameObjects { Score = score, Player1Paddle = player1Paddle, Player2Paddle = player2Paddle, Ball = ball };
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


            player1Paddle.Update(gameTime, gameObjects);
            player2Paddle.Update(gameTime, gameObjects);
            ball.Update(gameTime, gameObjects);
            score.Update(gameTime, gameObjects);
            // TODO: Add your update logic here

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
            player1Paddle.Draw(spriteBatch);
            player2Paddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            score.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
