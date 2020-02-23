using System;

namespace Data.Domain
{
	/// <summary>
	/// RaceLeagueResults configuration class.
	/// </summary>
	public class Configuration
	{
		/// <summary>
		/// Name of configuration.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Value for given configuration.
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// Configuration grouping name.
		/// </summary>
		public string Object { get; set; }

		/// <summary>
		/// Configuration grouping id.
		/// </summary>
		public int ObjectId { get; set; }

		/// <summary>
		/// Client identifier.
		/// </summary>
		public Guid ClientToken { get; set; }

		/// <summary>
		/// Unique identifier for configuration.
		/// </summary>
		public int Id { get; set; }
	}
}