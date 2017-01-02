using System;
using System.Collections;
using System.Collections.Generic;


namespace Animation
{
	public class ConcurrentAnimationSet : IEnumerable<Animator>, IList<Animator>
	{
		private readonly IList<Animator> _animations = new List<Animator>();
		private float _maxAnimationDuration = 0.0f;

		public int Count => _animations.Count;
		public bool IsReadOnly => _animations.IsReadOnly;
		IEnumerator IEnumerable.GetEnumerator() => _animations.GetEnumerator();
		public IEnumerator<Animator> GetEnumerator() => _animations.GetEnumerator();

		public Animator this[int index]
		{
			get { return _animations[index]; }
			set { _animations[index] = value; }
		}


		public void Clear()
		{
			_animations.Clear();
		}


		public Animator Add(Animator constraint)
		{
			_animations.Add(constraint);
			return constraint;
		}


		public ConcurrentAnimationSet Animate()
		{


			return this;
		}


		public void ForEach(Action<Animator> action)
		{
			foreach (var constraint in _animations)
			{
				action?.Invoke(constraint);
			}
		}

		public int IndexOf(Animator item)
		{
			return _animations.IndexOf(item);
		}


		public void Insert(int index, Animator item)
		{
			_animations.Insert(index, item);
		}


		public void RemoveAt(int index)
		{
			_animations.RemoveAt(index);
		}


		void ICollection<Animator>.Add(Animator item)
		{
			_animations.Add(item);
		}


		public bool Contains(Animator item)
		{
			return _animations.Contains(item);
		}


		public void CopyTo(Animator[] array, int arrayIndex)
		{
			_animations.CopyTo(array, arrayIndex);
		}


		public bool Remove(Animator item)
		{
			return _animations.Remove(item);
		}
	}
}
