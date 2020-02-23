using Microsoft.AspNetCore.Builder;

namespace Api.Middleware
{
	/// <summary>
	/// Global error handling for uncaught errors.
	/// </summary>
	public static class GlobalExceptionMiddlewareExtensions
	{
		/// <summary>
		/// Adds the GlobalExceptionMiddleware to the IApplicationBuilder.
		/// </summary>
		/// <param name="builder">IApplicationBuilder from the Startup.cs.</param>
		/// <returns>The current IApplicationBuilder.</returns>
		public static IApplicationBuilder UseGlobalExceptions(this IApplicationBuilder builder)
			=> builder.UseMiddleware<GlobalExceptionMiddleware>();
	}
}