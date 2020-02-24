using Data.Domain;
using Data.Repositories;
using Data.Services;
using Api.Extensions;
using Api.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using Api.Middleware;
using Microsoft.OpenApi.Models;

namespace Api
{
	public class Startup
	{
		private IEnumerable<Configuration> _configurations;

		public Startup(IWebHostEnvironment environment)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(environment.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true);

			Configuration = builder.Build();

			if (Configuration.Get("Settings:ConfigurationDbConnectionString") == null)
				throw new Exception("ConfigurationDbConnectionString is NULL.");

			if (Configuration.Get("Settings:Object").Length == 0)
				throw new Exception("Object value has not been set.");

			if (Configuration.Get("Settings:ObjectId").Length == 0)
				throw new Exception("ObjectId has not been set.");

			if (Configuration.Get("Settings:ClientToken").Length == 0)
				throw new Exception("ClientToken value has not been set.");

			var configurationService = new ConfigurationService(
				new ConfigurationRepository(
					Configuration.Get("Settings:ConfigurationDbConnectionString")));

			(var configurations, var errors) = configurationService
				.GetManyBy(
					Configuration.Get("Settings:ClientToken"), 
					Configuration.Get("Settings:Object"));

			if (errors != null)
				throw new Exception(string.Join(" ", errors));

			_configurations = configurations;

			if (!_configurations.Any())
				throw new Exception("No configurations have been retrieved.");
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddNewtonsoftJson();

			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

			services.AddSingleton<IConfigurationRepository, ConfigurationRepository>(
				_ => new ConfigurationRepository(
					Configuration.Get("Settings:ConfigurationDbConnectionString")));
			services.AddSingleton<IConfigurationService, ConfigurationService>();
			services.AddSingleton<ISecurityRepository, SecurityRepository>(_ => new SecurityRepository(_configurations.ToList()));
			services.AddSingleton<ISecurityService, SecurityService>();


			services.AddTransient<IConfigurationMapper, ConfigurationMapper>();

			services.AddSwaggerGen(_ =>
			{
				_.SwaggerDoc("v1", new OpenApiInfo { Title = "Configuration API", Version = "v1" });
				_.CustomSchemaIds(x => x.FullName);
				var securitySchema = new OpenApiSecurityScheme
				{
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "basic",
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Basic"
					}
				};
				_.AddSecurityDefinition("Basic", securitySchema);

				var securityRequirement = new OpenApiSecurityRequirement();
				securityRequirement.Add(securitySchema, new[] { "Basic" });
				_.AddSecurityRequirement(securityRequirement);
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseSecurityMiddleware();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("v1/swagger.json", "Configuration API");
				c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
			});
		}
	}
}