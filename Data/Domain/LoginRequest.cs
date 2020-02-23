using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Domain
{
	public class LoginRequest
	{
		public string Token { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public Dictionary<string, string> GetAuthorizationHeader()
		{
			if (Username == null)
				throw new Exception("LoginRequest Username cannot be null");

			if (Password == null)
				throw new Exception("Login Request Password cannot be null");

			var authorizationHeaderValue = string.Format("Basic {0}", Encode(string.Format("{0}:{1}", Username, Password)));

			var header = new Dictionary<string, string>
			{
				{ "Authorization", authorizationHeaderValue }
			};

			return header;
		}

		public Dictionary<string, string> GetHeaders()
			=> GetAuthorizationHeader().ToDictionary(k => k.Key, v => v.Value);

		private string Encode(string plainText)
			=> Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
	}
}
