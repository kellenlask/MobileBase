using CoreGraphics;
using UIKit;


namespace MobileBaseIos.AutoLayout
{
	public partial class ConstraintSet
	{
		public ConstraintSet CenterXY(UIView view, CGPoint position)
		{
			return CenterX(view, (float) position.X).CenterY(view, (float) position.Y);
		}


		public ConstraintSet CenterX(UIView view, float x)
		{
			return New(
				view,
				NSLayoutAttribute.CenterX,
				NSLayoutRelation.Equal,
				null, NSLayoutAttribute.NoAttribute,
				1, x
			);
		}


		public ConstraintSet CenterY(UIView view, float y)
		{
			return New(
				view,
				NSLayoutAttribute.CenterY,
				NSLayoutRelation.Equal,
				null, NSLayoutAttribute.NoAttribute,
				1, y
			);
		}


		public ConstraintSet Center(UIView view1, UIView view2)
		{
			return New(
				view1,
				NSLayoutAttribute.CenterX,
				NSLayoutRelation.Equal,
				view2,
				NSLayoutAttribute.CenterX,
				1, 0
			).New(
				view1,
				NSLayoutAttribute.CenterY,
				NSLayoutRelation.Equal,
				view2,
				NSLayoutAttribute.CenterY,
				1, 0
			);
		}


		public ConstraintSet Top(UIView view1, UIView view2, float margin = 0)
		{
			return New(
				view1,
				NSLayoutAttribute.Top,
				NSLayoutRelation.Equal,
				view2,
				NSLayoutAttribute.Top,
				1, margin
			).New(
				view2,
				NSLayoutAttribute.Top,
				NSLayoutRelation.Equal,
				view1,
				NSLayoutAttribute.Top,
				1, margin
			);
		}


		public ConstraintSet Bottom(UIView view1, UIView view2, float margin = 0)
		{
			return New(
				view1,
				NSLayoutAttribute.Bottom,
				NSLayoutRelation.Equal,
				view2,
				NSLayoutAttribute.Bottom,
				1, margin
			).New(
				view2,
				NSLayoutAttribute.Bottom,
				NSLayoutRelation.Equal,
				view1,
				NSLayoutAttribute.Bottom,
				1, margin
			);
		}


		public ConstraintSet Left(UIView view1, UIView view2, float margin = 0)
		{
			return New(
				view1,
				NSLayoutAttribute.Left,
				NSLayoutRelation.Equal,
				view2,
				NSLayoutAttribute.Left,
				1, margin
			).New(
				view2,
				NSLayoutAttribute.Left,
				NSLayoutRelation.Equal,
				view1,
				NSLayoutAttribute.Left,
				1, margin
			);
		}


		public ConstraintSet Right(UIView view1, UIView view2, float margin = 0)
		{
			return New(
				view1,
				NSLayoutAttribute.Right,
				NSLayoutRelation.Equal,
				view2,
				NSLayoutAttribute.Right,
				1, margin
			).New(
				view2,
				NSLayoutAttribute.Right,
				NSLayoutRelation.Equal,
				view1,
				NSLayoutAttribute.Right,
				1, margin
			);
		}


		public ConstraintSet TopLeft(UIView view1, UIView view2, float margin = 0)
		{
			return Top(view1, view2, margin).Left(view1, view2, margin);
		}


		public ConstraintSet TopRight(UIView view1, UIView view2, float margin = 0)
		{
			return Top(view1, view2, margin).Right(view1, view2, margin);
		}


		public ConstraintSet BottomLeft(UIView view1, UIView view2, float margin = 0)
		{
			return Bottom(view1, view2, margin).Left(view1, view2, margin);
		}


		public ConstraintSet BottomRight(UIView view1, UIView view2, float margin = 0)
		{
			return Bottom(view1, view2, margin).Right(view1, view2, margin);
		}


		public ConstraintSet TopLeft(UIView view1, UIView view2, float marginTop, float marginLeft)
		{
			return Top(view1, view2, marginTop).Left(view1, view2, marginLeft);
		}


		public ConstraintSet TopRight(UIView view1, UIView view2, float marginTop, float marginRight)
		{
			return Top(view1, view2, marginTop).Right(view1, view2, marginRight);
		}


		public ConstraintSet BottomLeft(UIView view1, UIView view2, float marginBottom, float marginLeft)
		{
			return Bottom(view1, view2, marginBottom).Left(view1, view2, marginLeft);
		}


		public ConstraintSet BottomRight(UIView view1, UIView view2, float marginBottom, float marginRight)
		{
			return Bottom(view1, view2, marginBottom).Right(view1, view2, marginRight);
		}
	}
}
