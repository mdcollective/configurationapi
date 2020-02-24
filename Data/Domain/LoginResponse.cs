using Newtonsoft.Json;

namespace Data.Domain
{
	public class LoginResponse
	{
		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("token")]
		public string Token { get; set; }

		[JsonProperty("errors")]
		public string[] Errors { get; set; }
	}
}