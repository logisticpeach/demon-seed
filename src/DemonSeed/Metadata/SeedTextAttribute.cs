using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Metadata
{
    public class SeedTextAttribute : SeedAttribute
    {
        public int DesiredLength { get; set; }

        public TextType DesiredType { get; set; }

        public override SeedType SeedDataType
        {
            get
            {
                switch(DesiredType)
                {
                    case TextType.Paragraphs:
                        return SeedType.TextWithParagraphCount;
                    default:
                        return SeedType.TextWithWordCount;
                }
            }
        }

        internal override SeedRequestParamatersBase GetParameters()
        {
            switch (DesiredType)
            {
                case TextType.Paragraphs:
                    {
                        return new DataProviders.Parameters.ParagraphSeedRequestParameters()
                        {
                            ParagraphCount = DesiredLength
                        };
                    }
                default:
                    {
                        return new DataProviders.Parameters.WordCountSeedRequestParameters()
                        {
                            WordCount = DesiredLength
                        };
                    }
            }
        }

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
