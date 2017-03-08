using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.DataProviders.Parameters
{
    class WordCountSeedRequestParameters : SeedRequestParamatersBase
    {
        public override SeedType SeedDataType { get { return SeedType.TextWithWordCount; } }

        public int WordCount { get; set; }
    }
}
