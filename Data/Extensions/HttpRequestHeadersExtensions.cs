using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Data.Extensions
{
	/// <summary>
	/// HttpRequest extension methods.
	/// </summary>
	public static class HttpRequestHeadersExtensions
	{
		/// <summary>
		/// Accepts a dictionary of headers and returns a HttpRequestHeaders object with the added headers.
		/// </summary>
		/// <param name="httpRequestHeaders">HttpRequestHeader object being extended.</param>
		/// <param name="headers">Dictionary of headers to add.</param>
		/// <returns>HttpRequestHeaders object post modification.</returns>
		public static HttpRequestHeaders Add(this HttpRequestHeaders httpRequestHeaders, Dictionary<string, string> headers)
		{
			if (headers == null)
				return httpRequestHeaders;

			if (headers.Count < 1)
				return httpRequestHeaders;

			foreach (var header in headers)
				httpRequestHeaders.Add(header.Key, header.Value);

			return httpRequestHeaders;
		}
	}
}