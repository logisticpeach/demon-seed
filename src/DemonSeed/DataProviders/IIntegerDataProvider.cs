using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.DataProviders
{
    public interface IIntegerDataProvider
    {
        int GetInteger(int min, int max);
    }
}
