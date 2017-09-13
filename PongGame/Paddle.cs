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
        private readonly PlayerTypes playerType;
        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds, PlayerTypes playerType) : base(texture, location, screenBounds)
        {
            this.playerType = playerType;
        }

        public override void Update(GameTime gameTime, GameObjects gameObject)
        {
            if (playerType == PlayerTypes.Computer)
            {
                if (gameObject.Ball.Location.Y + gameObject.Ball.Height < Location.Y)
                    Velocity = new Vector2(0, -3f);
                if (gameObject.Ball.Location.Y > Location.Y + Height)
                    Velocity = new Vector2(0, 3f);
            }
            if (playerType == PlayerTypes.Human)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    Velocity = new Vector2(0, -3f);

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    Velocity = new Vector2(0, 3f);
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