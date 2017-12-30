/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame.GameObjects
{
    /// <summary>
    /// Abstract class for all sprites in the game
    /// </summary>
    public abstract class Sprite
    {
        protected readonly Texture2D Texture;
        public Vector2 Location;
        public int Width { get { return Texture.Width; } }
        public int Height { get { return Texture.Height; } }
        public Vector2 Velocity { get; set; }
        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)Location.X, (int)Location.Y, Width, Height); }
        }
        public Rectangle GameBoundaries { get; }

        /// <summary>
        /// Constructor for the Sprite class
        /// </summary>
        /// <param name="texture">Texture2D which represents the texture for the sprite</param>
        /// <param name="location">Vector2D which represents the location of the sprite</param>
        /// <param name="gameBoundaries">Rectangle which represents the game boundaries which the sprite can exist in</param>
        protected Sprite(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
        {
            Texture = texture;
            Location = location;
            Velocity = Vector2.Zero;
            GameBoundaries = gameBoundaries;
        }

        /// <summary>
        /// Draws the sprite during the game loop
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch helper class which draws the sprite</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
        }

        /// <summary>
        /// Updates the sprite in the game loop
        /// </summary>
        /// <param name="gameTime">GameTime which represents the game time</param>
        /// <param name="gameObjects">GameObjects which is a class that encapsulates all objects in the game</param>
        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Location += Velocity;
            CheckBounds();
        }

        /// <summary>
        /// Abstract method which is meant to check if the sprite is within the game boundaries
        /// </summary>
        protected abstract void CheckBounds();

        /// <summary>
        /// Abstract method which is meant to reset the sprite to it's initial location
        /// </summary>
        public abstract void ResetPosition();


    }


}
