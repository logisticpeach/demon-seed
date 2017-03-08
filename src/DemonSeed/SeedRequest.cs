using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DemonSeed
{
    class SeedRequest 
    {
        public SeedType RequestedSeedType { get; set; }
        public SeedRequestParamatersBase Parameters { get; set; }
        public Type TargetType { get; set; }
    }
}
