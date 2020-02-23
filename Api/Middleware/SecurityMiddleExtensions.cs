using Microsoft.AspNetCore.Builder;

namespace Api.Middleware
{
	/// <summary>
	/// Extends IApplicationBuilder to leverage using custom security middleware.
	/// </summary>
	public static class SecurityMiddleExtensions
	{
		/// <summary>
		/// Adds custom authentication in the Startup.cs.
		/// </summary>
		/// <param name="builder">Startup.cs IApplicationBuilder</param>
		/// <returns>IApplicationBuilder with the added Security Middleware.</returns>
		public static IApplicationBuilder UseSecurityMiddleware(this IApplicationBuilder builder)
			=> builder.UseMiddleware<SecurityMiddleware>();
	}
}