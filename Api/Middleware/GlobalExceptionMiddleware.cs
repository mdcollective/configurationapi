using Microsoft.AspNetCore.Http;
using System;
using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api.Middleware
{
	/// <summary>
	/// Middleware to catch any errors not handled in code.
	/// </summary>
	public class GlobalExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionMiddleware(RequestDelegate next)
			=> _next = next;

		/// <summary>
		/// Catches any uncaught errors in the current http context.
		/// </summary>
		/// <param name="context">Currently executing http context.</param>
		/// <returns>The currently executing http context.</returns>
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = 200;

				context.Response.Headers.Clear();

				context.Response.ContentType = "application/json";

				dynamic body = new ExpandoObject();

				body.Errors = new[] {ex.Message};

				await context.Response.WriteAsync((string)JsonConvert.SerializeObject(body));
			}
		}
	}
}
