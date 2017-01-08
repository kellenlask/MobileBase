using System;
using System.Collections;
using System.Collections.Generic;
using Android.Views;
using Util;

namespace Adapters
{
	public class ListAdapter<T> : Android.Widget.BaseAdapter, IList<T>
	{
		private readonly IList<T> _models = new List<T>();
		private readonly Func<T, int, View> _viewFactory;


		public ListAdapter(Func<T, int, View> viewFactory)
		{
			_viewFactory = viewFactory;
		}


		public ListAdapter(Func<T, View> viewFactory)
		{
			_viewFactory = (model, index) => viewFactory(model);
		}


		public T this[int index]
		{
			get
			{
				return _models[index];
			}

			set
			{
				_models[index] = value;
			}
		}


		public override int Count
		{
			get
			{
				return _models.Count;
			}
		}


		public bool IsReadOnly
		{
			get
			{
				return _models.IsReadOnly;
			}
		}


		public void Add(T item)
		{
			_models.Add(item);
		}


		public void Clear()
		{
			_models.Clear();
		}


		public bool Contains(T item)
		{
			return _models.Contains(item);
		}


		public void CopyTo(T[] array, int arrayIndex)
		{
			_models.CopyTo(array, arrayIndex);
		}


		public IEnumerator<T> GetEnumerator()
		{
			return _models.GetEnumerator();
		}


		/// <summary>
		/// 	Gets a JavaObjectWrapper<T> of the object at the given index.
		/// 	A much better way to get the element at a certain position is to
		/// 	use this class's IList implementation.
		/// </summary>
		public override Java.Lang.Object GetItem(int position)
		{
			return new JavaObjectWrapper<T>(_models[position]);
		}


		/// <summary>
		/// 	Uses the item's GetHashCode implementation as the unique ID. If you
		/// 	really do depend on this method for a unique ID, then you'll want
		/// 	to do something else -- hash codes aren't actually guaranteed to
		/// 	be unique.
		/// </summary>
		public override long GetItemId(int position)
		{
			return _models[position].GetHashCode();
		}


		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			return _viewFactory(_models[position], position);
		}


		public int IndexOf(T item)
		{
			return _models.IndexOf(item);
		}


		public void Insert(int index, T item)
		{
			_models.Insert(index, item);
		}


		public bool Remove(T item)
		{
			return _models.Remove(item);
		}


		public void RemoveAt(int index)
		{
			_models.RemoveAt(index);
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return _models.GetEnumerator();
		}
	}
}
