using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;


namespace MobileBaseIos.Animation
{
    public class Animator
    {
        public event EventHandler AnimationStarted
        {
            add { Animation.AnimationStarted += value; }
            remove { Animation.AnimationStarted -= value; }
        }

        public event EventHandler<CAAnimationStateEventArgs> AnimationStopped
        {
            add { Animation.AnimationStopped += value; }
            remove { Animation.AnimationStopped -= value; }
        }

        public UIView View { get; set; }
        public string Key { get; private set; }


        public CAKeyFrameAnimation Animation { get; set; } = new CAKeyFrameAnimation();


        public bool AutoReverses
        {
            get { return Animation.AutoReverses; }
            set { Animation.AutoReverses = value; }
        }


        public TimeSpan StartDelay
        {
            get { return TimeSpan.FromSeconds(Animation.BeginTime); }
            set { Animation.BeginTime = value.TotalSeconds; }
        }


        public bool AccumulateAcrossRepetitions
        {
            get { return Animation.Cumulative; }
            set { Animation.Cumulative = value; }
        }


        public nfloat FadeInDuration
        {
            get { return Animation.FadeInDuration; }
            set { Animation.FadeInDuration = value; }
        }


        public nfloat FadeOutDuration
        {
            get { return Animation.FadeOutDuration; }
            set { Animation.FadeOutDuration = value; }
        }


        public string FillMode
        {
            get { return Animation.FillMode; }
            set { Animation.FillMode = value; }
        }


        public NSNumber[] KeyTimes
        {
            get { return Animation.KeyTimes; }
            set { Animation.KeyTimes = value; }
        }


        public CGPath Path
        {
            get { return Animation.Path; }
            set { Animation.Path = value; }
        }


        public bool RemovedOnCompletion
        {
            get { return Animation.RemovedOnCompletion; }
            set { Animation.RemovedOnCompletion = value; }
        }


        public string RotationMode
        {
            get { return Animation.RotationMode; }
            set { Animation.RotationMode = value; }
        }


        public TimeSpan TimeOffset
        {
            get { return TimeSpan.FromSeconds(Animation.TimeOffset); }
            set { Animation.TimeOffset = value.TotalSeconds; }
        }


        public CAMediaTimingFunction TimingFunction
        {
            get { return Animation.TimingFunction; }
            set { Animation.TimingFunction = value; }
        }


        public NSObject[] Values
        {
            get { return Animation.Values; }
            set { Animation.Values = value; }
        }


        public TimeSpan Duration
        {
            get { return TimeSpan.FromSeconds(Animation.Duration); }
            set { Animation.Duration = value.TotalSeconds; }
        }


        public bool UseAbsoluteValues
        {
            get { return !Animation.Additive; }
            set { Animation.Additive = !value; }
        }


        public int Repetitions
        {
            get { return (int) Animation.RepeatCount; }
            set { Animation.RepeatCount = value; }
        }

        public TimeSpan RepetitionDuration
        {
            get { return TimeSpan.FromSeconds(Animation.RepeatDuration); }
            set { Animation.RepeatDuration = value.TotalSeconds; }
        }

        public float Speed
        {
            get { return Animation.Speed; }
            set { Animation.Speed = value; }
        }


        public IDisposable AddObserver(string key, NSKeyValueObservingOptions options, Action<NSObservedChange> observer)
        {
            return Animation.AddObserver(key, options, observer);
        }


        public void AddObserver(NSObject observer, string keyPath, NSKeyValueObservingOptions options, IntPtr context)
        {
            Animation.AddObserver(observer, keyPath, options, context);
        }


        public void AddObserver(NSObject observer, NSString keyPath, NSKeyValueObservingOptions options, IntPtr context)
        {
            Animation.AddObserver(observer, keyPath, options, context);
        }


        public IDisposable AddObserver(NSString key, NSKeyValueObservingOptions options,
            Action<NSObservedChange> observer)
        {
            return Animation.AddObserver(key, options, observer);
        }


        public void RemoveObserver(NSObject observer, string keyPath)
        {
            Animation.RemoveObserver(observer, keyPath);
        }


        public void RemoveObserver(NSObject observer, NSString keyPath)
        {
            Animation.RemoveObserver(observer, keyPath);
        }


        public void RemoveObserver(NSObject observer, string keyPath, IntPtr context)
        {
            Animation.RemoveObserver(observer, keyPath, context);
        }


        public void RemoveObserver(NSObject observer, NSString keyPath, IntPtr context)
        {
            Animation.RemoveObserver(observer, keyPath, context);
        }


        public void Apply()
        {
            if (View == null)
            {
                return;
            }

            Apply(View);
        }


        public void Apply(UIView view)
        {
            view.Layer.AddAnimation(Animation, Key);
        }
    }
}
