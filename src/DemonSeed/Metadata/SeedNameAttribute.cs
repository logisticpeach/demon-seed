using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public abstract class SeedNameAttribute : SeedAttribute
    {
        public NameType Type { get; set; }

        public SeedNameAttribute()
        {
            Type = NameType.FullName;
        }

        public SeedNameAttribute(NameType type)
        {
            Type = type;
        }

        public enum NameType
        {
            FirstName,
            LastName,
            FullName
        }
    }
}
