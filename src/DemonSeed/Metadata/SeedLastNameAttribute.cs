using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public class SeedLastNameAttribute : SeedNameAttribute
    {
        public SeedLastNameAttribute() : base(NameType.LastName) { }
    }
}
