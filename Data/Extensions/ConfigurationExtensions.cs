using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Extensions
{
	public static class ConfigurationExtensions
	{
		public static string Get(this IEnumerable<Configuration> configurations, string name)
		{
			if (string.IsNullOrEmpty(name))
				return string.Empty;

			try
			{
				var configuration = configurations.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());

				return configuration == null ? string.Empty : configuration.Value;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);

				throw;
			}
		}
	}
}
