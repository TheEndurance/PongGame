using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    public class Mediator
    {
        private static readonly Mediator _instance = new Mediator();

        private Mediator()
        {
            
        }

        public static Mediator GetMediator()
        {
            return _instance;
        }

        public delegate void GameUpdatedHandler(object sender, GameUpdatedEventArgs e);

        public delegate void SoundUpdatedHandler(object sender, SoundUpdatedEventArgs e);

        public event SoundUpdatedHandler SoundUpdated;

        public event GameUpdatedHandler GameUpdated;

        public void OnGameUpdated(GameUpdatedEventArgs args)
        {
            if (GameUpdated != null)
            {
                GameUpdated.Invoke(this, args);
            }
        }

        public void OnSoundUpdated(SoundUpdatedEventArgs args)
        {
            if (SoundUpdated != null)
            {
                SoundUpdated.Invoke(this, args);
            }
        }
    }
}
