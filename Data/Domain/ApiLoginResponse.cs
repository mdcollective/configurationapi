namespace Data.Domain
{
	public class ApiLoginResponse
	{
		public bool Success
		{
			get
			{
				return Message.ToLower() == "success";
			}
		}
		public ApiLoginResponseData Data { get; set; }
		public string Message { get; set; }
	}

	public class ApiLoginResponseData
	{
	}
}