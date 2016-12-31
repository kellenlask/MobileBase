using System;
using UIKit;

namespace AutoLayout
{
	public partial class ConstraintSet
	{
		// Complete
		public ConstraintSet New(
			UIView view1,
			NSLayoutAttribute attr1,
			NSLayoutRelation relation,
			UIView view2,
			NSLayoutAttribute attr2,
			float multiplier = 1,
			float constant = 0
		)
		{
			Add( NSLayoutConstraint.Create(
					view1, attr1,
					relation,
					view2, attr2,
					multiplier, constant
				)
			);

			return this;
		}


		// Same LayoutAttribute
		public ConstraintSet New(
			UIView view1,
			NSLayoutRelation relation,
			UIView view2,
			NSLayoutAttribute attr,
			float multiplier = 1,
			float constant = 0
		)
		{
			New(view1, attr, relation, view2, attr, multiplier, constant);
			return this;
		}


		// Same LayoutAttribute and relation == equal
		public ConstraintSet New(
			UIView view1,
			UIView view2,
			NSLayoutAttribute attr,
			float multiplier = 1,
			float constant = 0
		)
		{
			New(view1, attr, NSLayoutRelation.Equal, view2, attr, multiplier, constant);
			return this;
		}


		// Relation == equal, different LayoutAttributes
		public ConstraintSet New(
			UIView view1,
			NSLayoutAttribute attr1,
			UIView view2,
			NSLayoutAttribute attr2,
			float multiplier = 1,
			float constant = 0
		)
		{
			New(view1, attr1, NSLayoutRelation.Equal, view2, attr2, multiplier, constant);
			return this;
		}
	}
}
