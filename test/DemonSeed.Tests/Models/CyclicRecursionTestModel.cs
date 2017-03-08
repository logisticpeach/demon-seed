using DemonSeed.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Tests.Models
{
    class CyclicRecursionTestModel
    {
        [SeedFirstName]
        public string Name { get; set; }

        public CyclicRecursionTestModel Child { get; set; }
    }
}
