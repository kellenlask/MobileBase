using CoreGraphics;
using UIKit;


namespace AutoLayout
{
	public partial class ConstraintSet
	{
		public ConstraintSet Size(UIView view, CGSize size)
		{
			return Width(view, (float)size.Width)
				.Height(view, (float)size.Height);
		}


		public ConstraintSet Width(UIView view, float size)
		{
			return New(
				view,
				NSLayoutAttribute.Width,
				NSLayoutRelation.Equal,
				null,
				NSLayoutAttribute.NoAttribute,
				1, size
			);
		}


		public ConstraintSet Height(UIView view, float size)
		{
			return New(
				view,
				NSLayoutAttribute.Height,
				NSLayoutRelation.Equal,
				null,
				NSLayoutAttribute.NoAttribute,
				1, size
			);
		}


		public ConstraintSet SameSize(UIView view1, UIView view2, int margin = 0)
		{
			return SameHeight(view1, view2, margin)
				.SameWidth(view1, view2, margin);
		}


		public ConstraintSet SameHeight(UIView view1, UIView view2, int margin = 0)
		{
			return SameTop(view1, view2, margin).SameBottom(view1, view2, margin);
		}


		public ConstraintSet SameWidth(UIView view1, UIView view2, int margin = 0)
		{
			return SameLeft(view1, view2, margin).SameRight(view1, view2, margin);
		}


		public ConstraintSet SameTop(UIView view1, UIView view2, int margin = 0)
		{
			return New(view1, view2, NSLayoutAttribute.Top, 1, margin)
			.New(view2, view1, NSLayoutAttribute.Top, 1, -margin);
		}

		public ConstraintSet SameBottom(UIView view1, UIView view2, int margin = 0)
		{
			return New(view1, view2, NSLayoutAttribute.Bottom, 1, margin)
			.New(view2, view1, NSLayoutAttribute.Bottom, 1, -margin);
		}


		public ConstraintSet SameLeft(UIView view1, UIView view2, int margin = 0)
		{
			return New(view1, view2, NSLayoutAttribute.Left, 1, margin)
			.New(view2, view1, NSLayoutAttribute.Left, 1, -margin);
		}


		public ConstraintSet SameRight(UIView view1, UIView view2, int margin = 0)
		{
			return New(view1, view2, NSLayoutAttribute.Right, 1, margin)
			.New(view2, view1, NSLayoutAttribute.Right, 1, -margin);
		}

	}
}
