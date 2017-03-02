using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.DataProviders.DefaultProviders.ResourceModels
{
    public class NameResourceJsonModel
    {
        [JsonProperty("first_names")]
        public List<string> FirstNames { get; set; }

        [JsonProperty("last_names")]
        public List<string> LastNames { get; set; }

        public NameResourceJsonModel()
        {
            FirstNames = new List<string>();
            LastNames = new List<string>();
        }
    }
}
