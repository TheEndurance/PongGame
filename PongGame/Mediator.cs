/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongGame.GameState;
using PongGame.SoundState;

namespace PongGame
{
    /// <summary>
    /// Mediator class which is responsible for mediating event handling
    /// </summary>
    public class Mediator
    {
        private static readonly Mediator _instance = new Mediator();

        /// <summary>
        /// Constructor for mediator class
        /// </summary>
        private Mediator()
        {
            
        }

        /// <summary>
        /// Static method responsible for retrieving the singleton instance of Mediator
        /// </summary>
        /// <returns>The singleton instance of the Mediator</returns>
        public static Mediator GetMediator()
        {
            return _instance;
        }

        public delegate void GameUpdatedHandler(object sender, GameUpdatedEventArgs e);

        public delegate void SoundUpdatedHandler(object sender, SoundUpdatedEventArgs e);

        public event SoundUpdatedHandler SoundUpdated;

        public event GameUpdatedHandler GameUpdated;

        /// <summary>
        /// Triggers the GameUpdated event
        /// </summary>
        /// <param name="args">The event arguments for a game update</param>
        public void OnGameUpdated(GameUpdatedEventArgs args)
        {
            if (GameUpdated != null)
            {
                GameUpdated.Invoke(this, args);
            }
        }

        /// <summary>
        /// Triggers the SoundUpdated event
        /// </summary>
        /// <param name="args">The event arguments for a sound update</param>
        public void OnSoundUpdated(SoundUpdatedEventArgs args)
        {
            if (SoundUpdated != null)
            {
                SoundUpdated.Invoke(this, args);
            }
        }
    }
}
