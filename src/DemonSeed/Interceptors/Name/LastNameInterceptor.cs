using System;
using System.Collections.Generic;
using System.Text;

namespace DemonSeed.Interceptors.Name
{
    class LastNameInterceptor : IPropertyValueInterceptor
    {
        private DataProviders.INameDataProvider _nameProvider;

        public SeedType TargetType => SeedType.LastName;

        public LastNameInterceptor(DataProviders.INameDataProvider nameProvider)
        {
            _nameProvider = nameProvider;
        }

        public object GenerateValue(SeedRequest request)
        {
            return _nameProvider.GetLastName();
        }
    }
}
