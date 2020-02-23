using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Data.Extensions
{
	/// <summary>
	/// Extension methods for HttpClient class.
	/// </summary>
	public static class HttpClientExtensions
	{
		/// <summary>
		/// Executes an HTTP Get with the provided url and headers. By default this method uses application/json.
		/// </summary>
		/// <param name="httpClient">HttpClient class which is being extended.</param>
		/// <param name="url">Url of HTTP Get.</param>
		/// <param name="headers">Headers to include in HTTP Get.</param>
		/// <returns>Tuple of response and error. Successful messages will return a null error object.</returns>
		public static (string response, string error) Get(this HttpClient httpClient, string url, Dictionary<string, string> headers)
		{
			try
			{
				// Create get request with url and add headers via extension method.
				var request = new HttpRequestMessage(HttpMethod.Get, url).AddHeaders(headers);

				// Send http get request.
				var task = httpClient.SendAsync(request);

				task.Wait();

				var httpResponseMessage = task.Result;

				// Read response into string
				var response = httpResponseMessage.Content.ReadAsStringAsync().Result;

				return (response, null);
			}
			catch (Exception exception)
			{
				return (null, exception.Message);
			}
		}

		/// <summary>
		/// Executes an HTTP Post with the provided url, headers, and body. By default this method uses application/json.
		/// </summary>
		/// <param name="httpClient">HttpClient class which is being extended.</param>
		/// <param name="url">Url of HTTP Post.</param>
		/// <param name="body">Post body to be sent. Defaulted to application/json.</param>
		/// <param name="headers">Headers to include in HTTP Post.</param>
		/// <returns>Tuple of response and error. Successful messages will return a null error object.</returns>
		public static (string response, string error) Post(this HttpClient httpClient, string url, string body, Dictionary<string, string> headers)
		{
			try
			{
				// Create post request with url and add headers via extension method.
				var request = new HttpRequestMessage(HttpMethod.Post, url).AddHeaders(headers);

				// Writes string body to post body assuming application/json.
				request.Content = new StringContent(body, Encoding.UTF8, "application/json");

				// Send http post request.
				var task = httpClient.SendAsync(request);

				task.Wait();

				var httpResponseMessage = task.Result;

				// Reads the response in as a string.
				var response = httpResponseMessage.Content.ReadAsStringAsync().Result;

				return (response, null);
			}
			catch (Exception exception)
			{
				return (null, exception.Message);
			}
		}

		/// <summary>
		/// Extends the string object to convert json to an object of the provided type.
		/// </summary>
		/// <typeparam name="T">Type of object to convert to.</typeparam>
		/// <param name="string">String of json to be converted to object T.</param>
		/// <returns>Object of type T.</returns>
		public static (T item, string error) ToObject<T>(this string @string)
		{
			try
			{
				return (JsonConvert.DeserializeObject<T>(@string), null);
			}
			catch (Exception exception)
			{
				return (default(T), exception.Message);
			}
		}

		/// <summary>
		/// Extends type T to serialize object to a string.
		/// </summary>
		/// <typeparam name="T">Type T of object.</typeparam>
		/// <param name="object">Object of type T.</param>
		/// <returns>String of json.</returns>
		public static (string item, string error) FromString<T>(this T @object)
		{
			try
			{
				return (JsonConvert.SerializeObject(@object), null);
			}
			catch (Exception exception)
			{
				return (null, exception.Message);
			}
		}

		/// <summary>
		/// Executes a HTTP Get call and returns the response as type T.
		/// </summary>
		/// <typeparam name="T">Type of response.</typeparam>
		/// <param name="httpClient">HttpClient object to extend.</param>
		/// <param name="url">Url of get call.</param>
		/// <param name="headers">Headers to include in Get.</param>
		/// <returns>Tuple of T and error string. Error string is null on success.</returns>
		public static (T item, string error) Get<T>(this HttpClient httpClient, string url, Dictionary<string, string> headers)
		{
			// Check for non null and non empty url
			if (string.IsNullOrEmpty(url))
				return (default(T), "Url is null or empty");

			// Make api request and return error on failure
			(var response, var httpError) = httpClient.Get(url, headers);

			if (!string.IsNullOrEmpty(httpError))
				return (default(T), httpError);

			// Convert string api response to an object of type T
			(var @object, var objectError) = response.ToObject<T>();

			if (!string.IsNullOrEmpty(objectError))
				return (default(T), objectError);

			return (@object, null);
		}

		/// <summary>
		/// Executes a post http call.
		/// </summary>
		/// <typeparam name="T">Type of response.</typeparam>
		/// <typeparam name="U">Type of post body.</typeparam>
		/// <param name="httpClient">HttpClient class to extend.</param>
		/// <param name="url">Url of post call.</param>
		/// <param name="body">Body to be sent with post.</param>
		/// <param name="headers">Headers to be included.</param>
		/// <returns></returns>
		public static (T item, string error) Post<T, U>(this HttpClient httpClient, string url, U body, Dictionary<string, string> headers)
		{
			// Check for non null and non empty url
			if (string.IsNullOrEmpty(url))
				return (default(T), "Url is null or empty");

			var bodyString = body.FromString<U>().item;

			// Make api request and return error on failure
			(var response, var httpError) = httpClient.Post(url, bodyString, headers);

			if (!string.IsNullOrEmpty(httpError))
				return (default(T), httpError);

			// Convert string api response to an object of type T
			(var @object, var objectError) = response.ToObject<T>();

			if (!string.IsNullOrEmpty(objectError))
				return (default(T), objectError);

			return (@object, null);
		}
	}
}