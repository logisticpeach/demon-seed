using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed
{
    internal static class RandomHelper
    {
        static Random _generator;

        static RandomHelper()
        {
            _generator = new Random(DateTimeOffset.Now.Millisecond);
        }

        public static Random Generator { get { return _generator; } }
    }
}
