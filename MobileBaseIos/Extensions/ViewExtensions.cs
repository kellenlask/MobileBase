using System.Linq;
using UIKit;


namespace MobileBaseIos.Extensions
{
    public static class ViewExtensions
    {

        /// <summary>
        ///    Composable method for adding subview arrays to the calling view. The purpose of this method is to make
        ///    possible the composition of view hierarchies in the form of the view hierarchy.
        /// </summary>
        public static UIView WithSubviews(this UIView root, params UIView[] subviews)
        {
            root.AddSubviews(subviews);
            return root;
        }


        /// <summary>
        ///    Composable method for adding subview arrays to the calling view. This is a convenience method for adding
        ///    any compositions of views to the calling view.
        /// </summary>
        public static UIView WithSubviews(this UIView root, params UIView[][] subviews)
        {
            root.AddSubviews(subviews.SelectMany(array => array).ToArray());
            return root;
        }




    }
}