using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.DataProviders.Parameters
{
    internal class FirstNameSeedRequestParamaters : SeedRequestParamatersBase
    {
        public override SeedType SeedDataType { get { return SeedType.FirstName; } }
    }
}
