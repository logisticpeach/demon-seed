using DemonSeed.DataProviders.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public class SeedFirstNameAttribute : SeedNameAttribute
    {
        public SeedFirstNameAttribute() : base(NameType.FirstName) { }
    }
}
