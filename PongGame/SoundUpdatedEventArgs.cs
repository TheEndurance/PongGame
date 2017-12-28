using System;

namespace PongGame
{
    public class SoundUpdatedEventArgs : EventArgs
    {
        public Sound Sound { get; set; }
    }
}