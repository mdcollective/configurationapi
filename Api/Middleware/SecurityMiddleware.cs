using Api.Extensions;
using Data.Domain;
using Data.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Api.Middleware
{
	/// <summary>
	/// Middleware to support custom authentication through a security api.
	/// </summary>
	public class SecurityMiddleware
	{
		private readonly RequestDelegate _next;

		private ISecurityService _securityService;

		public SecurityMiddleware(RequestDelegate next)
			=> _next = next;

		/// <summary>
		/// Authenticates each api call against the provided ISecurityService.
		/// </summary>
		/// <param name="context">Current HttpContext in execution.</param>
		/// <param name="securityService">Security service to authenticate against.</param>
		/// <returns>Asynchronous HttpContext.</returns>
		public async Task Invoke(HttpContext context, ISecurityService securityService)
		{
			_securityService = securityService;

			var path = context.Request.Path.Value;

			if (!path.ToLower().Contains("/swagger"))
			{
				if (!context.HasValidHeaders())
				{
					context.Response.StatusCode = 401;
					await context.Response.WriteAsync("Invalid Headers");
					return;
				}

				var loginResult = _securityService.Login(new LoginRequest
				{
					Username = context.GetUsername(),
					Password = context.GetPassword()
				});


				if (!loginResult.Success)
				{
					context.Response.StatusCode = 401;
					await context.Response.WriteAsync("Invalid username, password, or client id");
					return;
				}
			}

			await _next.Invoke(context);
		}
	}
}