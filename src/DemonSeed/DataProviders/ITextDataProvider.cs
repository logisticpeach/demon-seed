using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.DataProviders
{
    public interface ITextDataProvider
    {
        string GetWords(int wordCount);

        string GetParagraphs(int paragraphCount);
    }
}
