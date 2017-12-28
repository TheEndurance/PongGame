using System;
using Microsoft.Xna.Framework;
using PongGame.GameObjects;

namespace PongGame.InputCommands
{
    public class UpCommand : Command
    {
        private readonly float _upVelocity;

        public UpCommand(float upVelocity)
        {
            _upVelocity = upVelocity;
        }
        public override void Execute(Sprite sprite)
        {
            sprite.Velocity = new Vector2(sprite.Velocity.X, _upVelocity);
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
