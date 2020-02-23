namespace Data.Domain
{
	/// <summary>
	/// Object representation of appsettings.json.
	/// </summary>
	public class AppSettings
	{
		/// <summary>
		/// Connection string for the Configuration database.
		/// </summary>
		public string ConfigurationDbConnectionString { get; set; }

		/// <summary>
		/// Object name for the Configuration Api.
		/// </summary>
		public string Object { get; set; }

		/// <summary>
		/// Object Id for the Configuration Api
		/// </summary>
		public string ObjectId { get; set; }

		/// <summary>
		/// Client unique identifier.
		/// </summary>
		public string ClientToken { get; set; }

		/// <summary>
		/// Value to be used in basic auth.
		/// </summary>
		public string Authorization { get; set; }
	}
}