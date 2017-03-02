using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.DataProviders
{
    public interface IDateTimeDataProvider
    {
        DateTimeOffset GetDate(DateTimeOffset min, DateTimeOffset max);
    }
}
