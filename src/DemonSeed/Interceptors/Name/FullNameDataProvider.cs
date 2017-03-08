using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Interceptors.Name
{
    class FullNameDataProvider : IPropertyValueInterceptor
    {
        private DataProviders.INameDataProvider _nameProvider;

        public SeedType TargetType => SeedType.FullName;

        public FullNameDataProvider(DataProviders.INameDataProvider nameProvider)
        {
            _nameProvider = nameProvider;
        }

        public object GenerateValue(SeedRequest request)
        {
            return $"{_nameProvider.GetFirstName()} {_nameProvider.GetLastName()}";
        }
    }
}
