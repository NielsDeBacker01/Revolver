﻿using Revolver.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Interfaces
{
    internal interface IAnimate
    {
        public int currentFrameIndex { get; set; }
    }
}
