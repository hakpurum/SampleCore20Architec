using System.Collections.Generic;
using System.Linq;

namespace SampleCoreArch.Core.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class DictionaryParser
    {
        /// <summary>
        /// Parses the key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="byValue">The by value.</param>
        /// <returns></returns>
        public static TKey ParseKey<TKey, TValue>(Dictionary<TKey, TValue> repository, TValue byValue)
        {
            return repository.Where(keyPair => keyPair.Value.Equals(byValue)).Select(keyPair => keyPair.Key).FirstOrDefault();
        }

        /// <summary>
        /// Parses the value.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="byKey">The by key.</param>
        /// <returns></returns>
        public static TValue ParseValue<TKey, TValue>(Dictionary<TKey, TValue> repository, TKey byKey)
        {
            return repository.TryGetValue(byKey, out var result) ? result : default(TValue);
        }
    }
}