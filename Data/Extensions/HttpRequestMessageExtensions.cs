using System.Collections.Generic;
using System.Net.Http;

namespace Data.Extensions
{
	/// <summary>
	/// HttpRequestMessage extension methods.
	/// </summary>
	public static class HttpRequestMessageExtensions
	{
		/// <summary>
		/// Adds a dictionary of headers to the provided HttpRequestMessage object.
		/// </summary>
		/// <param name="httpRequestMessage">HttpRequestMessage to add headers to.</param>
		/// <param name="headers">Dictionary of headers.</param>
		/// <returns>HttpRequestMessage post modification.</returns>
		public static HttpRequestMessage AddHeaders(this HttpRequestMessage httpRequestMessage, Dictionary<string, string> headers)
		{
			if (headers == null)
				return httpRequestMessage;

			if (headers.Count < 1)
				return httpRequestMessage;

			foreach (var header in headers)
				httpRequestMessage.Headers.Add(header.Key, header.Value);

			return httpRequestMessage;
		}
	}
}
