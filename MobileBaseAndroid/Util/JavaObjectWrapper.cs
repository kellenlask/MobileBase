namespace Util
{
	public class JavaObjectWrapper<T> : Java.Lang.Object
	{
		public T Value {get;set;}


		public JavaObjectWrapper()
		{
		}


		public JavaObjectWrapper(T obj)
		{
			Value = obj;
		}
	}
}
