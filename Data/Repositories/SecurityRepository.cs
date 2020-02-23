using Data.Domain;
using Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Data.Repositories
{
	/// <summary>
	/// Repository layer security service to be used for authentication.
	/// </summary>
	public class SecurityRepository : ISecurityRepository
	{
		private IEnumerable<Configuration> _configurations;

		private int _lookupCodeId = 0;

		public SecurityRepository(List<Configuration> configurations)
		{
			_configurations = configurations;
		}

		/// <summary>
		/// Authentication for standard user authentication.
		/// </summary>
		/// <param name="loginRequest">Credentials to authenticate.</param>
		/// <returns>LoginResponse object indicating result.</returns>
		public LoginResponse LogIn(LoginRequest request)
		{
			return new LoginResponse
			{
				Message = "Success",
				Token = "abc"
			};

			//var loginUrl = _configurationProperties.Get("login-url");

			//var loginResponse = new LoginResponse
			//{
			//	ClientId = 0
			//};

			//try
			//{
			//	var httpClient = new HttpClient();

			//	(var response, var error) = httpClient.Post<LoginResponse, LoginRequest>(loginUrl, request, request.GetHeaders());

			//	loginResponse.ClientId = response.ClientId;

			//	loginResponse.Message = response.Message;
			//}
			//catch (Exception ex)
			//{
			//	return new LoginResponse
			//	{
			//		Message = ex.Message
			//	};
			//}

			//return loginResponse;
		}

		/// <summary>
		/// Authentication for api authentication.
		/// </summary>
		/// <param name="loginRequest">Credentials to authenticate.</param>
		/// <returns>ApiLoginResponse object indicating result.</returns>
		public ApiLoginResponse LogIn(ApiLoginRequest request)
		{
			var loginUrl = _configurations.FirstOrDefault(c => c.Name.ToLower() == "securityapiurl").Value;

			try
			{
				var httpClient = new HttpClient();

				(var response, var error) = httpClient.Post<ApiLoginResponse, ApiLoginRequest>($"{loginUrl}apilogin", request, request.GetHeaders());

				return response;
			}
			catch (Exception ex)
			{
				return new ApiLoginResponse
				{
					Message = ex.Message
				};
			}
		}
	}
}
