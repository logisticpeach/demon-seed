using System;
using System.Collections.Generic;
using System.Text;
using DemonSeed.DataProviders;

namespace DemonSeed
{
    public interface ISeedOptions
    {
        INameDataProvider NameProvder { get; }

        ITextDataProvider TextProvider { get; }
    }
}
