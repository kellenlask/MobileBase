using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace AutoLayout
{
	public partial class ConstraintSet : IEnumerable<NSLayoutConstraint>, IList<NSLayoutConstraint>
	{
		private IList<NSLayoutConstraint> _constraints = new List<NSLayoutConstraint>();

		public int Count => _constraints.Count;
		public bool IsReadOnly => _constraints.IsReadOnly;
		IEnumerator IEnumerable.GetEnumerator() => _constraints.GetEnumerator();
		public IEnumerator<NSLayoutConstraint> GetEnumerator() => _constraints.GetEnumerator();

		public NSLayoutConstraint this[int index]
		{
			get
			{
				return _constraints[index];
			}

			set
			{
				_constraints[index] = value;
			}
		}


		public void Clear()
		{
			ForEach(constraint => constraint.Active = false);
			_constraints.Clear();
		}


		public NSLayoutConstraint Add(NSLayoutConstraint constraint)
		{
			_constraints.Add(constraint);
			return constraint;
		}


		public ConstraintSet Apply(UIView view)
		{
			view.AddConstraints(_constraints.ToArray());
			return this;
		}


		public void ForEach(Action<NSLayoutConstraint> action)
		{
			foreach(var constraint in _constraints)
			{
				action?.Invoke(constraint);
			}
		}

		public int IndexOf(NSLayoutConstraint item)
		{
			return _constraints.IndexOf(item);
		}


		public void Insert(int index, NSLayoutConstraint item)
		{
			_constraints.Insert(index, item);
		}


		public void RemoveAt(int index)
		{
			_constraints.RemoveAt(index);
		}


		void ICollection<NSLayoutConstraint>.Add(NSLayoutConstraint item)
		{
			_constraints.Add(item);
		}


		public bool Contains(NSLayoutConstraint item)
		{
			return _constraints.Contains(item);
		}


		public void CopyTo(NSLayoutConstraint[] array, int arrayIndex)
		{
			_constraints.CopyTo(array, arrayIndex);
		}


		public bool Remove(NSLayoutConstraint item)
		{
			return _constraints.Remove(item);
		}
	}
}
