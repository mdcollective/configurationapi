using Data.Domain;
using System.Collections.Generic;

namespace Data.Services
{
	/// <summary>
	/// Intermediate layer for CRUD on the configuration object where aggregation, logging, and caching may occur.
	/// </summary>
	public interface IConfigurationService
	{
		/// <summary>
		/// Gets a configuration object with the provided configuration id.
		/// </summary>
		/// <param name="id">Unique identifier for the configuration object.</param>
		/// <returns>Single configuration object.</returns>
		(Configuration configuration, string[] errors) GetBy(int id);

		/// <summary>
		/// Gets a list of configuration objects with the provided client token and object name.
		/// </summary>
		/// <param name="clientToken">Client unique identifier.</param>
		/// <param name="object">Object name for configuration values.</param>
		/// <returns>List of configurations.</returns>
		(IEnumerable<Configuration> configurations, string[] errors) GetManyBy(string clientToken, string @object);
	}
}