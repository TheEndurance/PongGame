/* 
 * Programmer: Rawa Jalal
 * Revision History:
 *          12/25/2017: Created
 *          
 */
using PongGame.GameObjects;

namespace PongGame.InputCommands
{
    /// <summary>
    /// Abstract command class that encapsulates game behaviour
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute(Sprite sprite);
        public abstract void Execute();
    }
}
