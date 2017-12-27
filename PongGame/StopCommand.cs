using Microsoft.Xna.Framework;

namespace PongGame
{
    public class StopCommand : Command
    {
        public StopCommand()
        {
            
        }
        public override void Execute(Sprite sprite)
        {
            sprite.Velocity = new Vector2(0, 0);
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}