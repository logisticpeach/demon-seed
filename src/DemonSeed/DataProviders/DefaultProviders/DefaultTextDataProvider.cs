﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("DemonSeed.Tests")]

namespace DemonSeed.DataProviders.DefaultProviders
{
    internal class DefaultTextDataProvider : ITextDataProvider
    {
        private ResourceModels.TextResourceJsonModel _sampleTextDocument;

        public DefaultTextDataProvider()
        {
            try
            {
                Assembly targetAssembly = typeof(DefaultTextDataProvider).GetTypeInfo().Assembly;

                using (var resourceStream = targetAssembly.GetManifestResourceStream("DemonSeed.Resources.text.json"))
                {
                    using (StreamReader reader = new StreamReader(resourceStream))
                    {
                        string rawJson = reader.ReadToEnd();

                        _sampleTextDocument = JsonConvert.DeserializeObject<ResourceModels.TextResourceJsonModel>(rawJson);
                    }
                }
            }
            catch(Exception e)
            {
                throw new InvalidOperationException("An unexpected error ocurred while initialising the default text provider", e);
            }
        }

        public string GetParagraphs(int paragraphCount)
        {
            if (paragraphCount < 0)
                throw new ArgumentOutOfRangeException("paragraphCount", "The paragraph count must be non-negative");

            int numParas = _sampleTextDocument.Paragraphs.Count;

            if (paragraphCount > numParas)
                throw new ArgumentOutOfRangeException("paragraphCount", $"Cannot generate {paragraphCount} paragraphs - maximum supported by provider is {numParas}");

            int startingMargin = numParas - paragraphCount;
            int startIndex = 0;

            if (startingMargin > 1)
            {
                startIndex = RandomHelper.Generator.Next(startIndex, startingMargin);
            }

            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < paragraphCount; i++)
            {
                int offset = i + startIndex;
                resultBuilder.Append(_sampleTextDocument.Paragraphs[offset].WriteToString());

                // TODO - control the whitespace via options.
                if (i < paragraphCount - 1)
                {
                    resultBuilder.Append(Environment.NewLine);
                    resultBuilder.Append(Environment.NewLine);
                }
            }

            return resultBuilder.ToString().Trim(' ').TrimEnd('"');
        }

        public string GetWords(int wordCount)
        {
            if (wordCount < 0)
                throw new ArgumentOutOfRangeException("wordCount", "Word count must be non-negative");

            if (wordCount == 0)
                return string.Empty;

            var qualifyingParagraphsForSample = _sampleTextDocument.Paragraphs.Where(x => x.Words.Count >= wordCount).ToList();

            if (qualifyingParagraphsForSample.Count == 0)
            {
                int maxWords = _sampleTextDocument.Paragraphs.OrderByDescending(x => x.Words.Count).First().Words.Count;
                throw new ArgumentOutOfRangeException("wordCount", $"Cannot generate a string of this length, the maximum supported by this provider is {maxWords} words");
            }

            int index = 0;

            if (qualifyingParagraphsForSample.Count > 1)
            {
                index = RandomHelper.Generator.Next(0, qualifyingParagraphsForSample.Count);
            }

            var words = qualifyingParagraphsForSample[index].Words.Take(wordCount);

            StringBuilder resultBuilder = new StringBuilder();

            foreach (var w in words)
                resultBuilder.Append(w).Append(" ");

            return resultBuilder.ToString().Trim(' ').Trim('"');

        }
    }
}
