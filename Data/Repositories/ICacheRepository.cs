using System.Collections.Generic;

namespace Data.Repositories
{
	/// <summary>
	/// Strongly typed cache repository.
	/// </summary>
	/// <typeparam name="T">Type of object in cache.</typeparam>
	public interface ICacheRepository<T>
	{
		/// <summary>
		/// Retrieves a cached object with the provided key of type T.
		/// </summary>
		/// <param name="key">Id of cached object.</param>
		/// <returns>Single object of type T.</returns>
		T GetBy(string key);

		/// <summary>
		/// Retrieves a list of cached objects with the provided key of type IEnumerable<T>.
		/// </summary>
		/// <param name="key">Id of the cached objects.</param>
		/// <returns>IEnumerable objects of type T.</returns>
		IEnumerable<T> GetManyBy(string key);

		/// <summary>
		/// Adds the provided object to the cache.
		/// </summary>
		/// <param name="key">Unique identifier of object to be added.</param>
		/// <param name="object">Object to add to the cache.</param>
		/// <returns>Single object of type T.</returns>
		T Add(string key, T @object);

		/// <summary>
		/// Adds a list of objects to the cache.
		/// </summary>
		/// <param name="key">Unique identifier of objects to be added.</param>
		/// <param name="objects">Objects to be added to the cache.</param>
		/// <returns>Enumerable list of objects.</returns>
		IEnumerable<T> AddMany(string key, IEnumerable<T> objects);
	}
}