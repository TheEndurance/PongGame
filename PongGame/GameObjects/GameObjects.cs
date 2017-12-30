/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
namespace PongGame.GameObjects
{
    /// <summary>
    /// Contains the Game objects
    /// </summary>
    public class GameObjects
    {
        public Paddle Player1Paddle { get; set; }
        public Ball Ball { get; set; }
        public Score Score { get; set; }
        public Paddle Player2Paddle { get; set; }

        /// <summary>
        /// Constructor for the GameObjects class
        /// </summary>
        public GameObjects()
        {
            
        }
    }
}
