using System.Linq;
using UIKit;


namespace MobileBaseIos.AutoLayout
{
    public static class UiViewExtensinos
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
