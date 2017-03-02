using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public class SeedIntegerAttribute : SeedAttribute
    {
        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public SeedIntegerAttribute() { }
    }
}
