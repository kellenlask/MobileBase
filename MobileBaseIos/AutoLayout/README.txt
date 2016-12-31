To create a Linq-like, monadic constraint system that will (hopefully) be very efficient. 

rootView.Apply(
	new ConstraintSet()
		.SameWidth(v1, v2, margin)
		.SameHeight(v1, v2, margin)
		.SameDimension(v1, v2, dimension, margin)
		.SameSize(v1, v2, multiplyer)
		.New(v1, attr, v2, attr, mult, const)
);

new ConstraintSet()
	.SameWidth(v1, v2, margin)
	.SameHeight(v1, v2, margin)
	.SameDimension(v1, v2, dimension, margin)
	.SameSize(v1, v2, multiplyer)
	.New(v1, attr, v2, attr, mult, const)
	.Apply(root);

ConstraintSet set = new ConstraintSet();
set.SameWidth(v1, v2, margin);
set.Clear();
set.ReApply(newRoot);
set.Count;
set.Add(constraint);
