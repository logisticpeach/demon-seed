using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public class SeedTextAttribute : SeedAttribute
    {
        public int DesiredLength { get; set; }

        public TextType DesiredType { get; set; }

        public SeedTextAttribute()
        {
            DesiredType = TextType.String;
            DesiredLength = 10;
        }

        public enum TextType
        {
            String,
            Paragraphs
        }
    }
}
