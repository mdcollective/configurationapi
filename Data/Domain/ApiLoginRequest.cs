using System.Collections.Generic;

namespace Data.Domain
{
	public class ApiLoginRequest
	{
		public string Token { get; set; }

		public Dictionary<string, string> GetAuthorizationHeader()
		{
			return new Dictionary<string, string>
			{
				{ "Authorization", Token },
				{ "Content-Type", "application/json" }
			};
		}

		public Dictionary<string, string> GetHeaders()
		{
			return GetAuthorizationHeader();
		}
	}
}