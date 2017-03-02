using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public class SeedDoubleAttribute : SeedAttribute
    {
        public double MinValue { get; set; }

        public double MaxValue { get; set; }
    }
}
