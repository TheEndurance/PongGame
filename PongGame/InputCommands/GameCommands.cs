/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using Microsoft.Xna.Framework.Input;

namespace PongGame.InputCommands
{
    /// <summary>
    /// Encapsulates all of the game commands that players can trigger with input
    /// </summary>
    public class GameCommands
    {
        private float _moveUpVelocity = -6.5f;
        private float _moveDownVelocity = 6.5f;

        /// <summary>
        /// Constructor for the GameCommands class
        /// </summary>
        public GameCommands()
        {

        }

        /// <summary>
        /// Game command for pressing the Enter key
        /// </summary>
        /// <returns>ReleaseCommand Command object</returns>
        public Command ReleaseBall()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return new ReleaseCommand();
            }
            return null;
        }

        /// <summary>
        /// Game command for pressing the up key
        /// </summary>
        /// <returns>UpCommand Command object</returns>
        public Command UpKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                return new UpCommand(_moveUpVelocity);
            }
            return null;
        }

        /// <summary>
        /// Game command for pressing the down key
        /// </summary>
        /// <returns>DownCommand Command object</returns>
        public Command DownKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                return new DownCommand(_moveDownVelocity);
            }
            return null;
        }

        /// <summary>
        /// Game command for pressing the A key
        /// </summary>
        /// <returns>UpCommand Command object</returns>
       public Command AKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                return new UpCommand(_moveUpVelocity);
            }
            return null;
        }

        /// <summary>
        /// Game command for pressing the Z key
        /// </summary>
        /// <returns>DownCommand Command object</returns>
        public Command ZKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                return new DownCommand(_moveDownVelocity);
            }
            return null;
        }

        /// <summary>
        /// Game command for pressing the Space key
        /// </summary>
        /// <returns>ResetGameCommand Command object</returns>
        public Command SpaceBarResetGameAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                return new ResetGameCommand(GameState.GameStateManager.GetGameStateManager().GameState); 
            }
            return null;
        }
    }
}
