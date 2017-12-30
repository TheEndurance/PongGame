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
    /// A command that describes the behaviour of moving up on the y-axis
    /// </summary>
    public class UpCommand : Command
    {
        private readonly float _upVelocity;

        /// <summary>
        /// Constructor for UpCommand
        /// </summary>
        /// <param name="upVelocity">The velocity to move up on the y-axis by</param>
        public UpCommand(float upVelocity)
        {
            _upVelocity = upVelocity;
        }


        /// <summary>
        /// Executes the behaviour
        /// </summary>
        /// <param name="sprite">The sprite entity to execute the behaviour on</param>
        public override void Execute(Sprite sprite)
        {
            sprite.Velocity = new Vector2(sprite.Velocity.X, _upVelocity);
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
