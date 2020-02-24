using Api.Dto;
using Api.Mappings;
using Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
	/// <summary>
	/// Manages CRUD for the configuration object.
	/// </summary>
	[Route("v1")]
	[ApiController]
	public class ConfigurationController : BaseController
	{
		private readonly IConfigurationService _service;

		private readonly IConfigurationMapper _mapper;

		public ConfigurationController(IConfigurationService service, IConfigurationMapper mapper)
		{
			_service = service;

			_mapper = mapper;
		}

		/// <summary>
		/// Gets a configuration with its unique identifier.
		/// </summary>
		/// <param name="id">Configuration unique identifier.</param>
		/// <returns>Single configuration object.</returns>
		[HttpGet("configurations/{id}")]
		public dynamic GetBy(int id)
		{
			(var item, var errors) = _service.GetBy(id);

			if (errors != null)
				return new ConfigurationDto { Errors = errors };

			var mappedItem = _mapper.Map(item);

			return mappedItem;
		}

		/// <summary>
		/// Provides all configurations for the given object.
		/// </summary>
		/// <param name="object">Object requesting configurations.</param>
		/// <returns>List of configurations.</returns>
		[HttpGet("configurations")]
		public dynamic GetManyBy(string clientToken, string @object)
		{
			(var items, var errors) = _service.GetManyBy(clientToken, @object);

			if (errors != null)
				return new ConfigurationDto { Errors = errors };

			var mappedItem = _mapper.Map(items.ToList());

			return mappedItem;
		}
	}
}