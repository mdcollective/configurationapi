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

		private readonly ConfigurationDbContext _context;

		public ConfigurationRepository(string connectionString)
			=> _context = new ConfigurationDbContext(connectionString);

		/// <summary>
		/// Gets a list of configuration objects with the provided client token and object name.
		/// </summary>
		/// <param name="clientToken">Client unique identifier.</param>
		/// <param name="object">Object name for configuration values.</param>
		/// <returns>List of configurations.</returns>
		public (IEnumerable<Configuration> configurations, string[] errors) GetManyBy(string clientToken, string @object)
		{
			try
			{
				var items = _context.Configurations.Where(_ =>
					_.ClientToken == Guid.Parse(clientToken) &&
					_.Object.ToLower() == @object.ToLower());

				return (items, null);
			}
			catch (Exception exception)
			{
				return (null, new string[] { exception.Message });
			}
		}

		/// <summary>
		/// Gets a configuration object with the provided configuration id.
		/// </summary>
		/// <param name="id">Unique identifier for the configuration object.</param>
		/// <returns>Single configuration object.</returns>
		public (Configuration configuration, string[] errors) GetBy(int id)
		{
			try
			{
				var item = _context.Configurations.FirstOrDefault(_ => _.Id == id);

				return (item, null);
			}
			catch (Exception exception)
			{
				return (null, new string[] { exception.Message });
			}
		}
	}
}