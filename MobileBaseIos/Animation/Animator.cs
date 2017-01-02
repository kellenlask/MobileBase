using System;
using CoreAnimation;
using UIKit;

namespace MobileBaseIos.Animation
{
    public class Animator
    {
        public UIView View {get; set;}
        public string Key {get; private set;}


		public CAKeyFrameAnimation Animation { get; protected set; } = new CAKeyFrameAnimation();

		public TimeSpan Duration
		{
			get { return TimeSpan.FromSeconds(Animation.Duration); }
			set { Animation.Duration = value.TotalSeconds; }
		}


		public bool UseAbsoluteValues 
		{
			get { return !Animation.Additive; }
			set { Animation.Additive = !value;}
		}


		public int Repetitions 
		{ 
			get { return (int) Animation.RepeatCount;}
			set { Animation.RepeatCount = value; }
		}

		public TimeSpan RepetitionDuration 
		{
			get { return TimeSpan.FromSeconds(Animation.RepeatDuration); }
			set { Animation.RepeatDuration = value.TotalSeconds; }
		}

		public float Speed 
		{
			get { return Animation.Speed;}
			set { Animation.Speed = value;}
		}







		public void Apply()
		{
            if(View == null)
            {
                return;
            }

            Apply(View);
		}


		public void Apply(UIView view)
        {
			Animation.TimingFunction

			//view.Layer.AddAnimation(Animation, key:);
		}

    }
}
