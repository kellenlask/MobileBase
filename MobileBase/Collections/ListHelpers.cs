using System;


namespace MobileBase.Collections
{
    public static class ListHelpers
    {
        /// <summary>
        /// 	A C# implementation of the F# Array Initialization from a function.
        /// 	var myArray = Init&lt;int&gt;(5, i => i * 2); // {0, 2, 4, 6, 8}
        /// </summary>
        public static T[] Init<T>(int length, Func<int, T> valueFactory)
        {
            var array = new T[length];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = valueFactory(i);
            }

            return array;
        }
    }
}