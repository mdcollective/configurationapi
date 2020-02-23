using Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
	/// <summary>
	/// Object representation of configuration database.
	/// </summary>
	public class ConfigurationDbContext : DbContext
	{
		public ConfigurationDbContext() { }

		private readonly string _connectionString;

		public ConfigurationDbContext(DbContextOptions options) : base(options) { }

		public ConfigurationDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
		{
			dbContextOptionsBuilder.UseSqlServer(_connectionString);
		}

		/// <summary>
		/// Object representation of Configuration table.
		/// </summary>
		public virtual DbSet<Configuration> Configurations { get; set; }
	}
}