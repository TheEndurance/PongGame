using System;
using Microsoft.Xna.Framework;
using PongGame.GameObjects;

namespace PongGame.InputCommands
{
    public class ReleaseCommand : Command
    {
        private const int MAXIMUM_SPEED = 9;
        private const int MINIMUM_SPEED = 3;

        public ReleaseCommand()
        {

        }
        public override void Execute(Sprite sprite)
        {
            if (!(sprite.Velocity == new Vector2(0, 0))) return;

            float xVelocity;
            float yVelocity;
            int xDirection = 0;
            int yDirection = 0;
            Random rand = new Random();

            while (xDirection == 0)
            {
                xDirection = rand.Next(-1, 2);
            }
            while (yDirection == 0)
            {
                yDirection = rand.Next(-1, 2);
            }

            xVelocity = (float)(rand.NextDouble() * (MAXIMUM_SPEED - MINIMUM_SPEED) + MINIMUM_SPEED) * xDirection;
            yVelocity = (float)(rand.NextDouble() * (MAXIMUM_SPEED - MINIMUM_SPEED) + MINIMUM_SPEED) * yDirection;

            sprite.Velocity = new Vector2(xVelocity, yVelocity);

        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
