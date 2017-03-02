using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.DataProviders.DefaultProviders.ResourceModels
{
    class TextResourceJsonModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("paragraphs")]
        public List<ParagraphModel> Paragraphs { get; set; }

        public TextResourceJsonModel()
        {
            Paragraphs = new List<ParagraphModel>();
        }
    }

    class ParagraphModel
    {
        [JsonProperty("words")]
        public List<string> Words { get; set; }

        public ParagraphModel()
        {
            Words = new List<string>();
        }

        public string WriteToString()
        {
            if (Words.Count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < Words.Count; i++)
            {
                sb.Append(Words[i]);

                if (i < (Words.Count - 1))
                    sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}
