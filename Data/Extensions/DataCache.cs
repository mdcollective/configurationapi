using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Data.Extensions
{
	public class DataCache<T> : IDataCache<T>
	{
		private readonly IMemoryCache _cache;

		public DataCache(IMemoryCache cache)
		{
			_cache = cache;
		}

		public T Get(string key)
		{
			return _cache.Get<T>(key);
		}

		public IEnumerable<T> GetMany(string key)
		{
			return _cache.Get<IEnumerable<T>>(key);
		}

		public T Set(string key, T data)
		{
			return _cache.Set<T>(key, data, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(15)).SetAbsoluteExpiration(TimeSpan.FromHours(1)));
		}

		public IEnumerable<T> Set(string key, IEnumerable<T> data)
		{
			return _cache.Set<IEnumerable<T>>(key, data, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(15)).SetAbsoluteExpiration(TimeSpan.FromHours(1)));
		}

		public IEnumerable<T> Set(string key, IEnumerable<T> data, int expirationMinutes)
		{
			return _cache.Set<IEnumerable<T>>(key, data, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(expirationMinutes)));
		}

		public string CreateKey(string name, params object[] list)
		{
			var sb = new StringBuilder();

			sb.Append(name);

			sb.Append("-");

			for (int i = 0; i < list.Length; i++)
			{
				sb.Append(list[i].ToString());

				if (i != list.Length - 1)
					sb.Append("-");
			}

			return sb.ToString();
		}
	}
}
