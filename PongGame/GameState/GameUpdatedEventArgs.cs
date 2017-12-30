/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using System;

namespace PongGame.GameState
{
    /// <inheritdoc />
    /// <summary>
    /// Custom event arguments for the SoundUpdated event
    /// </summary>
    public class GameUpdatedEventArgs : EventArgs
    {
        public GameState GameState { get; set; }
    }
}
