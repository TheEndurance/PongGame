/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using Microsoft.Xna.Framework;
using PongGame.GameObjects;

namespace PongGame.InputCommands
{
    /// <summary>
    /// A command that describes the behaviour of going down the y-axis
    /// </summary>
    public class DownCommand : Command
    {
        private readonly float _downVelocity;

        /// <summary>
        /// Constructor for the DownCommand class
        /// </summary>
        /// <param name="downVelocity"></param>
        public DownCommand(float downVelocity)
        {
            _downVelocity = downVelocity;
        }

        /// <summary>
        /// Executes the behaviour
        /// </summary>
        /// <param name="sprite">The sprite entity to execute the behaviour on</param>
        public override void Execute(Sprite sprite)
        {
            sprite.Velocity = new Vector2(sprite.Velocity.X, _downVelocity);
        }

        /// <summary>
        /// Executes the behaviour
        /// </summary>
        public override void Execute()
        {
            
        }
    }
}
