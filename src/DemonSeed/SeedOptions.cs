using System;
using System.Collections.Generic;
using System.Text;
using DemonSeed.DataProviders;
using DemonSeed.DataProviders.DefaultProviders;

namespace DemonSeed
{
    public class SeedOptions : ISeedOptions
    {
        public INameDataProvider NameProvder { get; set; }

        public ITextDataProvider TextProvider { get; set; }

        public SeedOptions()
        {
            NameProvder = new DefaultNameDataProvider();
            TextProvider = new DefaultTextDataProvider();
        }
    }
}
