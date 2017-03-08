using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace DemonSeed
{
    class InterceptorCatalog
    {
        private IDictionary<SeedType, IPropertyValueInterceptor> _catalog;

        public InterceptorCatalog(ISeedOptions options)
        {
            _catalog = new Dictionary<SeedType, IPropertyValueInterceptor>();
            RegisterDefaultInterceptors(options);
        }

        public void AddInterceptor(SeedType t, IPropertyValueInterceptor interceptor)
        {
            if (!_catalog.ContainsKey(t))
                _catalog.Add(t, interceptor);
            else
                _catalog[t] = interceptor;
        }

        public IPropertyValueInterceptor GetInterceptor(SeedType type)
        {
            if (!_catalog.ContainsKey(type))
                return null;
            else
                return _catalog[type];
        }

        private void RegisterDefaultInterceptors(ISeedOptions options)
        {
            AddInterceptor(SeedType.FirstName, new Interceptors.FirstNameInterceptor(options.NameProvder));
        }
    }
}
