using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class GameCommands
    {
        private float _moveUpVelocity = -6.5f;
        private float _moveDownVelocity = 6.5f;
        private readonly UpCommand _upCommand;
        private readonly DownCommand _downCommand;
        private readonly ReleaseCommand _releaseCommand;
        private readonly StopCommand _stopCommand;

        public GameCommands()
        {
            _upCommand = new UpCommand(_moveUpVelocity);
            _downCommand = new DownCommand(_moveDownVelocity);
            _releaseCommand = new ReleaseCommand();
            _stopCommand = new StopCommand();

        }

        public Command ReleaseBall()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return _releaseCommand;
            }
            return null;
        }

        public Command UpKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                return _upCommand;
            }
            return null;
        }
        public Command DownKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                return _downCommand;
            }
            return null;
        }
       public Command AKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                return _upCommand;
            }
            return null;
        }

        public Command ZKeyAction ()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                return _downCommand;
            }
            return null;
        }
    }
}
