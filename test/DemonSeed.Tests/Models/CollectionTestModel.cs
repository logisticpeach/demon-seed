using DemonSeed.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Tests.Models
{
    class CollectionTestModel : FlatTestModel
    {
        [SeedCollection(Count = 3)]
        public IList<FlatTestModel> Friends { get; set; }
    }
}
