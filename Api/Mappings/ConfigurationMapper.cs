using Api.Dto;
using Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Api.Mappings
{
	/// <summary>
	/// Manages mappings between Configuration domain and dto objects.
	/// </summary>
	public class ConfigurationMapper : IConfigurationMapper
	{
		/// <summary>
		/// Maps a list of Configuration domain objects to a list of configuration dto objects.
		/// </summary>
		/// <param name="itemsToMap">List of configuration domain objects.</param>
		/// <returns>List of configuration dto objects.</returns>
		public List<ConfigurationDto> Map(List<Configuration> itemsToMap)
		{
			if (itemsToMap == null)
				return default;

			return itemsToMap.Select(Map).ToList();
		}

		/// <summary>
		/// Maps a list of Configuration dto objects to a list of configuration domain objects.
		/// </summary>
		/// <param name="itemsToMap">List of configuration dto objects.</param>
		/// <returns>List of configuration domain objects.</returns>
		public List<Configuration> Map(List<ConfigurationDto> itemsToMap)
		{
			if (itemsToMap == null)
				return default;

			return itemsToMap.Select(Map).ToList();
		}

		/// <summary>
		/// Maps a configuration domain object to a configuration dto object.
		/// </summary>
		/// <param name="itemToMap">Configuration domain object.</param>
		/// <returns>Configuration dto object.</returns>
		public ConfigurationDto Map(Configuration itemToMap)
		{
			if (itemToMap == null)
				return default;

			return new ConfigurationDto
			{
				ClientToken = itemToMap.ClientToken,
				Id = itemToMap.Id,
				Name = itemToMap.Name,
				Object = itemToMap.Object,
				ObjectId = itemToMap.ObjectId,
				Value = itemToMap.Value
			};
		}

		/// <summary>
		/// Maps a configuration dto object to a configuration domain object.
		/// </summary>
		/// <param name="itemToMap">Configuration dto object.</param>
		/// <returns>Configuration domain object.</returns>
		public Configuration Map(ConfigurationDto itemToMap)
		{
			if (itemToMap == null)
				return default;

			return new Configuration
			{
				ClientToken = itemToMap.ClientToken,
				Id = itemToMap.Id,
				Name = itemToMap.Name,
				Object = itemToMap.Object,
				ObjectId = itemToMap.ObjectId,
				Value = itemToMap.Value
			};
		}
	}
}
