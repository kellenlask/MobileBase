using System;
namespace Collections
{
	public static class Arrays
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
	}
}
