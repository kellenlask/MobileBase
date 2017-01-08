using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoreAnimation;
using UIKit;

namespace MobileBaseIos.Animation
{
	public class AnimationSet : IEnumerable<Animator>, IList<Animator>
	{
		private readonly IList<Animator> _animations = new List<Animator>();

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


		public Animator Add(Animator animator)
		{
			_animations.Add(animator);
			return animator;
		}


		public AnimationSet AnimateSequential(TimeSpan? interAnimationTiming = null)
		{
			TimeSpan timing = interAnimationTiming ?? new TimeSpan(0);





			return this;
		}


		public AnimationSet AnimateConcurrent(UIView view)
		{
			return AnimateConcurrent(view.Layer);
		}


		public AnimationSet AnimateConcurrent(CALayer layer)
		{
			var animationGroup = CAAnimationGroup.CreateAnimation();

			animationGroup.Duration = _animations.Max(a => a.Duration).TotalSeconds;
			animationGroup.Animations = _animations.Select(animation => animation.Animation).ToArray();
			layer.AddAnimation(animationGroup, null);

			return this;
		}


		public void ForEach(Action<Animator> action)
		{
			foreach (var animator in _animations)
			{
				action?.Invoke(animator);
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
