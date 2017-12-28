using PongGame.GameObjects;

namespace PongGame.InputCommands
{
    public abstract class Command
    {
        public abstract void Execute(Sprite sprite);
        public abstract void Execute();
    }
}
