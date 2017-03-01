using System;
using System.Collections.Generic;


namespace MobileBase.Collections
{
	public static class ListHelpers
	{
		/// <summary>
		/// 	A C# implementation of the F# Array Initialization from a function. 
		/// 	var myArray = Init<int>(5, i => i * 2); // {0, 2, 4, 6, 8}
		/// </summary>
		public static T[] Init<T>(int length, Func<int, T> valueFactory)
		{
			var array = new T[length];

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = valueFactory(i);
			}

			return array;
		}


		/// <summary>
		/// 	A ForEach method for for-eaching through an IList ever so slightly more functionally. 
		/// </summary>
		public static IList<T> ForEach<T>(this IList<T> list, Action<T> action)
		{
			foreach(var element in list)
			{
				action?.Invoke(element);
			}

			return list;
		}


	    public static HashSet<T> ForEach<T>(this HashSet<T> list, Action<T> action)
	    {
	        foreach (var item in list)
	        {
	            action?.Invoke(item);
	        }

	        return list;
	    }
	}
}