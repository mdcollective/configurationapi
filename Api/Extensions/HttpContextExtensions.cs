using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text;

namespace Api.Extensions
{
	public static class HttpContextExtensions
	{
		public static string GetUsername(this HttpContext obj)
		{
			var username = obj.GetUsernameAndPassord().Replace(":" + obj.GetPassword(), string.Empty).Trim();

			return username;
		}

		public static bool HasValidHeaders(this HttpContext context)
		{
			if (!context.GetAuthorizationHeader().Contains("Basic"))
				return false;

			if (context.GetUsername() == string.Empty)
				return false;

			if (context.GetPassword() == string.Empty)
				return false;

			if (context.GetUserId() == string.Empty)
				return false;

			return true;
		}

		public static string GetUserId(this HttpContext obj)
		{
			return obj.Request.Headers["UserId"].ToString().Trim();
		}

		public static bool IsBasicAuthentication(this HttpContext obj)
		{
			var header = obj.Request.Headers["Authorization"].ToString().Trim();

			return header.ToLower().Contains("basic");
		}

		public static bool IsBearerAuthentication(this HttpContext obj)
		{
			var header = obj.Request.Headers["Authorization"].ToString().Trim();

			return header.ToLower().Contains("bearer");
		}

		public static string GetJwt(this HttpContext obj)
		{
			if (IsBasicAuthentication(obj))
				return string.Empty;

			if (!IsBearerAuthentication(obj))
				return string.Empty;

			var authorizationHeader = obj.GetAuthorizationHeader();

			var jwt = authorizationHeader.Replace("Bearer", string.Empty).Trim();

			return jwt;
		}

		public static string GetPassword(this HttpContext obj)
		{
			var userAndPwd = obj.GetUsernameAndPassord();

			var startIndex = userAndPwd.IndexOf(":") + 1;

			var length = userAndPwd.Length - userAndPwd.IndexOf(":") - 1;

			var password = userAndPwd.Substring(startIndex, length).Trim();

			return password;
		}

		public static string GetAuthorizationHeader(this HttpContext obj)
		{
			return obj.Request.Headers["Authorization"].ToString().Trim();
		}

		public static string GetAuthorizationToken(this HttpContext obj)
		{
			return obj.GetAuthorizationHeader().Replace("Basic", string.Empty).Trim();
		}

		public static string GetUsernameAndPassord(this HttpContext obj)
		{
			var authorizationHeader = obj.GetAuthorizationHeader();

			var encodedUserAndPwd = authorizationHeader.Replace("Basic", string.Empty).Trim();

			var decodedUserAndPwd = Decode(encodedUserAndPwd);

			return decodedUserAndPwd;
		}

		private static string Decode(string base64)
		{
			var data = Convert.FromBase64String(base64);

			var decodedString = Encoding.UTF8.GetString(data);

			return decodedString;
		}

		public static string ToHeaderString(this IHeaderDictionary objs)
		{
			return objs.Aggregate(string.Empty, (current, obj) => current + $"{obj.Key}: {obj.Value};");
		}
	}
}