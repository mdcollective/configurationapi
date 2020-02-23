using Api.Dto;
using Data.Domain;
using System.Collections.Generic;

namespace Api.Mappings
{
	/// <summary>
	/// Manages mappings between Configuration domain and dto objects.
	/// </summary>
	public interface IConfigurationMapper
	{
		/// <summary>
		/// Maps a configuration domain object to a configuration dto object.
		/// </summary>
		/// <param name="itemToMap">Configuration domain object.</param>
		/// <returns>Configuration dto object.</returns>
		ConfigurationDto Map(Configuration itemToMap);

		/// <summary>
		/// Maps a configuration dto object to a configuration domain object.
		/// </summary>
		/// <param name="itemToMap">Configuration dto object.</param>
		/// <returns>Configuration domain object.</returns>
		Configuration Map(ConfigurationDto itemToMap);

		/// <summary>
		/// Maps a list of Configuration domain objects to a list of configuration dto objects.
		/// </summary>
		/// <param name="itemsToMap">List of configuration domain objects.</param>
		/// <returns>List of configuration dto objects.</returns>
		List<ConfigurationDto> Map(List<Configuration> itemsToMap);

		/// <summary>
		/// Maps a list of Configuration dto objects to a list of configuration domain objects.
		/// </summary>
		/// <param name="itemsToMap">List of configuration dto objects.</param>
		/// <returns>List of configuration domain objects.</returns>
		List<Configuration> Map(List<ConfigurationDto> itemsToMap);
	}
}