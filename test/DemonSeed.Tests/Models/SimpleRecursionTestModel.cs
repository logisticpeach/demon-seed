using DemonSeed.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Tests.Models
{
    class SimpleRecursionTestModel : FlatTestModel
    {
        public FlatTestModel BestFriend { get; set; }
    }
}
