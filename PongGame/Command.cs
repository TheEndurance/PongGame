﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    public abstract class Command
    {
        public abstract void Execute(Sprite sprite);
        public abstract void Execute();
    }
}
