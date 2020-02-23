using Data.Domain;
using Data.Repositories;
using System.Collections.Generic;

namespace Data.Services
{
	/// <summary>
	/// Intermediate layer for CRUD on the configuration object where aggregation, logging, and caching may occur.
	/// </summary>
	public class ConfigurationService : IConfigurationService
	{
		private readonly IConfigurationRepository _repository;

		public ConfigurationService(IConfigurationRepository repository)
			=> _repository = repository;

		/// <summary>
		/// Gets a configuration object with the provided configuration id.
		/// </summary>
		/// <param name="id">Unique identifier for the configuration object.</param>
		/// <returns>Single configuration object.</returns>
		public Configuration GetBy(int id)
			=> _repository.GetBy(id);

		/// <summary>
		/// Gets a list of configuration objects with the provided client token and object name.
		/// </summary>
		/// <param name="clientToken">Client unique identifier.</param>
		/// <param name="object">Object name for configuration values.</param>
		/// <returns>List of configurations.</returns>
		public IEnumerable<Configuration> GetManyBy(string clientToken, string @object)
			=> _repository.GetManyBy(clientToken, @object);
	}
}