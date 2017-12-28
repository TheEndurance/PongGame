using System;

namespace PongGame.SoundState
{
    public class SoundUpdatedEventArgs : EventArgs
    {
        public Sound Sound { get; set; }
    }
}