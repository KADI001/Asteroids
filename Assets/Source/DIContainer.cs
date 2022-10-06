using System;
using System.Collections.Generic;


namespace Source
{
    public class DIContainer
    {
        private static DIContainer _instance;
        public static DIContainer Container => _instance ??= new DIContainer();

        private static readonly Dictionary<Type, object> Implementations = new Dictionary<Type, object>();

        public void UnRegisterSingle<T>(T type) where T : notnull
        {
            if (HasTypeImplementationSingle<T>())
                Implementations.Remove(typeof(T));
            else
                throw new InvalidOperationException("There is no implementation for this type.");
        }

        public void RegisterSingle<T>(T implementation) where T : notnull
        {
            if (HasTypeImplementationSingle<T>())
                throw new InvalidOperationException("There is implementation for this type.");

            Implementations[typeof(T)] = implementation;
        }

        public T GetSingle<T>() where T : notnull => HasTypeImplementationSingle<T>() ? (T)Implementations[typeof(T)] : default;
        private bool HasTypeImplementationSingle<T>() => Implementations.ContainsKey(typeof(T));
    }
}