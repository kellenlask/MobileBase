using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CoreAnimation;
using UIKit;


namespace MobileBaseIos.Animation
{ 
	/// <summary>
	///		An animation collection class for handling sets of Animations. This class simply 
	/// 	delegates its IList implementaion down to an internal IList of Animators. Animators
	/// 	are an abstraction on iOS animations. 
	/// </summary>
	public class AnimationSet : IList<Animator>, IDisposable
	{
		private Timer _timer;
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


		public AnimationSet Add(AnimationSet animationSet) 
		{
			((List<Animator>)_animations).AddRange(animationSet);
			return this;
		}


		public AnimationSet AnimateSequential(TimeSpan? interAnimationTiming = null)
		{
			TimeSpan timing = interAnimationTiming ?? TimeSpan.Zero;
			PerformSequentialAnimation(0, timing);
			return this;
		}


		private void PerformSequentialAnimation(int index, TimeSpan interAnimationDelay)
		{
			// If the Index is ridiculous, give up. 
			if(index >= _animations.Count || index < 0)
			{
				return;
			}

			// Apply the animation at index
			_animations[index].Apply();

			// Start a timer for the next animation
			_timer = new Timer(
				// Callback
				state => PerformSequentialAnimation(index + 1, interAnimationDelay), 
				// Timer State
				null, 
				// Delay
				(int)(interAnimationDelay + _animations[index].Duration).TotalMilliseconds,
				// Repeat interval
				Timeout.Infinite
			);
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


		public void Dispose()
		{
			_timer?.Dispose();
			_timer = null;
		}
	}
}
