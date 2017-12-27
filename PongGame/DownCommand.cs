using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PongGame
{
    public class DownCommand : Command
    {
        private readonly float _downVelocity;

        public DownCommand(float downVelocity)
        {
            _downVelocity = downVelocity;
        }
        public override void Execute(Sprite sprite)
        {
            sprite.Velocity = new Vector2(sprite.Velocity.X, _downVelocity);
        }

        public override void Execute()
        {
            
        }
    }
}
