using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DemonSeed.DataProviders.DefaultProviders
{
    internal class DefaultNameDataProvider : INameDataProvider
    {
        private ResourceModels.NameResourceJsonModel _nameDocument;

        public DefaultNameDataProvider()
        {
            try
            {
                var assembly = typeof(DefaultNameDataProvider).GetTypeInfo().Assembly;

                using (var resourceStream = assembly.GetManifestResourceStream("DemonSeed.Resources.names.json"))
                {
                    using (var reader = new StreamReader(resourceStream))
                    {
                        string rawJson = reader.ReadToEnd();
                        _nameDocument = JsonConvert.DeserializeObject<ResourceModels.NameResourceJsonModel>(rawJson);
                    }
                }
            }
            catch(Exception e)
            {
                throw new InvalidOperationException("An unexpected error ocurred while initialising the default name provider", e);
            }
        }

        public string GetFirstName()
        {
            int idx = RandomHelper.Generator.Next(0, _nameDocument.FirstNames.Count);
            return _nameDocument.FirstNames[idx];
        }

        public string GetLastName()
        {
            int idx = RandomHelper.Generator.Next(0, _nameDocument.LastNames.Count);
            return _nameDocument.LastNames[idx];
        }
    }
}
