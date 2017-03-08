using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed
{
    interface IPropertyValueInterceptor
    {
        object GenerateValue(SeedRequest request);

        SeedType TargetType { get; }
    }
}
