/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using System;
using Microsoft.Xna.Framework;
using PongGame.GameObjects;

namespace PongGame.InputCommands
{
    /// <summary>
    /// A command that describes the behaviour for releasing a ball
    /// </summary>
    public class ReleaseCommand : Command
    {
        private const int MAXIMUM_SPEED = 9;
        private const int MINIMUM_SPEED = 3;

        /// <summary>
        /// Constructor for the ReleaseCommand class
        /// </summary>
        public ReleaseCommand()
        {

        }

        /// <summary>
        /// Executes the release behaviour
        /// </summary>
        /// <param name="sprite">The sprite entity to execute the behaviour on</param>
        public override void Execute(Sprite sprite)
        {
            if (!(sprite.Velocity == new Vector2(0, 0))) return;

            float xVelocity;
            float yVelocity;
            int xDirection = 0;
            int yDirection = 0;
            Random rand = new Random();

            while (xDirection == 0)
            {
                xDirection = rand.Next(-1, 2);
            }
            while (yDirection == 0)
            {
                yDirection = rand.Next(-1, 2);
            }

            xVelocity = (float)(rand.NextDouble() * (MAXIMUM_SPEED - MINIMUM_SPEED) + MINIMUM_SPEED) * xDirection;
            yVelocity = (float)(rand.NextDouble() * (MAXIMUM_SPEED - MINIMUM_SPEED) + MINIMUM_SPEED) * yDirection;

            sprite.Velocity = new Vector2(xVelocity, yVelocity);

        }

        /// <summary>
        /// Executes the release behaviour
        /// </summary>
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
