using Data.Contexts;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
	/// <summary>
	/// Intermediate layer for CRUD on the configuration object where aggregation, logging, and caching may occur.
	/// </summary>
	public class ConfigurationRepository : IConfigurationRepository
	{

		/// <summary>
		/// Connection string for Configuration database.
		/// </summary>
		private readonly string _connectionString = string.Empty;

		public ConfigurationRepository(string connectionString)
			=> _connectionString = connectionString;

		/// <summary>
		/// Gets a list of configuration objects with the provided client token and object name.
		/// </summary>
		/// <param name="clientToken">Client unique identifier.</param>
		/// <param name="object">Object name for configuration values.</param>
		/// <returns>List of configurations.</returns>
		public IEnumerable<Configuration> GetManyBy(string clientToken, string @object)
		{
			var context = new ConfigurationDbContext(_connectionString);

			var items = context.Configurations.Where(_ => 
				_.ClientToken == Guid.Parse(clientToken) && 
				_.Object.ToLower() == @object.ToLower());

			return items;
		}

		/// <summary>
		/// Gets a configuration object with the provided configuration id.
		/// </summary>
		/// <param name="id">Unique identifier for the configuration object.</param>
		/// <returns>Single configuration object.</returns>
		public Configuration GetBy(int id)
		{
			var context = new ConfigurationDbContext(_connectionString);

			var item = context.Configurations.FirstOrDefault(_ => _.Id == id);

			return item;
		}
	}
}