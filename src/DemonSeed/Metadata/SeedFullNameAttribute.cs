using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public class SeedFullNameAttribute : SeedNameAttribute
    {
        public SeedFullNameAttribute() : base(NameType.FullName) { }
    }
}
