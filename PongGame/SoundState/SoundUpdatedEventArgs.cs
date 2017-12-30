/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using System;

namespace PongGame.SoundState
{
    /// <inheritdoc />
    /// <summary>
    /// Custom event args for the SoundUpdated event
    /// </summary>
    public class SoundUpdatedEventArgs : EventArgs
    {
        public Sound Sound { get; set; }
    }
}