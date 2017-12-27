using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    public class GameUpdatedEventArgs : EventArgs
    {
        public GameState GameState { get; set; }
    }
}
