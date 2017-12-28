using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace PongGame
{
    public class SoundManager
    {
        private Mediator _mediator;
        private SoundEffect _paddleBallHit;
        private SoundEffect _playerScored;
        private SoundEffect _applause;

        public SoundManager(SoundEffect paddleBallHit, SoundEffect playerScored, SoundEffect applause)
        {
            _mediator = Mediator.GetMediator();
            _paddleBallHit = paddleBallHit;
            _playerScored = playerScored;
            _applause = applause;
            _mediator.SoundUpdated += ManageGameSounds;
        }

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
