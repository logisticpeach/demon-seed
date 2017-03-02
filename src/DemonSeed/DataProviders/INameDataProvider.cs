using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.DataProviders
{
    public interface INameDataProvider
    {
        string GetFirstName();

        string GetLastName();
    }
}
