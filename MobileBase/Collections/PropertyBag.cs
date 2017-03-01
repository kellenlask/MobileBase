using System;
using System.Collections.Generic;


namespace MobileBase.Collections
{
    /// <summary>
    ///     A fancy dictionary that makes it easier to store mixed-type values and access them later. This could have
    ///     been done with extension methods, but a subclass also allowed for removing the value type parameter.
    /// </summary>
    /// <typeparam name="TKey">The Key type</typeparam>
    public class PropertyBag<TKey> : Dictionary<TKey, object>
    {
        /// <summary>
        ///     Attempts to get the value for the given key as the given type. Throws InvalidCastException if the typing
        ///     is wrong.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>(TKey key)
        {
            return (T) this[key];
        }


        /// <summary>
        ///     Attempt to get a value for the given key, but return default(T) if that is not possible.
        /// </summary>
        /// <param name="key">The key for the desired value</param>
        /// <typeparam name="T">The type the value should be</typeparam>
        /// <returns>Value for key if found or default(T)</returns>
        public T TryGet<T>(TKey key)
        {
            try
            {
                return Get<T>(key);
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }
    }



    /// <summary>
    ///     A super-simple, mixed-value dictionary with convenience methods for accessing objects as their original type.
    /// </summary>
    public class PropertyBag : PropertyBag<string>
    {
    }
}