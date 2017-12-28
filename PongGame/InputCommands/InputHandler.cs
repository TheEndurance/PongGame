using System;
using System.Collections.Generic;

namespace PongGame.InputCommands
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
