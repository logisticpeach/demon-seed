using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public class SeedCollectionAttribute : Attribute
    {
        public int Count { get; set; }
    }
}
