using System;


namespace Contracts
{
	public interface IConfigurable<T>
	{
		T Configure(T data);
	}
}
