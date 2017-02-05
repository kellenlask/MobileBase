using System;
namespace Animation
{
	/// <summary>
	/// 	Most common KeyPaths for KeyFrameAnimations. Technically, any property
	/// 	can be referenced for the KeyPath, but these are by far the most likely.
	/// </summary>
	public static class KeyPaths
	{
		public static string RotationX = "rotation.x";
		public static string RotationY = "rotation.y";
		public static string RotationZ = "rotation.z";
		public static string Rotation = "rotation";

		public static string ScaleX = "scale.x";
		public static string ScaleY = "scale.y";
		public static string ScaleZ = "scale.z";
		public static string Scale = "scale";

		public static string TranslationX = "translation.x";
		public static string TranslationY = "translation.y";
		public static string TranslationZ = "translation.z";
		public static string Translation = "translation";

		public static string X = "x";
		public static string Y = "y";

		/// <summary>
		/// 	CGRect Origin.X.
		/// </summary>
		public static string OriginX = "origin.x";


		/// <summary>
		/// 	CGRect Origin.Y.
		/// </summary>
		public static string OriginY = "origin.y";


		/// <summary>
		/// 	CGRect Origin.
		/// </summary>
		public static string Origin = "origin";


		/// <summary>
		/// 	CGSize Width.
		/// </summary>
		public static string Width = "width";


		/// <summary>
		/// 	CGSize Height.
		/// </summary>
		public static string Height = "height";


		/// <summary>
		/// 	CGRect Size.Width.
		/// </summary>
		public static string SizeWidth = "size.width";


		/// <summary>
		/// 	CGRect Size.Height.
		/// </summary>
		public static string SizeHeight = "size.height";


		/// <summary>
		/// 	CGRect Size.
		/// </summary>
		public static string Size = "size";
	}
}
