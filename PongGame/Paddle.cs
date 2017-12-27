using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public enum PlayerTypes
    {
        Human,
        Computer
    }
    public class Paddle : Sprite
    {
        private readonly InputHandler _inputHandler;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds,InputHandler inputHandler) : base(texture, location, screenBounds)
        {
            _inputHandler = inputHandler;
        }

        public override void Update(GameTime gameTime, GameObjects gameObject)
        {
            Command command = _inputHandler.HandleInput();
            Velocity = new Vector2(0, 0);
            if (command != null)
            {
                command.Execute(this);
            }
            

            base.Update(gameTime, gameObject); //this updates the location
        }

        protected override void CheckBounds()
        {
            //if our location.Y is between 0 and the screenbound height - playerPaddle height, then its fine, else it will be set to either to 0, or screenbound.height-texture.height
            Location.Y = MathHelper.Clamp(Location.Y, 0, GameBoundaries.Height - this.Height);
        }
    }
}