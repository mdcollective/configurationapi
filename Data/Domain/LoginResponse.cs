namespace Data.Domain
{
	public class LoginResponse
	{
		public bool Success
		{
			get
			{
				return Message.ToLower() == "success";
			}
		}

		public string Token { get; set; }
		public string Message { get; set; }
	}
}