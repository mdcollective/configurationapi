using Microsoft.Extensions.Configuration;
using System;

namespace Api.Extensions
{
	public static class IConfiguratonExtensions
	{

		public static string Get(this IConfiguration configuration, string name)
		{
			try
			{
				return configuration[name];
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message);
			}
		}
	}
}
