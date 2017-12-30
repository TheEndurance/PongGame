/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using Microsoft.Xna.Framework.Audio;

namespace PongGame.SoundState
{
    /// <summary>
    /// Manages the sounds in the game
    /// </summary>
    public class SoundManager
    {
        private Mediator _mediator;
        private SoundEffect _paddleBallHit;
        private SoundEffect _playerScored;
        private SoundEffect _applause;

        /// <summary>
        /// Constructor for the sound manager class
        /// </summary>
        /// <param name="paddleBallHit">paddle ball sound effect</param>
        /// <param name="playerScored">player scored sound effect</param>
        /// <param name="applause">applause sound effect</param>
        public SoundManager(SoundEffect paddleBallHit, SoundEffect playerScored, SoundEffect applause)
        {
            _mediator = Mediator.GetMediator();
            _paddleBallHit = paddleBallHit;
            _playerScored = playerScored;
            _applause = applause;
            _mediator.SoundUpdated += ManageGameSounds;
        }

        /// <summary>
        /// Event handler that determines which sound effect to play
        /// </summary>
        /// <param name="sender">The event calling object</param>
        /// <param name="e">The sound updated event arguments containing the Sound enumeration</param>
        private void ManageGameSounds(object sender, SoundUpdatedEventArgs e)
        {
            switch (e.Sound)
            {
                case Sound.PaddleBallCollision:
                    _paddleBallHit.Play();
                    break;
                case Sound.PlayerScored:
                    _playerScored.Play();
                    break;
                case Sound.GameWon:
                    _applause.Play();
                    break;
            }
        }

    }
}
