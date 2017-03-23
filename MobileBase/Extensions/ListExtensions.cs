using System;
using System.Collections.Generic;


namespace MobileBase.Extensions
{
    /// <summary>
    ///     A set of extension methods for dealing with lists in a more convenient fashion.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// 	A ForEach method for for-eaching through an IList ever so slightly more functionally.
        /// </summary>
        public static IList<T> ForEach<T>(this IList<T> list, Action<T> action)
        {
            foreach (var element in list)
            {
                action?.Invoke(element);
            }

            return list;
        }


        /// <summary>
        ///    A method for For-Eaching through a HashSet ever so slightly more functionally.
        /// </summary>
        public static HashSet<T> ForEach<T>(this HashSet<T> set, Action<T> action)
        {
            foreach (var element in set)
            {
                action?.Invoke(element);
            }

            return set;
        }


        /// <summary>
        ///     If you want the index as you run through your collection ever so slightly more functionally, this
        ///     method will give your operation an index.
        /// </summary>
        public static IList<T> ForIn<T>(this IList<T> list, Action<int, T> action)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var element = list[i];
                action?.Invoke(i, element);
            }

            return list;
        }
    }
}