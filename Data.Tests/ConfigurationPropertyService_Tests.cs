using Data.Domain;
using Data.Repositories;
using Data.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Xunit;

namespace LoggingData.Tests
{
	public class ConfigurationPropertyService_Tests
	{
		private readonly IServiceCollection services;
		private readonly IServiceProvider serviceProvider;
		
		private IConfigurationPropertyService _configurationPropertyService;

		public ConfigurationPropertyService_Tests()
		{
			services = new ServiceCollection();

			services.AddHttpClient("ConfigurationApi", client =>
			{
				client.BaseAddress = new Uri("https://insight-test.inntopia.com/configurationapi/v1/configurationproperties");
				client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic UG9ydGFsU1U6UGFzc3cwcmQx");
				client.DefaultRequestHeaders.Add("ClientId", "0");
				client.DefaultRequestHeaders.Add("UserId", "LoggingApi");
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			});

			services.AddSingleton<IConfigurationPropertyRepository, ConfigurationPropertyRepository>();
			services.AddSingleton<IConfigurationPropertyService, ConfigurationPropertyService>();

			serviceProvider = services.BuildServiceProvider();

			_configurationPropertyService = serviceProvider.GetService<IConfigurationPropertyService>();
		}

		[Fact]
		public void Test1()
		{
			List<ConfigurationProperty> configs = _configurationPropertyService.GetManyBy(119).ToList();
			Assert.Equal(11, configs.Count());
		}

	}
}
