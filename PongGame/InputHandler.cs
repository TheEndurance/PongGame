using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class InputHandler
    {
        private readonly List<Func<Command>> _inputDelegates;
        public InputHandler(List<Func<Command>> inputDelegates)
        {
            _inputDelegates = inputDelegates;
        }

        public Command HandleInput()
        {
            foreach (Func<Command> inputDelegate in _inputDelegates)
            {
                Command command = inputDelegate();
                if (command != null)
                {
                    return command;
                }
            }
            return null;
        }
    }
}
