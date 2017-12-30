/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using System;
using System.Collections.Generic;

namespace PongGame.InputCommands
{
    /// <summary>
    /// Handles input from players
    /// </summary>
    public class InputHandler
    {
        private readonly List<Func<Command>> _inputDelegates;
        
        /// <summary>
        /// Constructor for InputHandler
        /// </summary>
        /// <param name="inputDelegates">A list of delegate methods that return a Command object</param>
        public InputHandler(List<Func<Command>> inputDelegates)
        {
            _inputDelegates = inputDelegates;
        }

        /// <summary>
        /// Iterates over the list of delegate methods to determine if an input has been triggered
        /// </summary>
        /// <returns>If an input has been triggered a Command object is returned to the caller</returns>
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
