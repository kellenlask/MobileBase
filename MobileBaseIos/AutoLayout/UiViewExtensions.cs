using System;
using System.Linq;
using UIKit;

namespace AutoLayout
{
	public static class UIViewExtensinos
	{
		public static T Remove<T>(this T view, ConstraintSet constraintSet) where T : UIView
		{
			view.RemoveConstraints(constraintSet.ToArray());
			return view;
		}


		public static T Apply<T>(this T view, ConstraintSet constraintSet) where T : UIView
		{
			constraintSet.Apply(view);
			return view;
		}
	}
}
