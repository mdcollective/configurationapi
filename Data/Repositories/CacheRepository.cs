using System.Collections.Generic;

namespace Data.Repositories
{
	/// <summary>
	/// Strongly typed cache repository.
	/// </summary>
	/// <typeparam name="T">Type of object in cache.</typeparam>
	public class CacheRepository<T> : ICacheRepository<T>
	{
		/// <summary>
		/// Retrieves a cached object with the provided key of type T.
		/// </summary>
		/// <param name="key">Id of cached object.</param>
		/// <returns>Single object of type T.</returns>
		public T GetBy(string key)
		{
			return default(T);
		}

		/// <summary>
		/// Retrieves a list of cached objects with the provided key of type IEnumerable<T>.
		/// </summary>
		/// <param name="key">Id of the cached objects.</param>
		/// <returns>IEnumerable objects of type T.</returns>
		public IEnumerable<T> GetManyBy(string key)
		{
			return default(List<T>);
		}

		/// <summary>
		/// Adds the provided object to the cache.
		/// </summary>
		/// <param name="key">Unique identifier of object to be added.</param>
		/// <param name="object">Object to add to the cache.</param>
		/// <returns>Single object of type T.</returns>
		public T Add(string key, T @object)
		{
			return default(T);
		}

		/// <summary>
		/// Adds a list of objects to the cache.
		/// </summary>
		/// <param name="key">Unique identifier of objects to be added.</param>
		/// <param name="objects">Objects to be added to the cache.</param>
		/// <returns>Enumerable list of objects.</returns>
		public IEnumerable<T> AddMany(string key, IEnumerable<T> objects)
		{
			return default(List<T>);
		}
	}
}