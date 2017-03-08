using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace DemonSeed
{
    internal class SeedProcessor
    {
        InterceptorCatalog _catalog;

        Stack<Type> _encounteredTypes;

        public SeedProcessor(ISeedOptions options)
        {
            _catalog = new InterceptorCatalog(options);
            _encounteredTypes = new Stack<Type>();
        }

        public T Generate<T>()
        {
            return (T)GenerateCore(typeof(T));
        }

        object GenerateCore(Type t)
        {
            if (_encounteredTypes.Contains(t))
                throw new OverflowException();

            _encounteredTypes.Push(t);

            var properties = t.GetProperties();

            try
            {
                var instance = Activator.CreateInstance(t);

                foreach (var p in properties)
                {
                    Type propType = p.PropertyType;

                    var seedAttribute = p.GetCustomAttribute<Metadata.SeedAttribute>();

                    if (seedAttribute != null)
                    {
                        var seedRequest = new SeedRequest()
                        {
                            RequestedSeedType = seedAttribute.SeedDataType,
                            Parameters = seedAttribute.GetParameters(),
                            TargetType = p.GetType()
                        };

                        var interceptor = _catalog.GetInterceptor(seedRequest.RequestedSeedType);

                        if (interceptor != null)
                        {
                            var value = interceptor.GenerateValue(seedRequest);
                            p.SetValue(instance, value);
                        }
                    }
                    else
                    {
                        var seedCollectionAttribute = p.GetCustomAttribute<Metadata.SeedCollectionAttribute>();

                        if (seedCollectionAttribute != null)
                        {
                            var enumerableType = propType.GetGenericArguments().First();

                            if (enumerableType != null)
                            {
                                var listType = typeof(List<>);
                                listType = listType.MakeGenericType(enumerableType);

                                if (propType.IsAssignableFrom(listType))
                                {
                                    var list = (IList)Activator.CreateInstance(listType);

                                    for (int i = 0; i < seedCollectionAttribute.Count; i++)
                                    {
                                        var listItem = GenerateCore(enumerableType);
                                        list.Add(listItem);
                                    }

                                    p.SetValue(instance, list);
                                }
                            }

                        }
                        else if (!IsPrimitive(propType))
                        {
                            p.SetValue(instance, GenerateCore(propType));
                        }
                    }
                }

                _encounteredTypes.Pop();
                return instance;
            }
            catch (Exception e)
            {
                if (e is OverflowException)
                    throw e;
                else
                    return null;
            }
        }

        bool IsPrimitive(Type t)
        {
            var types = new[]
                          {
                              typeof (Enum),
                              typeof (String),
                              typeof (Char),
                              typeof (Guid),

                              typeof (Boolean),
                              typeof (Byte),
                              typeof (Int16),
                              typeof (Int32),
                              typeof (Int64),
                              typeof (Single),
                              typeof (Double),
                              typeof (Decimal),

                              typeof (SByte),
                              typeof (UInt16),
                              typeof (UInt32),
                              typeof (UInt64),

                              typeof (DateTime),
                              typeof (DateTimeOffset),
                              typeof (TimeSpan),
                          };

            return types.Contains(t);
        }
    }
}
