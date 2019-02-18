using System;
using System.Collections.Generic;

namespace Shared
{
    /// <summary>
    /// Inversion of control class. Use this to obtain platform-specific dependencies.
    /// </summary>
    public class Ioc
    {
        private static Dictionary<Type, object> _singletons = new Dictionary<Type, object>();
        private static Dictionary<Type, Func<object>> _scoped = new Dictionary<Type, Func<object>>();

        /// <summary>
        /// Register a singleton type. Each request, the same instance will be returned.
        /// </summary>
        /// <typeparam name="T">The type of the singleton.</typeparam>
        /// <param name="singleton">The instance of the singleton.</param>
        public static void RegisterSingleton<T>(object singleton) where T : class
        {
            _singletons.Add(typeof(T), singleton);
        }

        /// <summary>
        /// Register a scoped type. Each request, a new instance will be returned.
        /// </summary>
        /// <typeparam name="T">The type of the scoped instance.</typeparam>
        /// <param name="factory">The method to use for creating the instance.</param>
        public static void RegisterScoped<T>(Func<object> factory) where T : class
        {
            _scoped.Add(typeof(T), factory);
        }

        /// <summary>
        /// Retrieve a registered instance.
        /// </summary>
        /// <typeparam name="T">The type of instance to retrieve.</typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class
        {
            _singletons.TryGetValue(typeof(T), out object value);
            if (value == null)
            {
                _scoped.TryGetValue(typeof(T), out Func<object> factory);
                return factory() as T;
            }
            return value as T;
        }
    }
}
