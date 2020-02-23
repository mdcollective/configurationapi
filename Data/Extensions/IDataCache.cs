using System.Collections.Generic;

namespace Data.Extensions
{
	public interface IDataCache<T>
	{
		T Get(string key);
		IEnumerable<T> GetMany(string key);
		T Set(string key, T data);
		IEnumerable<T> Set(string key, IEnumerable<T> data, int expirationMinutes);
		IEnumerable<T> Set(string key, IEnumerable<T> data);
		string CreateKey(string name, params object[] list);
	}
}
