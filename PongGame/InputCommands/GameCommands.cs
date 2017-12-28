using Microsoft.Xna.Framework.Input;

namespace PongGame.InputCommands
{
    public class GameCommands
    {
        private float _moveUpVelocity = -6.5f;
        private float _moveDownVelocity = 6.5f;

        public GameCommands()
        {

        }

        public Command ReleaseBall()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return new ReleaseCommand();
            }
            return null;
        }

        public Command UpKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                return new UpCommand(_moveUpVelocity);
            }
            return null;
        }
        public Command DownKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                return new DownCommand(_moveDownVelocity);
            }
            return null;
        }
       public Command AKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                return new UpCommand(_moveUpVelocity);
            }
            return null;
        }

        public Command ZKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                return new DownCommand(_moveDownVelocity);
            }
            return null;
        }
        public Command SpaceBarResetGameAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                return new ResetGameCommand();
            }
            return null;
        }
    }
}
